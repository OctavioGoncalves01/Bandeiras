using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace PaisesEBandeiras.Views.Paises
{
    public class PaisTelaFiltros : PageModel
    {
        private readonly ILogger<PaisTelaFiltros> _logger;

        public PaisTelaFiltros(ILogger<PaisTelaFiltros> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}