using System.Collections.Generic;

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
    }
}
