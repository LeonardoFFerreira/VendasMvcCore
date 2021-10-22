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

        public DbSet<VendasMvcCore.Models.Departamento> Departamento { get; set; }
    }
}
