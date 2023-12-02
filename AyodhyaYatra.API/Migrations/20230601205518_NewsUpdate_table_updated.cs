using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AyodhyaYatra.API.Migrations
{
    /// <inheritdoc />
    public partial class NewsUpdate_table_updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "NewsUpdates",
                newName: "HiTitle");

            migrationBuilder.AddColumn<string>(
                name: "EnTitle",
                table: "NewsUpdates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnTitle",
                table: "NewsUpdates");

            migrationBuilder.RenameColumn(
                name: "HiTitle",
                table: "NewsUpdates",
                newName: "Title");
        }
    }
}
