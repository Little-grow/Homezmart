using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Homezmart.Migrations
{
    /// <inheritdoc />
    public partial class indexprice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Products_Price",
                table: "Products",
                column: "Price");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_Price",
                table: "Products");
        }
    }
}
