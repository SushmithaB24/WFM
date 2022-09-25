using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestAPI.Migrations
{
    public partial class WFMinit3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillMaps_Employees_Skillid",
                table: "SkillMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillMaps_Skills_SkillsSkillid",
                table: "SkillMaps");

            migrationBuilder.DropIndex(
                name: "IX_SkillMaps_SkillsSkillid",
                table: "SkillMaps");

            migrationBuilder.DropColumn(
                name: "SkillsSkillid",
                table: "SkillMaps");

            migrationBuilder.CreateIndex(
                name: "IX_SkillMaps_EmployeeId",
                table: "SkillMaps",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillMaps_Employees_EmployeeId",
                table: "SkillMaps",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillMaps_Skills_Skillid",
                table: "SkillMaps",
                column: "Skillid",
                principalTable: "Skills",
                principalColumn: "Skillid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillMaps_Employees_EmployeeId",
                table: "SkillMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_SkillMaps_Skills_Skillid",
                table: "SkillMaps");

            migrationBuilder.DropIndex(
                name: "IX_SkillMaps_EmployeeId",
                table: "SkillMaps");

            migrationBuilder.AddColumn<int>(
                name: "SkillsSkillid",
                table: "SkillMaps",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SkillMaps_SkillsSkillid",
                table: "SkillMaps",
                column: "SkillsSkillid");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillMaps_Employees_Skillid",
                table: "SkillMaps",
                column: "Skillid",
                principalTable: "Employees",
                principalColumn: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillMaps_Skills_SkillsSkillid",
                table: "SkillMaps",
                column: "SkillsSkillid",
                principalTable: "Skills",
                principalColumn: "Skillid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
