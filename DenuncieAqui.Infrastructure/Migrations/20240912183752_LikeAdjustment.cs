using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DenuncieAqui.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LikeAdjustment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Likes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Likes");
        }
    }
}
