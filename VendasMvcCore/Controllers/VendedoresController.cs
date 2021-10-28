using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using VendasMvcCore.Models;
using VendasMvcCore.Models.ViewModels;
using VendasMvcCore.Services;

namespace VendasMvcCore.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly VendedorService _vendedorService;
        private readonly DepartamentoService _departamentoService;

        public VendedoresController(VendedorService vendedorService, DepartamentoService departamentoService)
        {
            _vendedorService = vendedorService;
            _departamentoService = departamentoService;
        }

        public IActionResult Index()
        {
            var list = _vendedorService.Listar();

            return View(list);
        }

        public IActionResult Cadastrar()
        {
            List<Departamento> departamentos = _departamentoService.Listar();
            var viewModel = new VendedorViewModel { Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(Vendedor vendedor)
        {
            _vendedorService.Cadastrar(vendedor);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Deletar(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id nulo ou inválido" });
            }

            Vendedor vendedor = _vendedorService.BuscaPorId(id.Value);

            if (vendedor == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(vendedor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Deletar(int id)
        {
            _vendedorService.Deletar(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id nulo ou inválido" });
            }

            Vendedor vendedor = _vendedorService.BuscaPorId(id.Value);
            if (vendedor == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(vendedor);
        }

        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id nulo ou inválido" });
            }
            Vendedor vendedor = _vendedorService.BuscaPorId(id.Value);
            if (vendedor == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            List<Departamento> departamentos = _departamentoService.Listar();
            VendedorViewModel viewModel = new VendedorViewModel { Vendedor = vendedor, Departamentos = departamentos };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, Vendedor vendedor)
        {
            if (id != vendedor.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Os Id's fornecidos são imcompatíveis" });
            }
            try
            {
                _vendedorService.Editar(vendedor);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Error(string message)
        {
            var viewmodel = new ErrorViewModel { Message = message, RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };

            return View(viewmodel);
        }
    }
}
