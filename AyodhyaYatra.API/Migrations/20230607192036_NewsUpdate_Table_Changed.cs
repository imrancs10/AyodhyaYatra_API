using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AyodhyaYatra.API.Migrations
{
    /// <inheritdoc />
    public partial class NewsUpdate_Table_Changed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EnDescription",
                table: "NewsUpdates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EventDate",
                table: "NewsUpdates",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HiDescription",
                table: "NewsUpdates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnDescription",
                table: "NewsUpdates");

            migrationBuilder.DropColumn(
                name: "EventDate",
                table: "NewsUpdates");

            migrationBuilder.DropColumn(
                name: "HiDescription",
                table: "NewsUpdates");
        }
    }
}
