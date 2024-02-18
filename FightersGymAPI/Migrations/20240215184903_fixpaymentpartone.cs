using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FightersGymAPI.Migrations
{
    /// <inheritdoc />
    public partial class fixpaymentpartone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Products_ProductId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Products_produtId",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Payments",
                newName: "productId");

            migrationBuilder.RenameColumn(
                name: "produtId",
                table: "Payments",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_ProductId",
                table: "Payments",
                newName: "IX_Payments_productId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_produtId",
                table: "Payments",
                newName: "IX_Payments_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Products_ProductId",
                table: "Payments",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Products_productId",
                table: "Payments",
                column: "productId",
                principalTable: "Products",
                principalColumn: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Products_ProductId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Products_productId",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "Payments",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Payments",
                newName: "produtId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_productId",
                table: "Payments",
                newName: "IX_Payments_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_ProductId",
                table: "Payments",
                newName: "IX_Payments_produtId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Products_ProductId",
                table: "Payments",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Products_produtId",
                table: "Payments",
                column: "produtId",
                principalTable: "Products",
                principalColumn: "ProductId");
        }
    }
}
