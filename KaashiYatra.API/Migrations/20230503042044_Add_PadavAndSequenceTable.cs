using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KaashiYatra.API.Migrations
{
    /// <inheritdoc />
    public partial class Add_PadavAndSequenceTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Temples_MasterDivisions_DivisionId",
                table: "Temples");

            migrationBuilder.RenameColumn(
                name: "DivisionId",
                table: "Temples",
                newName: "PadavId");

            migrationBuilder.RenameIndex(
                name: "IX_Temples_DivisionId",
                table: "Temples",
                newName: "IX_Temples_PadavId");

            migrationBuilder.AddColumn<int>(
                name: "SequenceId",
                table: "ImageStores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MasterPadavs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiName = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_MasterPadavs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasterSequenceNos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sequence = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_MasterSequenceNos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageStores_SequenceId",
                table: "ImageStores",
                column: "SequenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Temples_MasterPadavs_PadavId",
                table: "Temples",
                column: "PadavId",
                principalTable: "MasterPadavs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropForeignKey(
                name: "FK_Temples_MasterPadavs_PadavId",
                table: "Temples");

            migrationBuilder.DropTable(
                name: "MasterPadavs");

            migrationBuilder.DropTable(
                name: "MasterSequenceNos");

            migrationBuilder.DropIndex(
                name: "IX_ImageStores_SequenceId",
                table: "ImageStores");

            migrationBuilder.DropColumn(
                name: "SequenceId",
                table: "ImageStores");

            migrationBuilder.RenameColumn(
                name: "PadavId",
                table: "Temples",
                newName: "DivisionId");

            migrationBuilder.RenameIndex(
                name: "IX_Temples_PadavId",
                table: "Temples",
                newName: "IX_Temples_DivisionId");

            migrationBuilder.DropForeignKey(
                name: "FK_Temples_MasterDivisions_DivisionId",
                table: "Temples");
        }
    }
}
