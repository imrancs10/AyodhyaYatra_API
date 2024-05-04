using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AyodhyaYatra.API.Migrations
{
    /// <inheritdoc />
    public partial class TableInitials : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AudioGallery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_AudioGallery", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FeedbackComment = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasterAttractionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_MasterAttractionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasterDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterDataType = table.Column<int>(type: "int", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    VideoURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_MasterDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasterYatras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HiName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
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
                name: "NewsUpdates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterDataType = table.Column<int>(type: "int", nullable: false),
                    NewsUpdateType = table.Column<int>(type: "int", nullable: false),
                    EnDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_NewsUpdates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhotoAlbum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_PhotoAlbum", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThreeSixtyDegreeGallery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_ThreeSixtyDegreeGallery", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEmailVerified = table.Column<bool>(type: "bit", nullable: false),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false),
                    IsBlocked = table.Column<bool>(type: "bit", nullable: false),
                    IsTcAccepted = table.Column<bool>(type: "bit", nullable: false),
                    IsResetCodeInitiated = table.Column<bool>(type: "bit", nullable: false),
                    PasswordResetCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordResetCodeExpireOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmailVerificationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailVerificationCodeExpireOn = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VideoGallery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_VideoGallery", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasterAttractions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SequenceNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttractionTypeId = table.Column<int>(type: "int", nullable: false),
                    EnName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HiName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HiDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Video360URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Verified = table.Column<bool>(type: "bit", nullable: false),
                    AttractionURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BarcodeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_MasterAttractions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterAttractions_MasterAttractionTypes_AttractionTypeId",
                        column: x => x.AttractionTypeId,
                        principalTable: "MasterAttractionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhotoGallery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoAlbumId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_PhotoGallery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhotoGallery_PhotoAlbum_PhotoAlbumId",
                        column: x => x.PhotoAlbumId,
                        principalTable: "PhotoAlbum",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "YatraAttractionMappers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterAttractionId = table.Column<int>(type: "int", nullable: false),
                    YatraId = table.Column<int>(type: "int", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_YatraAttractionMappers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YatraAttractionMappers_MasterAttractions_MasterAttractionId",
                        column: x => x.MasterAttractionId,
                        principalTable: "MasterAttractions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_YatraAttractionMappers_MasterYatras_YatraId",
                        column: x => x.YatraId,
                        principalTable: "MasterYatras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageStores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThumbPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModuleId = table.Column<int>(type: "int", nullable: false),
                    ModuleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Verified = table.Column<bool>(type: "bit", nullable: false),
                    AudioGalleryId = table.Column<int>(type: "int", nullable: true),
                    MasterAttractionId = table.Column<int>(type: "int", nullable: true),
                    MasterDataId = table.Column<int>(type: "int", nullable: true),
                    NewsUpdateId = table.Column<int>(type: "int", nullable: true),
                    PhotoAlbumId = table.Column<int>(type: "int", nullable: true),
                    PhotoGalleryId = table.Column<int>(type: "int", nullable: true),
                    ThreeSixtyDegreeGalleryId = table.Column<int>(type: "int", nullable: true),
                    VideoGalleryId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_ImageStores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageStores_AudioGallery_AudioGalleryId",
                        column: x => x.AudioGalleryId,
                        principalTable: "AudioGallery",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ImageStores_MasterAttractions_MasterAttractionId",
                        column: x => x.MasterAttractionId,
                        principalTable: "MasterAttractions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ImageStores_MasterDatas_MasterDataId",
                        column: x => x.MasterDataId,
                        principalTable: "MasterDatas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ImageStores_NewsUpdates_NewsUpdateId",
                        column: x => x.NewsUpdateId,
                        principalTable: "NewsUpdates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ImageStores_PhotoAlbum_PhotoAlbumId",
                        column: x => x.PhotoAlbumId,
                        principalTable: "PhotoAlbum",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ImageStores_PhotoGallery_PhotoGalleryId",
                        column: x => x.PhotoGalleryId,
                        principalTable: "PhotoGallery",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ImageStores_ThreeSixtyDegreeGallery_ThreeSixtyDegreeGalleryId",
                        column: x => x.ThreeSixtyDegreeGalleryId,
                        principalTable: "ThreeSixtyDegreeGallery",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ImageStores_VideoGallery_VideoGalleryId",
                        column: x => x.VideoGalleryId,
                        principalTable: "VideoGallery",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageStores_AudioGalleryId",
                table: "ImageStores",
                column: "AudioGalleryId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageStores_MasterAttractionId",
                table: "ImageStores",
                column: "MasterAttractionId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageStores_MasterDataId",
                table: "ImageStores",
                column: "MasterDataId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageStores_NewsUpdateId",
                table: "ImageStores",
                column: "NewsUpdateId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageStores_PhotoAlbumId",
                table: "ImageStores",
                column: "PhotoAlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageStores_PhotoGalleryId",
                table: "ImageStores",
                column: "PhotoGalleryId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageStores_ThreeSixtyDegreeGalleryId",
                table: "ImageStores",
                column: "ThreeSixtyDegreeGalleryId");

            migrationBuilder.CreateIndex(
                name: "IX_ImageStores_VideoGalleryId",
                table: "ImageStores",
                column: "VideoGalleryId");

            migrationBuilder.CreateIndex(
                name: "IX_MasterAttractions_AttractionTypeId",
                table: "MasterAttractions",
                column: "AttractionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoGallery_PhotoAlbumId",
                table: "PhotoGallery",
                column: "PhotoAlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_YatraAttractionMappers_MasterAttractionId",
                table: "YatraAttractionMappers",
                column: "MasterAttractionId");

            migrationBuilder.CreateIndex(
                name: "IX_YatraAttractionMappers_YatraId",
                table: "YatraAttractionMappers",
                column: "YatraId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "ImageStores");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "YatraAttractionMappers");

            migrationBuilder.DropTable(
                name: "AudioGallery");

            migrationBuilder.DropTable(
                name: "MasterDatas");

            migrationBuilder.DropTable(
                name: "NewsUpdates");

            migrationBuilder.DropTable(
                name: "PhotoGallery");

            migrationBuilder.DropTable(
                name: "ThreeSixtyDegreeGallery");

            migrationBuilder.DropTable(
                name: "VideoGallery");

            migrationBuilder.DropTable(
                name: "MasterAttractions");

            migrationBuilder.DropTable(
                name: "MasterYatras");

            migrationBuilder.DropTable(
                name: "PhotoAlbum");

            migrationBuilder.DropTable(
                name: "MasterAttractionTypes");
        }
    }
}
