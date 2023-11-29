using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KaashiYatra.API.Migrations
{
    /// <inheritdoc />
    public partial class master_yatra_and_Padav_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "MasterPadavs",
                newName: "HiName");

            //migrationBuilder.RenameColumn(
            //    name: "MasterDataId",
            //    table: "MasterDatas",
            //    newName: "MasterDataType");

            migrationBuilder.AddColumn<string>(
                name: "EnDescription",
                table: "MasterYatras",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HiDescription",
                table: "MasterYatras",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EnDescription",
                table: "MasterPadavs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EnName",
                table: "MasterPadavs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HiDescription",
                table: "MasterPadavs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MasterPadavId",
                table: "ImageStores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MasterYatraId",
                table: "ImageStores",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImageStores_MasterPadavId",
                table: "ImageStores",
                column: "MasterPadavId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageStores_MasterYatraId",
                table: "ImageStores",
                column: "MasterYatraId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageStores_MasterPadavs_MasterPadavId",
                table: "ImageStores",
                column: "MasterPadavId",
                principalTable: "MasterPadavs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageStores_MasterYatras_MasterYatraId",
                table: "ImageStores",
                column: "MasterYatraId",
                principalTable: "MasterYatras",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageStores_MasterPadavs_MasterPadavId",
                table: "ImageStores");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageStores_MasterYatras_MasterYatraId",
                table: "ImageStores");

            migrationBuilder.DropIndex(
                name: "IX_ImageStores_MasterPadavId",
                table: "ImageStores");

            migrationBuilder.DropIndex(
                name: "IX_ImageStores_MasterYatraId",
                table: "ImageStores");

            migrationBuilder.DropColumn(
                name: "EnDescription",
                table: "MasterYatras");

            migrationBuilder.DropColumn(
                name: "HiDescription",
                table: "MasterYatras");

            migrationBuilder.DropColumn(
                name: "EnDescription",
                table: "MasterPadavs");

            migrationBuilder.DropColumn(
                name: "EnName",
                table: "MasterPadavs");

            migrationBuilder.DropColumn(
                name: "HiDescription",
                table: "MasterPadavs");

            migrationBuilder.DropColumn(
                name: "MasterPadavId",
                table: "ImageStores");

            migrationBuilder.DropColumn(
                name: "MasterYatraId",
                table: "ImageStores");

            migrationBuilder.RenameColumn(
                name: "HiName",
                table: "MasterPadavs",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "MasterDataType",
                table: "MasterDatas",
                newName: "MasterDataId");
        }
    }
}
