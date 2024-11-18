using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace PaisesEBandeiras.Views.Paises
{
    public class PaisDetalhes : PageModel
    {
        private readonly ILogger<PaisDetalhes> _logger;

        public PaisDetalhes(ILogger<PaisDetalhes> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}