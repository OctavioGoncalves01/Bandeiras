using System.Text.Json;
using PaisesEBandeiras.Models;

namespace PaisesEBandeiras.Services.ClimaServices
{
    public class ClimaService : IClimaService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "API_Key"; 
        private readonly string _baseUrl = "http://api.weatherapi.com/v1/current.json";

        public ClimaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherModel> BuscaClimaCidadeEspecifica(string nomeCidade)
        {
            var url = $"{_baseUrl}?key={_apiKey}&q={nomeCidade}";

            try
            {
                var response = await _httpClient.GetStringAsync(url);

                var climaJson = JsonSerializer.Deserialize<JsonElement>(response);

                var clima = new WeatherModel
                {
                    Location = new Location
                    {
                        Name = climaJson.GetProperty("location").GetProperty("name").GetString(),
                        Region = climaJson.GetProperty("location").GetProperty("region").GetString(),
                        Country = climaJson.GetProperty("location").GetProperty("country").GetString(),
                        Lat = climaJson.GetProperty("location").GetProperty("lat").GetDouble(),
                        Lon = climaJson.GetProperty("location").GetProperty("lon").GetDouble(),
                        Timezone = climaJson.GetProperty("location").GetProperty("tz_id").GetString(),
                        LocaltimeEpoch = climaJson.GetProperty("location").GetProperty("localtime_epoch").GetInt64(),
                        Localtime = climaJson.GetProperty("location").GetProperty("localtime").GetString()
                    },
                    Current = new CurrentWeather
                    {
                        LastUpdated = climaJson.GetProperty("current").GetProperty("last_updated").GetString(),
                        TempC = climaJson.GetProperty("current").GetProperty("temp_c").GetDouble(),
                        TempF = climaJson.GetProperty("current").GetProperty("temp_f").GetDouble(),
                        IsDay = climaJson.GetProperty("current").GetProperty("is_day").GetInt32() == 1,
                        Condition = new WeatherCondition
                        {
                            Text = climaJson.GetProperty("current").GetProperty("condition").GetProperty("text").GetString(),
                            Icon = climaJson.GetProperty("current").GetProperty("condition").GetProperty("icon").GetString(),
                            Code = climaJson.GetProperty("current").GetProperty("condition").GetProperty("code").GetInt32()
                        },
                        WindMph = climaJson.GetProperty("current").GetProperty("wind_mph").GetDouble(),
                        WindKph = climaJson.GetProperty("current").GetProperty("wind_kph").GetDouble(),
                        WindDegree = climaJson.GetProperty("current").GetProperty("wind_degree").GetInt32(),
                        WindDir = climaJson.GetProperty("current").GetProperty("wind_dir").GetString(),
                        PressureMb = climaJson.GetProperty("current").GetProperty("pressure_mb").GetDouble(),
                        PressureIn = climaJson.GetProperty("current").GetProperty("pressure_in").GetDouble(),
                        PrecipMm = climaJson.GetProperty("current").GetProperty("precip_mm").GetDouble(),
                        PrecipIn = climaJson.GetProperty("current").GetProperty("precip_in").GetDouble(),
                        Humidity = climaJson.GetProperty("current").GetProperty("humidity").GetInt32(),
                        Cloud = climaJson.GetProperty("current").GetProperty("cloud").GetInt32(),
                        FeelslikeC = climaJson.GetProperty("current").GetProperty("feelslike_c").GetDouble(),
                        FeelslikeF = climaJson.GetProperty("current").GetProperty("feelslike_f").GetDouble(),
                        WindchillC = climaJson.GetProperty("current").GetProperty("windchill_c").GetDouble(),
                        WindchillF = climaJson.GetProperty("current").GetProperty("windchill_f").GetDouble(),
                        HeatindexC = climaJson.GetProperty("current").GetProperty("heatindex_c").GetDouble(),
                        HeatindexF = climaJson.GetProperty("current").GetProperty("heatindex_f").GetDouble(),
                        DewpointC = climaJson.GetProperty("current").GetProperty("dewpoint_c").GetDouble(),
                        DewpointF = climaJson.GetProperty("current").GetProperty("dewpoint_f").GetDouble(),
                        VisKm = climaJson.GetProperty("current").GetProperty("vis_km").GetDouble(),
                        VisMiles = climaJson.GetProperty("current").GetProperty("vis_miles").GetDouble(),
                        Uv = climaJson.GetProperty("current").GetProperty("uv").GetDouble(),
                        GustMph = climaJson.GetProperty("current").GetProperty("gust_mph").GetDouble(),
                        GustKph = climaJson.GetProperty("current").GetProperty("gust_kph").GetDouble()
                    }
                };


                return clima;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao buscar clima: {ex.Message}");
                return null;
            }
        }
    }
}
