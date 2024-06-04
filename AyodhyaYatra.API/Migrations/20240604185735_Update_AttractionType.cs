using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AyodhyaYatra.API.Migrations
{
    /// <inheritdoc />
    public partial class Update_AttractionType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HiName",
                table: "MasterAttractionTypes",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TaName",
                table: "MasterAttractionTypes",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TeName",
                table: "MasterAttractionTypes",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HiName",
                table: "MasterAttractionTypes");

            migrationBuilder.DropColumn(
                name: "TaName",
                table: "MasterAttractionTypes");

            migrationBuilder.DropColumn(
                name: "TeName",
                table: "MasterAttractionTypes");
        }
    }
}
