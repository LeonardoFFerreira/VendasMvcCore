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

        public void Cadastrar(Vendedor vendedor)
        {
            _context.Add(vendedor);
            _context.SaveChanges();
        }

        public Vendedor BuscaPorId(int id)
        {
            return _context.Vendedor.FirstOrDefault(v => v.Id == id);
        }

        public void Deletar(int id)
        {
            Vendedor vendedor = _context.Vendedor.Find(id);

            _context.Vendedor.Remove(vendedor);
            _context.SaveChanges();
        }
    }
}
