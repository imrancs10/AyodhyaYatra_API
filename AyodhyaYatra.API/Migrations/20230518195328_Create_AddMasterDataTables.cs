using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AyodhyaYatra.API.Migrations
{
    /// <inheritdoc />
    public partial class Create_AddMasterDataTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MasterATMId",
                table: "ImageStores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MasterBusinessId",
                table: "ImageStores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MasterCaltureId",
                table: "ImageStores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MasterEducationalInstituteId",
                table: "ImageStores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MasterEntertainmentId",
                table: "ImageStores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MasterGangaAartiId",
                table: "ImageStores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MasterGhatId",
                table: "ImageStores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MasterHeritageId",
                table: "ImageStores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MasterHospitalId",
                table: "ImageStores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MasterHotelId",
                table: "ImageStores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MasterIndustriesId",
                table: "ImageStores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MasterMuseumId",
                table: "ImageStores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MasterParkId",
                table: "ImageStores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MasterRailwayId",
                table: "ImageStores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MasterRestaurantId",
                table: "ImageStores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MasterShoppingPlaceId",
                table: "ImageStores",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MasterTransportId",
                table: "ImageStores",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MasterATMs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_MasterATMs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasterBusinesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_MasterBusinesses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasterCaltures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_MasterCaltures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasterEducationalInstitutes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_MasterEducationalInstitutes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasterEntertainments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_MasterEntertainments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasterGangaAartis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_MasterGangaAartis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasterGhats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_MasterGhats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasterHeritages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_MasterHeritages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasterHospitals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_MasterHospitals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasterHotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_MasterHotels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasterIndustries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_MasterIndustries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasterMuseums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_MasterMuseums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasterParks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_MasterParks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasterRailways",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_MasterRailways", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasterRestaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_MasterRestaurants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasterShoppingPlaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_MasterShoppingPlaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasterTransports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_MasterTransports", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageStores_MasterATMId",
                table: "ImageStores",
                column: "MasterATMId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageStores_MasterBusinessId",
                table: "ImageStores",
                column: "MasterBusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageStores_MasterCaltureId",
                table: "ImageStores",
                column: "MasterCaltureId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageStores_MasterEducationalInstituteId",
                table: "ImageStores",
                column: "MasterEducationalInstituteId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageStores_MasterEntertainmentId",
                table: "ImageStores",
                column: "MasterEntertainmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageStores_MasterGangaAartiId",
                table: "ImageStores",
                column: "MasterGangaAartiId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageStores_MasterGhatId",
                table: "ImageStores",
                column: "MasterGhatId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageStores_MasterHeritageId",
                table: "ImageStores",
                column: "MasterHeritageId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageStores_MasterHospitalId",
                table: "ImageStores",
                column: "MasterHospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageStores_MasterHotelId",
                table: "ImageStores",
                column: "MasterHotelId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageStores_MasterIndustriesId",
                table: "ImageStores",
                column: "MasterIndustriesId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageStores_MasterMuseumId",
                table: "ImageStores",
                column: "MasterMuseumId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageStores_MasterParkId",
                table: "ImageStores",
                column: "MasterParkId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageStores_MasterRailwayId",
                table: "ImageStores",
                column: "MasterRailwayId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageStores_MasterRestaurantId",
                table: "ImageStores",
                column: "MasterRestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageStores_MasterShoppingPlaceId",
                table: "ImageStores",
                column: "MasterShoppingPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageStores_MasterTransportId",
                table: "ImageStores",
                column: "MasterTransportId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageStores_MasterATMs_MasterATMId",
                table: "ImageStores",
                column: "MasterATMId",
                principalTable: "MasterATMs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageStores_MasterBusinesses_MasterBusinessId",
                table: "ImageStores",
                column: "MasterBusinessId",
                principalTable: "MasterBusinesses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageStores_MasterCaltures_MasterCaltureId",
                table: "ImageStores",
                column: "MasterCaltureId",
                principalTable: "MasterCaltures",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageStores_MasterEducationalInstitutes_MasterEducationalInstituteId",
                table: "ImageStores",
                column: "MasterEducationalInstituteId",
                principalTable: "MasterEducationalInstitutes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageStores_MasterEntertainments_MasterEntertainmentId",
                table: "ImageStores",
                column: "MasterEntertainmentId",
                principalTable: "MasterEntertainments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageStores_MasterGangaAartis_MasterGangaAartiId",
                table: "ImageStores",
                column: "MasterGangaAartiId",
                principalTable: "MasterGangaAartis",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageStores_MasterGhats_MasterGhatId",
                table: "ImageStores",
                column: "MasterGhatId",
                principalTable: "MasterGhats",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageStores_MasterHeritages_MasterHeritageId",
                table: "ImageStores",
                column: "MasterHeritageId",
                principalTable: "MasterHeritages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageStores_MasterHospitals_MasterHospitalId",
                table: "ImageStores",
                column: "MasterHospitalId",
                principalTable: "MasterHospitals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageStores_MasterHotels_MasterHotelId",
                table: "ImageStores",
                column: "MasterHotelId",
                principalTable: "MasterHotels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageStores_MasterIndustries_MasterIndustriesId",
                table: "ImageStores",
                column: "MasterIndustriesId",
                principalTable: "MasterIndustries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageStores_MasterMuseums_MasterMuseumId",
                table: "ImageStores",
                column: "MasterMuseumId",
                principalTable: "MasterMuseums",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageStores_MasterParks_MasterParkId",
                table: "ImageStores",
                column: "MasterParkId",
                principalTable: "MasterParks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageStores_MasterRailways_MasterRailwayId",
                table: "ImageStores",
                column: "MasterRailwayId",
                principalTable: "MasterRailways",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageStores_MasterRestaurants_MasterRestaurantId",
                table: "ImageStores",
                column: "MasterRestaurantId",
                principalTable: "MasterRestaurants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageStores_MasterShoppingPlaces_MasterShoppingPlaceId",
                table: "ImageStores",
                column: "MasterShoppingPlaceId",
                principalTable: "MasterShoppingPlaces",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageStores_MasterTransports_MasterTransportId",
                table: "ImageStores",
                column: "MasterTransportId",
                principalTable: "MasterTransports",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageStores_MasterATMs_MasterATMId",
                table: "ImageStores");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageStores_MasterBusinesses_MasterBusinessId",
                table: "ImageStores");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageStores_MasterCaltures_MasterCaltureId",
                table: "ImageStores");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageStores_MasterEducationalInstitutes_MasterEducationalInstituteId",
                table: "ImageStores");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageStores_MasterEntertainments_MasterEntertainmentId",
                table: "ImageStores");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageStores_MasterGangaAartis_MasterGangaAartiId",
                table: "ImageStores");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageStores_MasterGhats_MasterGhatId",
                table: "ImageStores");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageStores_MasterHeritages_MasterHeritageId",
                table: "ImageStores");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageStores_MasterHospitals_MasterHospitalId",
                table: "ImageStores");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageStores_MasterHotels_MasterHotelId",
                table: "ImageStores");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageStores_MasterIndustries_MasterIndustriesId",
                table: "ImageStores");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageStores_MasterMuseums_MasterMuseumId",
                table: "ImageStores");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageStores_MasterParks_MasterParkId",
                table: "ImageStores");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageStores_MasterRailways_MasterRailwayId",
                table: "ImageStores");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageStores_MasterRestaurants_MasterRestaurantId",
                table: "ImageStores");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageStores_MasterShoppingPlaces_MasterShoppingPlaceId",
                table: "ImageStores");

            migrationBuilder.DropForeignKey(
                name: "FK_ImageStores_MasterTransports_MasterTransportId",
                table: "ImageStores");

            migrationBuilder.DropTable(
                name: "MasterATMs");

            migrationBuilder.DropTable(
                name: "MasterBusinesses");

            migrationBuilder.DropTable(
                name: "MasterCaltures");

            migrationBuilder.DropTable(
                name: "MasterEducationalInstitutes");

            migrationBuilder.DropTable(
                name: "MasterEntertainments");

            migrationBuilder.DropTable(
                name: "MasterGangaAartis");

            migrationBuilder.DropTable(
                name: "MasterGhats");

            migrationBuilder.DropTable(
                name: "MasterHeritages");

            migrationBuilder.DropTable(
                name: "MasterHospitals");

            migrationBuilder.DropTable(
                name: "MasterHotels");

            migrationBuilder.DropTable(
                name: "MasterIndustries");

            migrationBuilder.DropTable(
                name: "MasterMuseums");

            migrationBuilder.DropTable(
                name: "MasterParks");

            migrationBuilder.DropTable(
                name: "MasterRailways");

            migrationBuilder.DropTable(
                name: "MasterRestaurants");

            migrationBuilder.DropTable(
                name: "MasterShoppingPlaces");

            migrationBuilder.DropTable(
                name: "MasterTransports");

            migrationBuilder.DropIndex(
                name: "IX_ImageStores_MasterATMId",
                table: "ImageStores");

            migrationBuilder.DropIndex(
                name: "IX_ImageStores_MasterBusinessId",
                table: "ImageStores");

            migrationBuilder.DropIndex(
                name: "IX_ImageStores_MasterCaltureId",
                table: "ImageStores");

            migrationBuilder.DropIndex(
                name: "IX_ImageStores_MasterEducationalInstituteId",
                table: "ImageStores");

            migrationBuilder.DropIndex(
                name: "IX_ImageStores_MasterEntertainmentId",
                table: "ImageStores");

            migrationBuilder.DropIndex(
                name: "IX_ImageStores_MasterGangaAartiId",
                table: "ImageStores");

            migrationBuilder.DropIndex(
                name: "IX_ImageStores_MasterGhatId",
                table: "ImageStores");

            migrationBuilder.DropIndex(
                name: "IX_ImageStores_MasterHeritageId",
                table: "ImageStores");

            migrationBuilder.DropIndex(
                name: "IX_ImageStores_MasterHospitalId",
                table: "ImageStores");

            migrationBuilder.DropIndex(
                name: "IX_ImageStores_MasterHotelId",
                table: "ImageStores");

            migrationBuilder.DropIndex(
                name: "IX_ImageStores_MasterIndustriesId",
                table: "ImageStores");

            migrationBuilder.DropIndex(
                name: "IX_ImageStores_MasterMuseumId",
                table: "ImageStores");

            migrationBuilder.DropIndex(
                name: "IX_ImageStores_MasterParkId",
                table: "ImageStores");

            migrationBuilder.DropIndex(
                name: "IX_ImageStores_MasterRailwayId",
                table: "ImageStores");

            migrationBuilder.DropIndex(
                name: "IX_ImageStores_MasterRestaurantId",
                table: "ImageStores");

            migrationBuilder.DropIndex(
                name: "IX_ImageStores_MasterShoppingPlaceId",
                table: "ImageStores");

            migrationBuilder.DropIndex(
                name: "IX_ImageStores_MasterTransportId",
                table: "ImageStores");

            migrationBuilder.DropColumn(
                name: "EnName",
                table: "MasterYatras");

            migrationBuilder.DropColumn(
                name: "MasterATMId",
                table: "ImageStores");

            migrationBuilder.DropColumn(
                name: "MasterBusinessId",
                table: "ImageStores");

            migrationBuilder.DropColumn(
                name: "MasterCaltureId",
                table: "ImageStores");

            migrationBuilder.DropColumn(
                name: "MasterEducationalInstituteId",
                table: "ImageStores");

            migrationBuilder.DropColumn(
                name: "MasterEntertainmentId",
                table: "ImageStores");

            migrationBuilder.DropColumn(
                name: "MasterGangaAartiId",
                table: "ImageStores");

            migrationBuilder.DropColumn(
                name: "MasterGhatId",
                table: "ImageStores");

            migrationBuilder.DropColumn(
                name: "MasterHeritageId",
                table: "ImageStores");

            migrationBuilder.DropColumn(
                name: "MasterHospitalId",
                table: "ImageStores");

            migrationBuilder.DropColumn(
                name: "MasterHotelId",
                table: "ImageStores");

            migrationBuilder.DropColumn(
                name: "MasterIndustriesId",
                table: "ImageStores");

            migrationBuilder.DropColumn(
                name: "MasterMuseumId",
                table: "ImageStores");

            migrationBuilder.DropColumn(
                name: "MasterParkId",
                table: "ImageStores");

            migrationBuilder.DropColumn(
                name: "MasterRailwayId",
                table: "ImageStores");

            migrationBuilder.DropColumn(
                name: "MasterRestaurantId",
                table: "ImageStores");

            migrationBuilder.DropColumn(
                name: "MasterShoppingPlaceId",
                table: "ImageStores");

            migrationBuilder.DropColumn(
                name: "MasterTransportId",
                table: "ImageStores");

            migrationBuilder.RenameColumn(
                name: "HiName",
                table: "MasterYatras",
                newName: "Name");
        }
    }
}
