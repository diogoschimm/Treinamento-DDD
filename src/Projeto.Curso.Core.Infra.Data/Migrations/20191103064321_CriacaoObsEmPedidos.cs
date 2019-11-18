using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto.Curso.Core.Infra.Data.Migrations
{
    public partial class CriacaoObsEmPedidos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        { 
            migrationBuilder.AddColumn<string>(
                name: "observacao",
                table: "Pedidos",
                type: "varchar(500)",
                nullable: true); 
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "varchar(500)",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "uf",
                table: "Clientes");

            migrationBuilder.AddColumn<int>(
                name: "Endereco_UF_Estado_UFEnderecoClienteId",
                table: "Fornecedores",
                type: "int",
                nullable: true)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Fornecedores_Endereco_UF_Estado_UFEnderecoClienteId",
                table: "Fornecedores",
                column: "Endereco_UF_Estado_UFEnderecoClienteId");
        }
    }
}
