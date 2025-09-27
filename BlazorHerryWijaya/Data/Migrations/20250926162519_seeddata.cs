using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorHerryWijaya.Migrations
{
    /// <inheritdoc />
    public partial class seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyInventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyInventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyInventory_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyInventory_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "PT Jaya Kusuma" },
                    { 2, "Sehat Swadaya Tbk." },
                    { 3, "PT Makmur Bersama" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Tomato Red" },
                    { 2, "Apple Red" },
                    { 3, "Banana Yellow" },
                    { 4, "Apple Green" },
                    { 5, "Tomato Dark Red" }
                });

            migrationBuilder.InsertData(
                table: "CompanyInventory",
                columns: new[] { "Id", "CompanyId", "ProductId", "StockQuantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 15 },
                    { 2, 1, 2, 25 },
                    { 3, 1, 5, 115 },
                    { 4, 2, 1, 215 },
                    { 5, 2, 3, 315 },
                    { 6, 2, 4, 415 },
                    { 7, 3, 2, 25 },
                    { 8, 3, 4, 46 },
                    { 9, 3, 5, 77 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyInventory_CompanyId",
                table: "CompanyInventory",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyInventory_ProductId",
                table: "CompanyInventory",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyInventory");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
