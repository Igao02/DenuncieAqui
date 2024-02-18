using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DenuncieAqui.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ThirdTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LivroExemplo",
                table: "LivroExemplo");

            migrationBuilder.RenameTable(
                name: "LivroExemplo",
                newName: "LivroExemplos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LivroExemplos",
                table: "LivroExemplos",
                column: "LivroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LivroExemplos",
                table: "LivroExemplos");

            migrationBuilder.RenameTable(
                name: "LivroExemplos",
                newName: "LivroExemplo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LivroExemplo",
                table: "LivroExemplo",
                column: "LivroId");
        }
    }
}
