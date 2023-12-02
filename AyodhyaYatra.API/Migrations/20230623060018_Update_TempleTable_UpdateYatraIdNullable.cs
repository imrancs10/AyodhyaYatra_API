﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AyodhyaYatra.API.Migrations
{
    /// <inheritdoc />
    public partial class Update_TempleTable_UpdateYatraIdNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Temples_MasterYatras_YatraId",
                table: "Temples");

            migrationBuilder.AlterColumn<int>(
                name: "YatraId",
                table: "Temples",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "SequenceNo",
                table: "Temples",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Temples_MasterYatras_YatraId",
                table: "Temples",
                column: "YatraId",
                principalTable: "MasterYatras",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Temples_MasterYatras_YatraId",
                table: "Temples");

            migrationBuilder.AlterColumn<int>(
                name: "YatraId",
                table: "Temples",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SequenceNo",
                table: "Temples",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Temples_MasterYatras_YatraId",
                table: "Temples",
                column: "YatraId",
                principalTable: "MasterYatras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
