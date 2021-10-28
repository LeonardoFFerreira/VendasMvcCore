using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
                return NotFound();
            }

            Vendedor vendedor = _vendedorService.BuscaPorId(id.Value);

            if (vendedor == null)
            {
                return NotFound();
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
                return NotFound();
            }

            Vendedor vendedor = _vendedorService.BuscaPorId(id.Value);
            if (vendedor == null)
            {
                return NotFound();
            }

            return View(vendedor);
        }

        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Vendedor vendedor = _vendedorService.BuscaPorId(id.Value);
            if (vendedor == null)
            {
                return NotFound();
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
                return BadRequest();
            }
            try
            {
                _vendedorService.Editar(vendedor);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }
        }
    }
}
