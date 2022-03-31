using Microsoft.EntityFrameworkCore.Migrations;

namespace Teste.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 256, nullable: false),
                    Telefone = table.Column<string>(maxLength: 20, nullable: false),
                    Endereco = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_Produto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 256, nullable: false),
                    Preco = table.Column<double>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Produto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_Compra",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Compra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Compra_TB_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "TB_Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_CompraItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCompra = table.Column<int>(nullable: false),
                    IdProduto = table.Column<int>(nullable: false),
                    Quantidade = table.Column<int>(maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CompraItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_CompraItem_TB_Compra_IdCompra",
                        column: x => x.IdCompra,
                        principalTable: "TB_Compra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_CompraItem_TB_Produto_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "TB_Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_Compra_ClienteId",
                table: "TB_Compra",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CompraItem_IdCompra",
                table: "TB_CompraItem",
                column: "IdCompra");

            migrationBuilder.CreateIndex(
                name: "IX_TB_CompraItem_IdProduto",
                table: "TB_CompraItem",
                column: "IdProduto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_CompraItem");

            migrationBuilder.DropTable(
                name: "TB_Compra");

            migrationBuilder.DropTable(
                name: "TB_Produto");

            migrationBuilder.DropTable(
                name: "TB_Cliente");
        }
    }
}
