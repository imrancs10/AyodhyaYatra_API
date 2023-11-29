using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KaashiYatra.API.Migrations
{
    /// <inheritdoc />
    public partial class Update_PadavTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnName",
                table: "MasterPadavs");

            migrationBuilder.RenameColumn(
                name: "HiName",
                table: "MasterPadavs",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "YatraId",
                table: "MasterPadavs",
                type: "int",
                nullable: true,
                defaultValue: null);

            migrationBuilder.CreateIndex(
                name: "IX_MasterPadavs_YatraId",
                table: "MasterPadavs",
                column: "YatraId");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterPadavs_MasterYatras_YatraId",
                table: "MasterPadavs",
                column: "YatraId",
                principalTable: "MasterYatras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterPadavs_MasterYatras_YatraId",
                table: "MasterPadavs");

            migrationBuilder.DropIndex(
                name: "IX_MasterPadavs_YatraId",
                table: "MasterPadavs");

            migrationBuilder.DropColumn(
                name: "YatraId",
                table: "MasterPadavs");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "MasterPadavs",
                newName: "HiName");

            migrationBuilder.AddColumn<string>(
                name: "EnName",
                table: "MasterPadavs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
