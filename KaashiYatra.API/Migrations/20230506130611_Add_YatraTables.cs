using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KaashiYatra.API.Migrations
{
    /// <inheritdoc />
    public partial class Add_YatraTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Temples_MasterPadavs_PadavId",
                table: "Temples");

            migrationBuilder.DropIndex(
                name: "IX_Temples_PadavId",
                table: "Temples");

            migrationBuilder.DropColumn(
                name: "PadavId",
                table: "Temples");

            migrationBuilder.DropColumn(
                name: "SequenceId",
                table: "ImageStores");

            migrationBuilder.AddColumn<bool>(
                name: "Verified",
                table: "Temples",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Verified",
                table: "ImageStores",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "MasterYatras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterYatras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "YatraDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YatraId = table.Column<int>(type: "int", nullable: false),
                    PadavId = table.Column<int>(type: "int", nullable: false),
                    SequenceId = table.Column<int>(type: "int", nullable: false),
                    TempleId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false),
                    DeletedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YatraDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YatraDetails_MasterPadavs_PadavId",
                        column: x => x.PadavId,
                        principalTable: "MasterPadavs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_YatraDetails_MasterSequenceNos_SequenceId",
                        column: x => x.SequenceId,
                        principalTable: "MasterSequenceNos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_YatraDetails_MasterYatras_YatraId",
                        column: x => x.YatraId,
                        principalTable: "MasterYatras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_YatraDetails_Temples_TempleId",
                        column: x => x.TempleId,
                        principalTable: "Temples",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_YatraDetails_PadavId",
                table: "YatraDetails",
                column: "PadavId");

            migrationBuilder.CreateIndex(
                name: "IX_YatraDetails_SequenceId",
                table: "YatraDetails",
                column: "SequenceId");

            migrationBuilder.CreateIndex(
                name: "IX_YatraDetails_TempleId",
                table: "YatraDetails",
                column: "TempleId");

            migrationBuilder.CreateIndex(
                name: "IX_YatraDetails_YatraId",
                table: "YatraDetails",
                column: "YatraId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "YatraDetails");

            migrationBuilder.DropTable(
                name: "MasterYatras");

            migrationBuilder.DropColumn(
                name: "Verified",
                table: "Temples");

            migrationBuilder.DropColumn(
                name: "Verified",
                table: "ImageStores");

            migrationBuilder.AddColumn<int>(
                name: "PadavId",
                table: "Temples",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SequenceId",
                table: "ImageStores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Temples_PadavId",
                table: "Temples",
                column: "PadavId");

            migrationBuilder.AddForeignKey(
                name: "FK_Temples_MasterPadavs_PadavId",
                table: "Temples",
                column: "PadavId",
                principalTable: "MasterPadavs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
