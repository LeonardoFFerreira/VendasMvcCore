using System;
using System.Collections.Generic;
using System.Linq;

namespace VendasMvcCore.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public double Salario { get; set; }
        public Departamento Departamento { get; set; }
        public int DepartamentoID { get; set; }

        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

        public Vendedor()
        {
        }
        public Vendedor(int id, string nome, string email, DateTime dataNascimento, double salario, Departamento departamento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            Salario = salario;
            Departamento = departamento;
        }

        public void AddVendas(Pedido pedido)
        {
            Pedidos.Add(pedido);
        }

        public void RemoverVendas(Pedido pedido)
        {
            Pedidos.Remove(pedido);
        }

        public double TotalVendasVendedor(DateTime dataInicio, DateTime dataFinal)
        {
            return Pedidos.Where(p => p.Data >= dataInicio && p.Data <= dataFinal).Sum(p => p.Valor);
        }
    }
}
