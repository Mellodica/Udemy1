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

        public async Task<IActionResult> Index()
        {

            var list = await _vendedorServico.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {

            
            var departaments = await _departamentoServico.FindAllAsync();
            var viewModel = new VendedorViewModel { Departamentos = departaments };
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                var departamentos = await _departamentoServico.FindAllAsync();
                var viewModel = new VendedorViewModel { Vendedor = vendedor, Departamentos = departamentos };
                return View(viewModel);
            }
            await _vendedorServico.InsertAsync(vendedor);
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int? id)
        {
            if ( id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = await _vendedorServico.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrada" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int Id)
        {
            await _vendedorServico.RemoveAsync(Id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detalhe(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = await _vendedorServico.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = await _vendedorServico.FindByIdAsync(id.Value);

            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrada" });
            }
            List<Departamento> departamentos = await _departamentoServico.FindAllAsync();
            VendedorViewModel viewModel = new VendedorViewModel { Vendedor = obj, Departamentos = departamentos };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Vendedor vendedor)
        {

            if (!ModelState.IsValid)
            {
                var departamentos = await _departamentoServico.FindAllAsync();
                var viewModel = new VendedorViewModel { Vendedor = vendedor, Departamentos = departamentos};
                return View(viewModel);
            }
            if (id != vendedor.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrada" });
            }

            try
            {
                await _vendedorServico.AtualizarAsync(vendedor);
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