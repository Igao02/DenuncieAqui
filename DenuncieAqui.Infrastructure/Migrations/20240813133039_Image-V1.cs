using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DenuncieAqui.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ImageV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Images");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Images",
                type: "nvarchar(350)",
                maxLength: 350,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "ImageDate",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageDate",
                table: "Images");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Images",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(350)",
                oldMaxLength: 350);

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Images",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
