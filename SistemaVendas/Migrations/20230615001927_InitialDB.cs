using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaVendas.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Distribuidoras",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_distribuidora = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cnpj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distribuidoras", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_marca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cnpj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeusuario = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    role = table.Column<int>(type: "int", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_cliente = table.Column<int>(type: "int", nullable: false),
                    data_venda = table.Column<DateTime>(type: "datetime2", nullable: false),
                    precototal_venda = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    metodo_pagamento = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Vendas_Clientes_id_cliente",
                        column: x => x.id_cliente,
                        principalTable: "Clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NFes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_distribuidora = table.Column<int>(type: "int", nullable: false),
                    num_nfe = table.Column<int>(type: "int", nullable: false),
                    total_icms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    total_ipi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    total_pis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    total_cofins = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    total_iss = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    valortotal_nfe = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NFes", x => x.id);
                    table.ForeignKey(
                        name: "FK_NFes_Distribuidoras_id_distribuidora",
                        column: x => x.id_distribuidora,
                        principalTable: "Distribuidoras",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_marca = table.Column<int>(type: "int", nullable: false),
                    cod_barras = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    nome_produto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    preco_venda = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Produtos_Marcas_id_marca",
                        column: x => x.id_marca,
                        principalTable: "Marcas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItensNFes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_produto = table.Column<int>(type: "int", nullable: false),
                    id_nfe = table.Column<int>(type: "int", nullable: false),
                    quantidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    valor_unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    valor_total_produto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    icms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ipi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cofins = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    iss = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    total_icms_produto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    total_ipi_produto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    total_pis_produto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    total_cofins_produto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    total_iss_produto = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensNFes", x => x.id);
                    table.ForeignKey(
                        name: "FK_ItensNFes_NFes_id_nfe",
                        column: x => x.id_nfe,
                        principalTable: "NFes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItensNFes_Produtos_id_produto",
                        column: x => x.id_produto,
                        principalTable: "Produtos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoVendas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_produto = table.Column<int>(type: "int", nullable: false),
                    id_venda = table.Column<int>(type: "int", nullable: false),
                    quantidade = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoVendas", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProdutoVendas_Produtos_id_produto",
                        column: x => x.id_produto,
                        principalTable: "Produtos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdutoVendas_Vendas_id_venda",
                        column: x => x.id_venda,
                        principalTable: "Vendas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItensNFes_id_nfe",
                table: "ItensNFes",
                column: "id_nfe");

            migrationBuilder.CreateIndex(
                name: "IX_ItensNFes_id_produto",
                table: "ItensNFes",
                column: "id_produto");

            migrationBuilder.CreateIndex(
                name: "IX_NFes_id_distribuidora",
                table: "NFes",
                column: "id_distribuidora");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_id_marca",
                table: "Produtos",
                column: "id_marca");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoVendas_id_produto",
                table: "ProdutoVendas",
                column: "id_produto");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoVendas_id_venda",
                table: "ProdutoVendas",
                column: "id_venda");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_id_cliente",
                table: "Vendas",
                column: "id_cliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensNFes");

            migrationBuilder.DropTable(
                name: "ProdutoVendas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "NFes");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "Distribuidoras");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
