using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KaashiYatra.API.Migrations
{
    /// <inheritdoc />
    public partial class tamil_and_Telgu_Fields_Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TaName",
                table: "VideoGallery",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TeName",
                table: "VideoGallery",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TaName",
                table: "ThreeSixtyDegreeGallery",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TeName",
                table: "ThreeSixtyDegreeGallery",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TaDescription",
                table: "Temples",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TaName",
                table: "Temples",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TeDescription",
                table: "Temples",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TeName",
                table: "Temples",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TaName",
                table: "PhotoGallery",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TeName",
                table: "PhotoGallery",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TaName",
                table: "PhotoAlbum",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TeName",
                table: "PhotoAlbum",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TaDescription",
                table: "NewsUpdates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TaTitle",
                table: "NewsUpdates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TeDescription",
                table: "NewsUpdates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TeTitle",
                table: "NewsUpdates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TaDescription",
                table: "MasterYatras",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TaName",
                table: "MasterYatras",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TeDescription",
                table: "MasterYatras",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TeName",
                table: "MasterYatras",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TaDescription",
                table: "MasterPadavs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TaName",
                table: "MasterPadavs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TeDescription",
                table: "MasterPadavs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TeName",
                table: "MasterPadavs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TaDescription",
                table: "MasterDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaName",
                table: "MasterDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeDescription",
                table: "MasterDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeName",
                table: "MasterDatas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaName",
                table: "AudioGallery",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TeName",
                table: "AudioGallery",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaName",
                table: "VideoGallery");

            migrationBuilder.DropColumn(
                name: "TeName",
                table: "VideoGallery");

            migrationBuilder.DropColumn(
                name: "TaName",
                table: "ThreeSixtyDegreeGallery");

            migrationBuilder.DropColumn(
                name: "TeName",
                table: "ThreeSixtyDegreeGallery");

            migrationBuilder.DropColumn(
                name: "TaDescription",
                table: "Temples");

            migrationBuilder.DropColumn(
                name: "TaName",
                table: "Temples");

            migrationBuilder.DropColumn(
                name: "TeDescription",
                table: "Temples");

            migrationBuilder.DropColumn(
                name: "TeName",
                table: "Temples");

            migrationBuilder.DropColumn(
                name: "TaName",
                table: "PhotoGallery");

            migrationBuilder.DropColumn(
                name: "TeName",
                table: "PhotoGallery");

            migrationBuilder.DropColumn(
                name: "TaName",
                table: "PhotoAlbum");

            migrationBuilder.DropColumn(
                name: "TeName",
                table: "PhotoAlbum");

            migrationBuilder.DropColumn(
                name: "TaDescription",
                table: "NewsUpdates");

            migrationBuilder.DropColumn(
                name: "TaTitle",
                table: "NewsUpdates");

            migrationBuilder.DropColumn(
                name: "TeDescription",
                table: "NewsUpdates");

            migrationBuilder.DropColumn(
                name: "TeTitle",
                table: "NewsUpdates");

            migrationBuilder.DropColumn(
                name: "TaDescription",
                table: "MasterYatras");

            migrationBuilder.DropColumn(
                name: "TaName",
                table: "MasterYatras");

            migrationBuilder.DropColumn(
                name: "TeDescription",
                table: "MasterYatras");

            migrationBuilder.DropColumn(
                name: "TeName",
                table: "MasterYatras");

            migrationBuilder.DropColumn(
                name: "TaDescription",
                table: "MasterPadavs");

            migrationBuilder.DropColumn(
                name: "TaName",
                table: "MasterPadavs");

            migrationBuilder.DropColumn(
                name: "TeDescription",
                table: "MasterPadavs");

            migrationBuilder.DropColumn(
                name: "TeName",
                table: "MasterPadavs");

            migrationBuilder.DropColumn(
                name: "TaDescription",
                table: "MasterDatas");

            migrationBuilder.DropColumn(
                name: "TaName",
                table: "MasterDatas");

            migrationBuilder.DropColumn(
                name: "TeDescription",
                table: "MasterDatas");

            migrationBuilder.DropColumn(
                name: "TeName",
                table: "MasterDatas");

            migrationBuilder.DropColumn(
                name: "TaName",
                table: "AudioGallery");

            migrationBuilder.DropColumn(
                name: "TeName",
                table: "AudioGallery");
        }
    }
}
