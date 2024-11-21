using Microsoft.AspNetCore.Mvc;
using PaisesEBandeiras.Models;
using PaisesEBandeiras.Services.PaisesServices;

namespace PaisesEBandeiras.Controllers
{
    public class PaisesController : Controller
    {
        private readonly IPaisesService _paisService;

        public PaisesController(IPaisesService paisService)
        {
            _paisService = paisService;
        }

        public async Task<IActionResult> Index()
        {
            var listaPaises = await _paisService.BuscarTodosPaises();
            return View(listaPaises);
        }

        public async Task<IActionResult> PaisDetalhes(string nome)
        {
            var paisDetalhes = await _paisService.BuscarPaisEspecifico(nome);
            return View("PaisDetalhes", paisDetalhes);
        }

        public async Task<IActionResult> ResultadoFiltro(string continente)
        {
            string txt = "Paises da Regiao " + continente;
            var listaPaisesPorContinente = await _paisService.BuscarPorContinente(continente);

            ViewBag.Titulo = txt;

            return View("ResultadoFiltro", listaPaisesPorContinente);
        }

        public IActionResult PaisTelaFiltros()
        {
            return View();
        }
    }
}