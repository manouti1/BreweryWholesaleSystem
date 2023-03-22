using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Wholesalers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Breweries",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "X", "Brewer 1" },
                    { 2, "Y", "Brewer 2" }
                });

            migrationBuilder.InsertData(
                table: "Wholesalers",
                columns: new[] { "Id", "BeerId", "Location", "Name" },
                values: new object[,]
                {
                    { 1, null, null, "Wholesaler 1" },
                    { 2, null, null, "Wholesaler 2" }
                });

            migrationBuilder.InsertData(
                table: "Beers",
                columns: new[] { "Id", "BreweryId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Description 1", "Beer 1", 4.50m },
                    { 2, 1, "Description 2", "Beer 2", 5.00m },
                    { 3, 2, "Description 3", "Beer 3", 4.00m },
                    { 4, 2, "Description 4", "Beer 4", 5.50m }
                });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "BeerId", "Price", "Quantity", "WholesalerId" },
                values: new object[,]
                {
                    { 1, 1, 100.0m, 2, 1 },
                    { 2, 2, 10.0m, 1, 1 },
                    { 3, 3, 20.0m, 3, 2 },
                    { 4, 4, 4.50m, 1, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Stocks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Wholesalers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Wholesalers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Breweries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Breweries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Wholesalers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
