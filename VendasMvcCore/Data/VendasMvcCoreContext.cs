using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VendasMvcCore.Models;

namespace VendasMvcCore.Data
{
    public class VendasMvcCoreContext : DbContext
    {
        public VendasMvcCoreContext(DbContextOptions<VendasMvcCoreContext> options) : base(options)
        {
        }

        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
    }
}
