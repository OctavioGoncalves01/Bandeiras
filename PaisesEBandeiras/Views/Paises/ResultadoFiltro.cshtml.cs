using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace PaisesEBandeiras.Views.Paises
{
    public class ResultadoFiltro : PageModel
    {
        private readonly ILogger<ResultadoFiltro> _logger;

        public ResultadoFiltro(ILogger<ResultadoFiltro> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}