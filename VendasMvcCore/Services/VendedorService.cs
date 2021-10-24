using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasMvcCore.Data;
using VendasMvcCore.Models;

namespace VendasMvcCore.Services
{

    public class VendedorService
    {
        private readonly VendasMvcCoreContext _context;

        public VendedorService(VendasMvcCoreContext context)
        {
            _context = context;

        }

        public List<Vendedor> Listar()
        {
            return _context.Vendedor.ToList();
        }
    }
}
