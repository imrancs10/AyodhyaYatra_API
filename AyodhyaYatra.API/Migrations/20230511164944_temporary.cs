using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AyodhyaYatra.API.Migrations
{
    /// <inheritdoc />
    public partial class temporary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "MasterYatras",
                newName: "HiName");

            migrationBuilder.AddColumn<string>(
                name: "EnName",
                table: "MasterYatras",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnName",
                table: "MasterYatras");

            migrationBuilder.RenameColumn(
                name: "HiName",
                table: "MasterYatras",
                newName: "Name");
        }
    }
}
