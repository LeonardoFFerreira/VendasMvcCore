using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<List<Departamento>> ListarAsync()
        {
            return await _context.Departamento.OrderBy(d => d.Nome).ToListAsync();
        }
    }
}
