using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto.Curso.Core.Infra.Data.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apelido = table.Column<string>(type: "varchar(20)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    cpfCnpj = table.Column<string>(type: "varchar(14)", nullable: true),
                    email = table.Column<string>(type: "varchar(100)", nullable: true),
                    cep = table.Column<string>(type: "varchar(9)", nullable: true),
                    endereco = table.Column<string>(type: "varchar(100)", nullable: true),
                    numeroEndereco = table.Column<string>(type: "varchar(20)", nullable: true),
                    bairro = table.Column<string>(type: "varchar(60)", nullable: true),
                    cidade = table.Column<string>(type: "varchar(100)", nullable: true),
                    uf = table.Column<string>(type: "varchar(2)", nullable: true),
                    complemento = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apelido = table.Column<string>(type: "varchar(20)", nullable: true),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    cpfCnpj = table.Column<string>(type: "varchar(14)", nullable: true),
                    email = table.Column<string>(type: "varchar(100)", nullable: true),
                    cep = table.Column<string>(type: "varchar(9)", nullable: true),
                    endereco = table.Column<string>(type: "varchar(100)", nullable: true),
                    numeroEndereco = table.Column<string>(type: "varchar(20)", nullable: true),
                    bairro = table.Column<string>(type: "varchar(60)", nullable: true),
                    cidade = table.Column<string>(type: "varchar(100)", nullable: true),
                    uf = table.Column<string>(type: "varchar(2)", nullable: true),
                    complemento = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dataPedido = table.Column<DateTime>(type: "datetime", nullable: false),
                    dataEntrega = table.Column<DateTime>(type: "datetime", nullable: true),
                    idCliente = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Clientes_idCliente",
                        column: x => x.idCliente,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    apelido = table.Column<string>(type: "varchar(100)", nullable: false),
                    nomeProduto = table.Column<string>(type: "varchar(100)", nullable: false),
                    valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    unidade = table.Column<string>(type: "varchar(2)", nullable: false),
                    IdFornecedor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Fornecedores_IdFornecedor",
                        column: x => x.IdFornecedor,
                        principalTable: "Fornecedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItensPedido",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    qtd = table.Column<int>(nullable: false),
                    idPedido = table.Column<int>(nullable: false),
                    idProduto = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensPedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensPedido_Pedidos_idPedido",
                        column: x => x.idPedido,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItensPedido_Produtos_idProduto",
                        column: x => x.idProduto,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Apelido",
                table: "Clientes",
                column: "Apelido",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_cpfCnpj",
                table: "Clientes",
                column: "cpfCnpj",
                unique: true,
                filter: "[cpfCnpj] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedores_cpfCnpj",
                table: "Fornecedores",
                column: "cpfCnpj",
                unique: true,
                filter: "[cpfCnpj] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedido_idPedido",
                table: "ItensPedido",
                column: "idPedido");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedido_idProduto",
                table: "ItensPedido",
                column: "idProduto");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_idCliente",
                table: "Pedidos",
                column: "idCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_IdFornecedor",
                table: "Produtos",
                column: "IdFornecedor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensPedido");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Fornecedores");
        }
    }
}
