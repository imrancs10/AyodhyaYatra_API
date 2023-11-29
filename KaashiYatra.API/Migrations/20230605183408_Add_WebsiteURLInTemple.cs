using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KaashiYatra.API.Migrations
{
    /// <inheritdoc />
    public partial class Add_WebsiteURLInTemple : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TempleWebsiteUrl",
                table: "Temples",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TempleWebsiteUrl",
                table: "Temples");
        }
    }
}
