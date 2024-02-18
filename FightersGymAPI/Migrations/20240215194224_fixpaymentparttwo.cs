using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FightersGymAPI.Migrations
{
    /// <inheritdoc />
    public partial class fixpaymentparttwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_AspNetUsers_CreatedBy",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_AspNetUsers_UserId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Products_ProductId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Products_productId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_CreatedBy",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_ProductId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_UserId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "Payments",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_productId",
                table: "Payments",
                newName: "IX_Payments_ProductId");

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Payments",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CreatedById",
                table: "Payments",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_AspNetUsers_CreatedById",
                table: "Payments",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Products_ProductId",
                table: "Payments",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_AspNetUsers_CreatedById",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Products_ProductId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_CreatedById",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Payments",
                newName: "productId");

            migrationBuilder.RenameIndex(
                name: "IX_Payments_ProductId",
                table: "Payments",
                newName: "IX_Payments_productId");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Payments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Payments",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Payments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CreatedBy",
                table: "Payments",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ProductId",
                table: "Payments",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_UserId",
                table: "Payments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_AspNetUsers_CreatedBy",
                table: "Payments",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_AspNetUsers_UserId",
                table: "Payments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
