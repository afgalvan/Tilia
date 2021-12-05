using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class AppointmentState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                table: "medical_appointments",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_active",
                table: "medical_appointments");
        }
    }
}
