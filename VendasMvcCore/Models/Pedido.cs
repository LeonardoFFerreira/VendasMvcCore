using System;
using System.ComponentModel.DataAnnotations;
using VendasMvcCore.Models.Enums;

namespace VendasMvcCore.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Valor { get; set; }
       
        public StatusVenda Status { get; set; }
        public Vendedor Vendedor { get; set; }
        public Pedido()
        {
        }
        public Pedido(int id, DateTime data, double valor, StatusVenda status, Vendedor vendedor)
        {
            Id = id;
            Data = data;
            Valor = valor;
            Status = status;
            Vendedor = vendedor;
        }
    }
}
