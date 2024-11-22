using Microsoft.AspNetCore.Mvc;
using PaisesEBandeiras.Services.ClimaServices;

namespace PaisesEBandeiras.Controllers
{

    public class ClimaController : Controller
    {
        private readonly IClimaService _climaService;

        public ClimaController(IClimaService climaService)
        {
            _climaService = climaService;
        }

        public async Task<IActionResult> Index(string cidade)
        {
            var clima = await _climaService.BuscaClimaCidadeEspecifica(cidade);

            return View("Index",clima);
        }
        






    }
}