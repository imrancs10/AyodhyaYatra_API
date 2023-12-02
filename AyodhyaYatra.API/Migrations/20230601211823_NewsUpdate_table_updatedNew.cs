using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AyodhyaYatra.API.Migrations
{
    /// <inheritdoc />
    public partial class NewsUpdate_table_updatedNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MasterDataType",
                table: "NewsUpdates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NewsUpdateId",
                table: "ImageStores",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImageStores_NewsUpdateId",
                table: "ImageStores",
                column: "NewsUpdateId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageStores_NewsUpdates_NewsUpdateId",
                table: "ImageStores",
                column: "NewsUpdateId",
                principalTable: "NewsUpdates",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageStores_NewsUpdates_NewsUpdateId",
                table: "ImageStores");

            migrationBuilder.DropIndex(
                name: "IX_ImageStores_NewsUpdateId",
                table: "ImageStores");

            migrationBuilder.DropColumn(
                name: "MasterDataType",
                table: "NewsUpdates");

            migrationBuilder.DropColumn(
                name: "NewsUpdateId",
                table: "ImageStores");
        }
    }
}
