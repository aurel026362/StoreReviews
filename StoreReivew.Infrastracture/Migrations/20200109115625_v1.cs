using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreReivew.Infrastracture.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyPhotos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(nullable: true),
                    CompanyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyPhotos_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adress = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    CompanyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shops_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    RoleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShopPhotos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(nullable: true),
                    ShopId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopPhotos_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyReview",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Ratting = table.Column<float>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    CompanyId = table.Column<long>(nullable: false),
                    CompanyReviewId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyReview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyReview_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyReview_CompanyReview_CompanyReviewId",
                        column: x => x.CompanyReviewId,
                        principalTable: "CompanyReview",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CompanyReview_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShopReview",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Ratting = table.Column<float>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    ShopId = table.Column<long>(nullable: false),
                    ShopReviewId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopReview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopReview_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopReview_ShopReview_ShopReviewId",
                        column: x => x.ShopReviewId,
                        principalTable: "ShopReview",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShopReview_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyReviewPhotos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(nullable: true),
                    CompanyReviewId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyReviewPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyReviewPhotos_CompanyReview_CompanyReviewId",
                        column: x => x.CompanyReviewId,
                        principalTable: "CompanyReview",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShopReviewPhotos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(nullable: true),
                    ShopReviewId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopReviewPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopReviewPhotos_ShopReview_ShopReviewId",
                        column: x => x.ShopReviewId,
                        principalTable: "ShopReview",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyPhotos_CompanyId",
                table: "CompanyPhotos",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyReview_CompanyId",
                table: "CompanyReview",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyReview_CompanyReviewId",
                table: "CompanyReview",
                column: "CompanyReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyReview_UserId",
                table: "CompanyReview",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyReviewPhotos_CompanyReviewId",
                table: "CompanyReviewPhotos",
                column: "CompanyReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopPhotos_ShopId",
                table: "ShopPhotos",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopReview_ShopId",
                table: "ShopReview",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopReview_ShopReviewId",
                table: "ShopReview",
                column: "ShopReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopReview_UserId",
                table: "ShopReview",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopReviewPhotos_ShopReviewId",
                table: "ShopReviewPhotos",
                column: "ShopReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_CompanyId",
                table: "Shops",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyPhotos");

            migrationBuilder.DropTable(
                name: "CompanyReviewPhotos");

            migrationBuilder.DropTable(
                name: "ShopPhotos");

            migrationBuilder.DropTable(
                name: "ShopReviewPhotos");

            migrationBuilder.DropTable(
                name: "CompanyReview");

            migrationBuilder.DropTable(
                name: "ShopReview");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
