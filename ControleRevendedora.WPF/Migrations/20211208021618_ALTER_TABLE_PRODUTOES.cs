using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleRevendedora.Migrations
{
    public partial class ALTER_TABLE_PRODUTOES : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KitProduto_Produtoes_KitProdutosId",
                table: "KitProduto");

            migrationBuilder.DropForeignKey(
                name: "FK_KitProduto_Produtoes_KitsId",
                table: "KitProduto");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtoes_Marcas_MarcaId",
                table: "Produtoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Produtoes_ProdutoID",
                table: "Transacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produtoes",
                table: "Produtoes");

            migrationBuilder.RenameTable(
                name: "Produtoes",
                newName: "Produtos");

            migrationBuilder.RenameIndex(
                name: "IX_Produtoes_MarcaId",
                table: "Produtos",
                newName: "IX_Produtos_MarcaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KitProduto_Produtos_KitProdutosId",
                table: "KitProduto",
                column: "KitProdutosId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KitProduto_Produtos_KitsId",
                table: "KitProduto",
                column: "KitsId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Marcas_MarcaId",
                table: "Produtos",
                column: "MarcaId",
                principalTable: "Marcas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_Produtos_ProdutoID",
                table: "Transacoes",
                column: "ProdutoID",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KitProduto_Produtos_KitProdutosId",
                table: "KitProduto");

            migrationBuilder.DropForeignKey(
                name: "FK_KitProduto_Produtos_KitsId",
                table: "KitProduto");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Marcas_MarcaId",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Produtos_ProdutoID",
                table: "Transacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos");

            migrationBuilder.RenameTable(
                name: "Produtos",
                newName: "Produtoes");

            migrationBuilder.RenameIndex(
                name: "IX_Produtos_MarcaId",
                table: "Produtoes",
                newName: "IX_Produtoes_MarcaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produtoes",
                table: "Produtoes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KitProduto_Produtoes_KitProdutosId",
                table: "KitProduto",
                column: "KitProdutosId",
                principalTable: "Produtoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KitProduto_Produtoes_KitsId",
                table: "KitProduto",
                column: "KitsId",
                principalTable: "Produtoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtoes_Marcas_MarcaId",
                table: "Produtoes",
                column: "MarcaId",
                principalTable: "Marcas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_Produtoes_ProdutoID",
                table: "Transacoes",
                column: "ProdutoID",
                principalTable: "Produtoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
