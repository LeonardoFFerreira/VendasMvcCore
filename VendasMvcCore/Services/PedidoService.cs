using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasMvcCore.Data;
using VendasMvcCore.Models;

namespace VendasMvcCore.Services
{
    public class PedidoService
    {
        private readonly VendasMvcCoreContext _context;

        public PedidoService(VendasMvcCoreContext context)
        {
            _context = context;
        }

        public async Task<List<Pedido>> BuscaPorDataAsync(DateTime? minDate, DateTime? maxDate)
        {
            IQueryable<Pedido> listaPedidos = from obj in _context.Pedido select obj;

            return await listaPedidos.Where(x => x.Data >= minDate &&
                                                 x.Data <= maxDate)
                                     .Include(x => x.Vendedor)
                                     .Include(x => x.Vendedor.Departamento)
                                     .OrderByDescending(x => x.Data)
                                     .ToListAsync();
        }
    }
}
