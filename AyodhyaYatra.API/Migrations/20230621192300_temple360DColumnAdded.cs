using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AyodhyaYatra.API.Migrations
{
    /// <inheritdoc />
    public partial class temple360DColumnAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TempleWebsiteUrl",
                table: "Temples",
                newName: "Temple360DegreeVideoURL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Temple360DegreeVideoURL",
                table: "Temples",
                newName: "TempleWebsiteUrl");
        }
    }
}
