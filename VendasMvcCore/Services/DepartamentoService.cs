using System.Collections.Generic;
using System.Linq;
using VendasMvcCore.Data;
using VendasMvcCore.Models;

namespace VendasMvcCore.Services
{
    public class DepartamentoService
    {
        private readonly VendasMvcCoreContext _context;

        public DepartamentoService(VendasMvcCoreContext context)
        {
            _context = context;
        }

        public List<Departamento> Listar()
        {
            return _context.Departamento.ToList();
        }
    }
}
