using System.Text.Json;
using PaisesEBandeiras.Models;

namespace PaisesEBandeiras.Services.PaisesServices
{
    public class PaisesService : IPaisesService
    {

        private readonly HttpClient _httpClient;

        public PaisesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<List<PaisesModel>> BuscarTodosPaises()
        {
            var url = "https://restcountries.com/v3.1/all";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            var paisesJson = JsonSerializer.Deserialize<List<JsonElement>>(content);
            var listaPaises = new List<PaisesModel>();

            foreach (var pais in paisesJson)
            {
                var nomePais = pais.GetProperty("name").GetProperty("common").GetString();
                var nomeCapital = pais.TryGetProperty("capital", out var capitalValue) 
                    ? capitalValue[0].GetString() : null;
                var bandeira = pais.GetProperty("flags").GetProperty("png").GetString();

                var populacao = pais.TryGetProperty("population", 
                    out var populacaoValue) && 
                    populacaoValue.TryGetInt32(out var populacaoInt) 
                    ? populacaoInt : (int?)null;

                var area = pais.TryGetProperty("area", out var areaValue)
                                                ? areaValue.ToString() 
                                                : "N/A";

                listaPaises.Add(new PaisesModel
                {
                    NomePais = nomePais,
                    NomeCapital = nomeCapital,
                    Bandeira = bandeira,
                    Area = area,
                    Populacao = populacao
                });
            }

            return listaPaises;
        }

          public async Task<List<PaisesModelDetalhes>> BuscarPaisEspecifico(string nome)
        {
            var url = $"https://restcountries.com/v3.1/name/{nome}?fullText=true";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            var paisesJson = JsonSerializer.Deserialize<List<JsonElement>>(content);
            var listaPaises = new List<PaisesModelDetalhes>();

            foreach (var pais in paisesJson)
            {
                var nomePais = pais.GetProperty("name").GetProperty("common").GetString();
                var nomeCapital = pais.TryGetProperty("capital", out var capitalValue) 
                    ? capitalValue[0].GetString() : null;
                var bandeira = pais.GetProperty("flags").GetProperty("png").GetString();

                var populacao = pais.TryGetProperty("population", 
                    out var populacaoValue) && 
                    populacaoValue.TryGetInt32(out var populacaoInt) 
                    ? populacaoInt : (int?)null;

                var area = pais.TryGetProperty("area", out var areaValue)
                                                ? areaValue.ToString() 
                                                : "N/A";

                var regiao = pais.TryGetProperty("region", out var regiaoValue)
                        ? regiaoValue.GetString()
                        : null;

                var subregiao = pais.TryGetProperty("subregion", out var subregionValue)
                                ? subregionValue.GetString() 
                                : null;

                var moeda = pais.TryGetProperty("currencies", out var moedaValue) 
                            ? moedaValue.EnumerateObject().FirstOrDefault().Value.GetProperty("name").GetString() 
                            : null;

                var linguas = pais.TryGetProperty("languages", out var linguasValue) 
                    ? linguasValue.EnumerateObject().Select(l => l.Value.GetString()).ToList() 
                    : new List<string>();

                listaPaises.Add(new PaisesModelDetalhes
                {
                    NomePais = nomePais,
                    NomeCapital = nomeCapital,
                    Bandeira = bandeira,
                    Area = area,
                    Populacao = populacao,
                    Regiao = regiao,
                    SubRegiao = subregiao,
                    Moeda = moeda,
                    Linguas = linguas
                });
            }

            return listaPaises;
        }


        public async Task<List<PaisesModel>> BuscarPorContinente(string continenteNome)
        {
            var url = $"https://restcountries.com/v3.1/region/{continenteNome}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            var paisesJson = JsonSerializer.Deserialize<List<JsonElement>>(content);
            var listaPaises = new List<PaisesModel>();

            foreach (var pais in paisesJson)
            {
                var nomePais = pais.GetProperty("name").GetProperty("common").GetString();
                var nomeCapital = pais.TryGetProperty("capital", out var capitalValue) 
                    ? capitalValue[0].GetString() : null;
                var bandeira = pais.GetProperty("flags").GetProperty("png").GetString();

                var populacao = pais.TryGetProperty("population", 
                    out var populacaoValue) && 
                    populacaoValue.TryGetInt32(out var populacaoInt) 
                    ? populacaoInt : (int?)null;

                var area = pais.TryGetProperty("area", out var areaValue)
                                                ? areaValue.ToString() 
                                                : "N/A";

                listaPaises.Add(new PaisesModel
                {
                    NomePais = nomePais,
                    NomeCapital = nomeCapital,
                    Bandeira = bandeira,
                    Area = area,
                    Populacao = populacao
                });
            }

            return listaPaises;
        }


    
    }
}