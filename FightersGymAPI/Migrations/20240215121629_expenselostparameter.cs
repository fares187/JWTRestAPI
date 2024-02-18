using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FightersGymAPI.Migrations
{
    /// <inheritdoc />
    public partial class expenselostparameter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ApplicationUser",
                table: "Expences",
                newName: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Expences_ApplicationUserId",
                table: "Expences",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expences_AspNetUsers_ApplicationUserId",
                table: "Expences",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expences_AspNetUsers_ApplicationUserId",
                table: "Expences");

            migrationBuilder.DropIndex(
                name: "IX_Expences_ApplicationUserId",
                table: "Expences");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Expences",
                newName: "ApplicationUser");
        }
    }
}
