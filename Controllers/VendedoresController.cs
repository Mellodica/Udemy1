using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Udemy_1.Models;
using Udemy1.Models;
using Udemy1.Servicos;
using Udemy1.Servicos.Erros;

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

        public IActionResult Delete(int? id)
        {
            if ( id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = _vendedorServico.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrada" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int Id)
        {
            _vendedorServico.Remove(Id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhe(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _vendedorServico.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = _vendedorServico.FindById(id.Value);

            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrada" });
            }
            List<Departamento> departamentos = _departamentoServico.FindAll();
            VendedorViewModel viewModel = new VendedorViewModel { Vendedor = obj, Departamentos = departamentos };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Vendedor vendedor)
        {
            if(id != vendedor.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrada" });
            }

            try
            {
                _vendedorServico.Atualizar(vendedor);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException e)
            {

                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            catch (DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Error(String message)
        {
            var viewModel = new ErrorViewModel
            {
                Mensagem = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }


    }
}