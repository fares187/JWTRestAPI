using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FightersGymAPI.Migrations
{
    /// <inheritdoc />
    public partial class removesomethingfrommembership : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberShips_GymPlans_PlanID",
                table: "MemberShips");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberShips_GymPlans_PlanId",
                table: "MemberShips");

            migrationBuilder.DropIndex(
                name: "IX_MemberShips_PlanId",
                table: "MemberShips");

            migrationBuilder.DropIndex(
                name: "IX_MemberShips_PlanID",
                table: "MemberShips");

            migrationBuilder.DropColumn(
                name: "PlanID",
                table: "MemberShips");

            migrationBuilder.RenameColumn(
                name: "PlanId",
                table: "MemberShips",
                newName: "PlanID");

            migrationBuilder.CreateIndex(
                name: "IX_MemberShips_PlanID",
                table: "MemberShips",
                column: "PlanID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberShips_GymPlans_PlanID",
                table: "MemberShips",
                column: "PlanID",
                principalTable: "GymPlans",
                principalColumn: "PlanId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberShips_GymPlans_PlanID",
                table: "MemberShips");

            migrationBuilder.DropIndex(
                name: "IX_MemberShips_PlanID",
                table: "MemberShips");

            migrationBuilder.RenameColumn(
                name: "PlanID",
                table: "MemberShips",
                newName: "PlanId");

            migrationBuilder.AddColumn<int>(
                name: "PlanID",
                table: "MemberShips",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MemberShips_PlanId",
                table: "MemberShips",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberShips_PlanID",
                table: "MemberShips",
                column: "PlanID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberShips_GymPlans_PlanID",
                table: "MemberShips",
                column: "PlanID",
                principalTable: "GymPlans",
                principalColumn: "PlanId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberShips_GymPlans_PlanId",
                table: "MemberShips",
                column: "PlanId",
                principalTable: "GymPlans",
                principalColumn: "PlanId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
