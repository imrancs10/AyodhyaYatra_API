using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AyodhyaYatra.API.Migrations
{
    /// <inheritdoc />
    public partial class Add_ParentYatraId_MasterYatra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentYatraId",
                table: "MasterYatras",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MasterYatras_ParentYatraId",
                table: "MasterYatras",
                column: "ParentYatraId");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterYatras_MasterYatras_ParentYatraId",
                table: "MasterYatras",
                column: "ParentYatraId",
                principalTable: "MasterYatras",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterYatras_MasterYatras_ParentYatraId",
                table: "MasterYatras");

            migrationBuilder.DropIndex(
                name: "IX_MasterYatras_ParentYatraId",
                table: "MasterYatras");

            migrationBuilder.DropColumn(
                name: "ParentYatraId",
                table: "MasterYatras");
        }
    }
}
