using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DenuncieAqui.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedInstitution : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Institutions",
                newName: "Street");

            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "Institutions",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NumHome",
                table: "Institutions",
                type: "int",
                maxLength: 5,
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cep",
                table: "Institutions");

            migrationBuilder.DropColumn(
                name: "NumHome",
                table: "Institutions");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Institutions",
                newName: "Address");
        }
    }
}
