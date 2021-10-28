using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace VendasMvcCore.Models
{
    public class Vendedor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        [StringLength(60, MinimumLength = 15, ErrorMessage = "O {0} deve conter entre {2} e {1} caracteres")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "Insira um e-mail válido")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        [Display(Name = "Data de nasc.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }

        [Range(100.0, 50000.0, ErrorMessage = "O {0} deve ser entre {1} e {2}")]
        [Required(ErrorMessage = "{0} é obrigatório")]
        [Display(Name = "Salário")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
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
