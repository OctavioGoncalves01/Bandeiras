using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using PaisesEBandeiras.Models;

namespace PaisesEBandeiras.Controllers
{
    [Route("[controller]")]
    public class PaisesController : Controller
    {
        private readonly HttpClient _httpClient;


        public PaisesController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var listaPaises = await BuscarTodosPaises();
            return View(listaPaises);
        }

        
        private async Task<List<PaisesModel>> BuscarTodosPaises()
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
                var nomeCapital = pais.TryGetProperty("capital", out var capitalValue) ? capitalValue[0].GetString() : null;
                var bandeira = pais.GetProperty("flags").GetProperty("png").GetString();
                

                var populacao = pais.TryGetProperty("population", out var populacaoValue) && populacaoValue.TryGetInt32(out var populacaoInt) ? populacaoInt : (int?)null;
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
