using Microsoft.EntityFrameworkCore.Migrations;

namespace Practial.Domain.Migrations
{
    public partial class EmployeeDepartmentIdNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<char>(
                name: "DepartmentId",
                table: "Employee",
                nullable: true,
                oldClrType: typeof(char),
                oldType: "character(1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<char>(
                name: "DepartmentId",
                table: "Employee",
                type: "character(1)",
                nullable: false,
                oldClrType: typeof(char),
                oldNullable: true);
        }
    }
}
