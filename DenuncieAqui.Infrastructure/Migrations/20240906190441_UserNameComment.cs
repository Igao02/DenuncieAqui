﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DenuncieAqui.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserNameComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Comments");
        }
    }
}
