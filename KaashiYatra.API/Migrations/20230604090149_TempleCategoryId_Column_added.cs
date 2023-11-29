using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KaashiYatra.API.Migrations
{
    /// <inheritdoc />
    public partial class TempleCategoryId_Column_added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TempleCategoryId",
                table: "Temples",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TempleCategoryId",
                table: "Temples");
        }
    }
}
