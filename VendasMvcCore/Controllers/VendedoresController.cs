using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using VendasMvcCore.Models;
using VendasMvcCore.Models.ViewModels;
using VendasMvcCore.Services;
using VendasMvcCore.Services.Exceptions;

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

        public async Task<IActionResult> Index()
        {
            List<Vendedor> vendedores = await _vendedorService.ListarAsync();

            return View(vendedores);
        }

        public async Task<IActionResult> Cadastrar()
        {
            List<Departamento> departamentos = await _departamentoService.ListarAsync();
            var viewModel = new VendedorViewModel { Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar(Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                List<Departamento> departamentos = await _departamentoService.ListarAsync();
                VendedorViewModel viewModel = new VendedorViewModel { Vendedor = vendedor, Departamentos = departamentos };
                return View(viewModel);
            }
            await _vendedorService.CadastrarAsync(vendedor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Deletar(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id nulo ou inválido" });
            }

            Vendedor vendedor = await _vendedorService.BuscaPorIdAsync(id.Value);

            if (vendedor == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(vendedor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deletar(int id)
        {
            try
            {
                await _vendedorService.DeletarAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id nulo ou inválido" });
            }

            Vendedor vendedor = await _vendedorService.BuscaPorIdAsync(id.Value);
            if (vendedor == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(vendedor);
        }

        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id nulo ou inválido" });
            }
            Vendedor vendedor = await _vendedorService.BuscaPorIdAsync(id.Value);
            if (vendedor == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            List<Departamento> departamentos = await _departamentoService.ListarAsync();
            VendedorViewModel viewModel = new VendedorViewModel { Vendedor = vendedor, Departamentos = departamentos };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                List<Departamento> departamentos = await _departamentoService.ListarAsync();
                VendedorViewModel viewModel = new VendedorViewModel { Vendedor = vendedor, Departamentos = departamentos };
                return View(viewModel);
            }

            if (id != vendedor.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Os Id's fornecidos são imcompatíveis" });
            }
            try
            {
                await _vendedorService.EditarAsync(vendedor);
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
