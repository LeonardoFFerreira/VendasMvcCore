using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VendasMvcCore.Models;

namespace VendasMvcCore.Controllers
{
    public class DepartamentosController : Controller
    {
        public IActionResult Index()
        {
            //Criado uma lista de departamentos e fazendo o retorno para a view

            List<Departamento> lista = new List<Departamento>();

            lista.Add(new Departamento { Id = 1, Nome = "Eletrônicos" });
            lista.Add(new Departamento { Id = 2, Nome = "Moda" });

            return View(lista);
        }
    }
}
