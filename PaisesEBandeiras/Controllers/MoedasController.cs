using Microsoft.AspNetCore.Mvc;
using PaisesEBandeiras.Services.MoedasServices;

namespace PaisesEBandeiras.Controllers
{
    public class MoedasController : Controller
    {
        private readonly IMoedasService _moedasService;

        public MoedasController(IMoedasService moedasService)
        {
            _moedasService = moedasService;
        }
        
        public async Task<IActionResult> Index(string nome)
        {
            var dadosMoeda = await _moedasService.BuscarCambioEspecifico(nome);
            return View(dadosMoeda);
        }

        
    }
}