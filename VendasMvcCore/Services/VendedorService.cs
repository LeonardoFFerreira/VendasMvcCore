using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using VendasMvcCore.Data;
using VendasMvcCore.Models;
using VendasMvcCore.Services.Exceptions;

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
            return _context.Vendedor.Include(v => v.Departamento).FirstOrDefault(v => v.Id == id);
        }

        public void Deletar(int id)
        {
            Vendedor vendedor = _context.Vendedor.Find(id);

            _context.Vendedor.Remove(vendedor);
            _context.SaveChanges();
        }

        public void Editar(Vendedor vendedor)
        {
            if (!_context.Vendedor.Any(v => v.Id == vendedor.Id))
            {
                throw new NotFoundException("Vendedor não encontrado");
            }
            try
            {
                _context.Update(vendedor);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }
    }
}
