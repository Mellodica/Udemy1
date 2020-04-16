using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Udemy1.Servicos;

namespace Udemy1.Controllers
{
    public class VendedoresController : Controller
    {

        private readonly VendedorServico _vendedorServico;

        public VendedoresController(VendedorServico vendedorServico)
        {
            _vendedorServico = vendedorServico;
        }

        public IActionResult Index()
        {

            var list = _vendedorServico.FindAll();
            return View(list);
        }
    }
}