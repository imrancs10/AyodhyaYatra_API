using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AyodhyaYatra.API.Migrations
{
    /// <inheritdoc />
    public partial class update_TempleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "YatraDetails");

            migrationBuilder.DropTable(
                name: "MasterSequenceNos");

            migrationBuilder.AddColumn<int>(
                name: "PadavId",
                table: "Temples",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SequenceNo",
                table: "Temples",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "YatraId",
                table: "Temples",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TempleSequences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TempleId = table.Column<int>(type: "int", nullable: false),
                    SequenceNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_TempleSequences", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Temples_PadavId",
                table: "Temples",
                column: "PadavId");

            migrationBuilder.CreateIndex(
                name: "IX_Temples_YatraId",
                table: "Temples",
                column: "YatraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Temples_MasterPadavs_PadavId",
                table: "Temples",
                column: "PadavId",
                principalTable: "MasterPadavs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Temples_MasterYatras_YatraId",
                table: "Temples",
                column: "YatraId",
                principalTable: "MasterYatras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Temples_MasterPadavs_PadavId",
                table: "Temples");

            migrationBuilder.DropForeignKey(
                name: "FK_Temples_MasterYatras_YatraId",
                table: "Temples");

            migrationBuilder.DropTable(
                name: "TempleSequences");

            migrationBuilder.DropIndex(
                name: "IX_Temples_PadavId",
                table: "Temples");

            migrationBuilder.DropIndex(
                name: "IX_Temples_YatraId",
                table: "Temples");

            migrationBuilder.DropColumn(
                name: "PadavId",
                table: "Temples");

            migrationBuilder.DropColumn(
                name: "SequenceNo",
                table: "Temples");

            migrationBuilder.DropColumn(
                name: "YatraId",
                table: "Temples");

            migrationBuilder.CreateTable(
                name: "MasterSequenceNos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Sequence = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterSequenceNos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "YatraDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PadavId = table.Column<int>(type: "int", nullable: false),
                    SequenceId = table.Column<int>(type: "int", nullable: false),
                    TempleId = table.Column<int>(type: "int", nullable: false),
                    YatraId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: false)
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
    }
}
