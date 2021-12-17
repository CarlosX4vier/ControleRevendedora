using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleRevendedora.Migrations
{
    public partial class ALTER_TABLE_CODIGOBARRAS_TO_VARCHAR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CodigoBarras",
                table: "Produtos",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "CodigoBarras",
                table: "Produtos",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
