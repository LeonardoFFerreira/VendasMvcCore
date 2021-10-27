using Microsoft.EntityFrameworkCore.Migrations;

namespace VendasMvcCore.Migrations
{
    public partial class VenderdorForeingKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendedor_Departamento_DepartamentoId",
                table: "Vendedor");

            migrationBuilder.RenameColumn(
                name: "DepartamentoId",
                table: "Vendedor",
                newName: "DepartamentoID");

            migrationBuilder.RenameIndex(
                name: "IX_Vendedor_DepartamentoId",
                table: "Vendedor",
                newName: "IX_Vendedor_DepartamentoID");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoID",
                table: "Vendedor",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendedor_Departamento_DepartamentoID",
                table: "Vendedor",
                column: "DepartamentoID",
                principalTable: "Departamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendedor_Departamento_DepartamentoID",
                table: "Vendedor");

            migrationBuilder.RenameColumn(
                name: "DepartamentoID",
                table: "Vendedor",
                newName: "DepartamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_Vendedor_DepartamentoID",
                table: "Vendedor",
                newName: "IX_Vendedor_DepartamentoId");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoId",
                table: "Vendedor",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Vendedor_Departamento_DepartamentoId",
                table: "Vendedor",
                column: "DepartamentoId",
                principalTable: "Departamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
