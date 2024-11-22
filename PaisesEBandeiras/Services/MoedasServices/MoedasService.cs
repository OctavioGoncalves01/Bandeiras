using System.Text.Json;
using PaisesEBandeiras.Models;

namespace PaisesEBandeiras.Services.MoedasServices
{
    public class MoedasService : IMoedasService
    {
        private readonly HttpClient _httpClient;

        public MoedasService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<MoedasModel> BuscarCambioEspecifico(string nome)
        {
            
            var apiUrl = $"https://v6.exchangerate-api.com/v6/APY_Key/latest/{nome}"; 


            var response = await _httpClient.GetStringAsync(apiUrl);

            var moedasPrincipais = new HashSet<string>
            {
                "USD", "CNY", "JPY", "EUR", "INR", 
                "GBP", "BRL", "CAD", "AUD", "MXN"  
            };

            using (JsonDocument doc = JsonDocument.Parse(response))
            {
                var lista = doc.RootElement;

                var result = lista.GetProperty("result").GetString();
                var documentation = lista.GetProperty("documentation").GetString();
                var termsOfUse = lista.GetProperty("terms_of_use").GetString();
                var timeLastUpdateUnix = lista.GetProperty("time_last_update_unix").GetInt64();
                var timeLastUpdateUtc = lista.GetProperty("time_last_update_utc").GetString();
                var timeNextUpdateUnix = lista.GetProperty("time_next_update_unix").GetInt64();
                var timeNextUpdateUtc = lista.GetProperty("time_next_update_utc").GetString();
                var baseCode = lista.GetProperty("base_code").GetString();

        
                var conversionRates = new Dictionary<string, decimal>();
                var rates = lista.GetProperty("conversion_rates");
        
                foreach (var rate in rates.EnumerateObject())
                {
                    var currencyCode = rate.Name;
                    var rateValue = rate.Value.GetDecimal(); 

                    if (moedasPrincipais.Contains(currencyCode))
                    {
                        conversionRates[currencyCode] = rateValue;
                    }
                }

                
                var moedasModel = new MoedasModel
                {
                    Result = result,
                    Documentation = documentation,
                    TermsOfUse = termsOfUse,
                    TimeLastUpdateUnix = timeLastUpdateUnix,
                    TimeLastUpdateUtc = timeLastUpdateUtc,
                    TimeNextUpdateUnix = timeNextUpdateUnix,
                    TimeNextUpdateUtc = timeNextUpdateUtc,
                    BaseCode = baseCode,
                    ConversionRates = conversionRates
                };

                return moedasModel; 
            }
        }





    }
}