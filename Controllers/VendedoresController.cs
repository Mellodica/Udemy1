using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Udemy1.Models;
using Udemy1.Servicos;

namespace Udemy1.Controllers
{
    public class VendedoresController : Controller
    {

        private readonly VendedorServico _vendedorServico;
        private readonly DepartamentoServico _departamentoServico;

        public VendedoresController(VendedorServico vendedorServico, DepartamentoServico departamentoServico)
        {
            _vendedorServico = vendedorServico;
            _departamentoServico = departamentoServico;
        }

        public IActionResult Index()
        {

            var list = _vendedorServico.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {

            var departaments = _departamentoServico.FindAll();
            var viewModel = new VendedorViewModel { Departamentos = departaments };
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor vendedor)
        {

            _vendedorServico.Insert(vendedor);
            return RedirectToAction(nameof(Index));

        }


    }
}