using System.Collections.Generic;
using System;
using System.Linq;

namespace VendasMvcCore.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Vendedor> Vendedores { get; set; } = new List<Vendedor>();
        public Departamento()
        {
        }
        public Departamento(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
        public void AddVendedor(Vendedor vendedor)
        {
            Vendedores.Add(vendedor);
        }
        public double TotalVendasDepartamento(DateTime dataInico, DateTime dataFinal)
        {
            return Vendedores.Sum(v => v.TotalVendasVendedor(dataInico, dataFinal));
        }
    }
}
