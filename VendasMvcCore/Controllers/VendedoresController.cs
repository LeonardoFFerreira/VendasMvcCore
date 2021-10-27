using Microsoft.AspNetCore.Mvc;
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
            var departamentos = _departamentoService.Listar();
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
    }
}
