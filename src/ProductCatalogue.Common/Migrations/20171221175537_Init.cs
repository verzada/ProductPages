using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ProductPages.Common.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductPageTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TypeOfProduct = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPageTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductPages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MaintainerOfProduct = table.Column<string>(nullable: true),
                    NameOfProduct = table.Column<string>(nullable: true),
                    OctopusDeployProjectUrl = table.Column<string>(nullable: true),
                    SystemDocumentationUrl = table.Column<string>(nullable: true),
                    TeamCityProjectUrl = table.Column<string>(nullable: true),
                    TypeOfProductId = table.Column<int>(nullable: true),
                    Updated = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPages_ProductPageTypes_TypeOfProductId",
                        column: x => x.TypeOfProductId,
                        principalTable: "ProductPageTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageUrl",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ProductPageId = table.Column<Guid>(nullable: true),
                    ToolTip = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageUrl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImageUrl_ProductPages_ProductPageId",
                        column: x => x.ProductPageId,
                        principalTable: "ProductPages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImageUrl_ProductPageId",
                table: "ImageUrl",
                column: "ProductPageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPages_TypeOfProductId",
                table: "ProductPages",
                column: "TypeOfProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageUrl");

            migrationBuilder.DropTable(
                name: "ProductPages");

            migrationBuilder.DropTable(
                name: "ProductPageTypes");
        }
    }
}
