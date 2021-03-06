// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using VendasMvcCore.Data;

namespace VendasMvcCore.Migrations
{
    [DbContext(typeof(VendasMvcCoreContext))]
    partial class VendasMvcCoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("VendasMvcCore.Models.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Departamento");
                });

            modelBuilder.Entity("VendasMvcCore.Models.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Data");

                    b.Property<int>("Status");

                    b.Property<double>("Valor");

                    b.Property<int?>("VendedorId");

                    b.HasKey("Id");

                    b.HasIndex("VendedorId");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("VendasMvcCore.Models.Vendedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataNascimento");

                    b.Property<int>("DepartamentoID");

                    b.Property<string>("Email");

                    b.Property<string>("Nome");

                    b.Property<double>("Salario");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoID");

                    b.ToTable("Vendedor");
                });

            modelBuilder.Entity("VendasMvcCore.Models.Pedido", b =>
                {
                    b.HasOne("VendasMvcCore.Models.Vendedor", "Vendedor")
                        .WithMany("Pedidos")
                        .HasForeignKey("VendedorId");
                });

            modelBuilder.Entity("VendasMvcCore.Models.Vendedor", b =>
                {
                    b.HasOne("VendasMvcCore.Models.Departamento", "Departamento")
                        .WithMany("Vendedores")
                        .HasForeignKey("DepartamentoID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
