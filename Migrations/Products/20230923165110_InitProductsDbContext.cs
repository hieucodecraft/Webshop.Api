using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Webshop.Api.Migrations.Products
{
    /// <inheritdoc />
    public partial class InitProductsDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Product");

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Product",
                table: "Products",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("09f3dcf3-7c5d-4473-b398-30123e317966"), "Product #5", 500m },
                    { new Guid("338fc2fd-d0d4-461a-aa79-7c578a9ac826"), "Product #2", 200m },
                    { new Guid("47fa320e-d415-4d63-8021-75119441a598"), "Product #4", 400m },
                    { new Guid("91c8403b-4641-484a-aa47-c5547800b7c1"), "Product #3", 300m },
                    { new Guid("c37c6ba1-5c92-44aa-8e9a-ad7c1ae2f246"), "Product #1", 100m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products",
                schema: "Product");
        }
    }
}
