using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasMvcCore.Models;
using VendasMvcCore.Models.Enums;

namespace VendasMvcCore.Data
{
    public class CargaDbService
    {
        private VendasMvcCoreContext _context;

        public CargaDbService(VendasMvcCoreContext context)
        {
            _context = context;
        }

        public void CargaDb()
        {
            if (_context.Departamento.Any() || _context.Pedido.Any() || _context.Vendedor.Any()) { return; }

            Departamento departamento01 = new Departamento(01, "Informática");
            Departamento departamento02 = new Departamento(02, "Beleza");
            Departamento departamento03 = new Departamento(03, "Moda");

            Vendedor vendedor01 = new Vendedor(01, "Leonardo", "leo@gmail.com", new DateTime(1990, 08, 08), 1000.0, departamento01);
            Vendedor vendedor02 = new Vendedor(02, "Carol", "carol@gmail.com", new DateTime(1987, 11, 20), 1000.0, departamento03);

            Pedido pedido01 = new Pedido(01, new DateTime(2021, 10, 23), 100.0, StatusVenda.FATURADO, vendedor02);
            Pedido pedido02 = new Pedido(02, new DateTime(2021, 10, 22), 80.0, StatusVenda.PENDENTE, vendedor02);
            Pedido pedido03 = new Pedido(03, new DateTime(2021, 10, 23), 50.0, StatusVenda.CANCELADO, vendedor02);
            Pedido pedido04 = new Pedido(04, new DateTime(2021, 10, 05), 20.0, StatusVenda.FATURADO, vendedor02);
            Pedido pedido05 = new Pedido(05, new DateTime(2021, 10, 23), 100.0, StatusVenda.FATURADO, vendedor02);
            Pedido pedido06 = new Pedido(06, new DateTime(2021, 10, 03), 45.0, StatusVenda.CANCELADO, vendedor01);
            Pedido pedido07 = new Pedido(07, new DateTime(2021, 10, 23), 60.0, StatusVenda.PENDENTE, vendedor01);
            Pedido pedido08 = new Pedido(08, new DateTime(2021, 10, 06), 5.0, StatusVenda.PENDENTE, vendedor02);
            Pedido pedido09 = new Pedido(09, new DateTime(2021, 10, 23), 1.0, StatusVenda.PENDENTE, vendedor01);
            Pedido pedido10 = new Pedido(10, new DateTime(2021, 10, 23), 250.0, StatusVenda.FATURADO, vendedor02);

            _context.Departamento.AddRange(departamento01, departamento02, departamento03);
            _context.Vendedor.AddRange(vendedor01, vendedor02);
            _context.Pedido.AddRange(pedido01, pedido02, pedido03, pedido04, pedido05, pedido06, pedido07, pedido08, pedido09, pedido10);

            _context.SaveChanges();
        }
    }
}
