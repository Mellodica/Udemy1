using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Udemy1.Servicos;

namespace Udemy1.Controllers
{
    public class VendaGravadasController : Controller
    {
        private readonly VendaGravadaServico _vendaGravadaServico;

        public VendaGravadasController(VendaGravadaServico vendaGravadaServico)
        {
            _vendaGravadaServico = vendaGravadaServico;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> BuscaSimples(DateTime? minDate, DateTime? maxDate)
        {

            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            ViewData["MinDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["MaxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _vendaGravadaServico.FindByDateAsync(minDate, maxDate);

            return View(result);
        }

        public IActionResult BuscaAgrupada()
        {
            return View();
        }
    }
}