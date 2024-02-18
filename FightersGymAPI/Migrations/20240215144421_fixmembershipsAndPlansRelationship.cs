using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FightersGymAPI.Migrations
{
    /// <inheritdoc />
    public partial class fixmembershipsAndPlansRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MemberShips_PlanID",
                table: "MemberShips");

            migrationBuilder.CreateIndex(
                name: "IX_MemberShips_PlanID",
                table: "MemberShips",
                column: "PlanID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MemberShips_PlanID",
                table: "MemberShips");

            migrationBuilder.CreateIndex(
                name: "IX_MemberShips_PlanID",
                table: "MemberShips",
                column: "PlanID",
                unique: true);
        }
    }
}
