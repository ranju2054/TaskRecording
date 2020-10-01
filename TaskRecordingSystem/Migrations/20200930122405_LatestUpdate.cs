using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskRecordingSystem.Migrations
{
    public partial class LatestUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_EmployeeTask_EmployeeId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_EmployeeId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Employee");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTask_EmployeeId",
                table: "EmployeeTask",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTask_Employee_EmployeeId",
                table: "EmployeeTask",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTask_Employee_EmployeeId",
                table: "EmployeeTask");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeTask_EmployeeId",
                table: "EmployeeTask");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeId",
                table: "Employee",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_EmployeeTask_EmployeeId",
                table: "Employee",
                column: "EmployeeId",
                principalTable: "EmployeeTask",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
