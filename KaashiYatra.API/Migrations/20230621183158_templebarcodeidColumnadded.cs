using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KaashiYatra.API.Migrations
{
    /// <inheritdoc />
    public partial class templebarcodeidColumnadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TempleBarcodeId",
                table: "Temples",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TempleBarcodeId",
                table: "Temples");
        }
    }
}
