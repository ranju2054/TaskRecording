using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskRecordingSystem.Migrations
{
    public partial class edited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Married",
                table: "MaritalStatus");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "MaritalStatus",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "MaritalStatus");

            migrationBuilder.AddColumn<bool>(
                name: "Married",
                table: "MaritalStatus",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
