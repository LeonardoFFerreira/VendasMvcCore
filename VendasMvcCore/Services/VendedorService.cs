using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<List<Vendedor>> ListarAsync()
        {
            return await _context.Vendedor.ToListAsync();
        }

        public async Task CadastrarAsync(Vendedor vendedor)
        {
            _context.Add(vendedor);
            await _context.SaveChangesAsync();
        }

        public async Task<Vendedor> BuscaPorIdAsync(int id)
        {
            return await _context.Vendedor.Include(v => v.Departamento).FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task DeletarAsync(int id)
        {
            try
            {
                Vendedor vendedor = await _context.Vendedor.FindAsync(id);

                _context.Vendedor.Remove(vendedor);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException("Erro de integridade de dados - Não é possível delelar um vendedor que possi vendas vinculadas");
            }
        }

        public async Task EditarAsync(Vendedor vendedor)
        {
            bool contenm = await _context.Vendedor.AnyAsync(v => v.Id == vendedor.Id);

            if (!contenm)
            {
                throw new NotFoundException("Vendedor não encontrado");
            }
            try
            {
                _context.Update(vendedor);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }
    }
}
