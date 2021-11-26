using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class RemoveScheduler : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_medical_appointments_employees_scheduler_id",
                table: "medical_appointments");

            migrationBuilder.DropForeignKey(
                name: "fk_medical_appointments_gynecological_backgrounds_gynecological_background_id",
                table: "medical_appointments");

            migrationBuilder.DropTable(
                name: "gynecological_backgrounds");

            migrationBuilder.DropIndex(
                name: "ix_medical_appointments_gynecological_background_id",
                table: "medical_appointments");

            migrationBuilder.DropIndex(
                name: "ix_medical_appointments_scheduler_id",
                table: "medical_appointments");

            migrationBuilder.DropColumn(
                name: "gynecological_background_id",
                table: "medical_appointments");

            migrationBuilder.DropColumn(
                name: "scheduler_id",
                table: "medical_appointments");

            migrationBuilder.CreateIndex(
                name: "ix_users_email",
                table: "users",
                column: "email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_users_email",
                table: "users");

            migrationBuilder.AddColumn<Guid>(
                name: "gynecological_background_id",
                table: "medical_appointments",
                type: "RAW(16)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "scheduler_id",
                table: "medical_appointments",
                type: "NVARCHAR2(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "gynecological_backgrounds",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    cycle = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    estimated_date_confinement = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    has_amenorrhea = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    has_dysmenorrhea = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    has_planning = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    is_regular = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    last_menstrual_period = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    menarchy = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    method = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_gynecological_backgrounds", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_medical_appointments_gynecological_background_id",
                table: "medical_appointments",
                column: "gynecological_background_id");

            migrationBuilder.CreateIndex(
                name: "ix_medical_appointments_scheduler_id",
                table: "medical_appointments",
                column: "scheduler_id");

            migrationBuilder.AddForeignKey(
                name: "fk_medical_appointments_employees_scheduler_id",
                table: "medical_appointments",
                column: "scheduler_id",
                principalTable: "employees",
                principalColumn: "person_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_medical_appointments_gynecological_backgrounds_gynecological_background_id",
                table: "medical_appointments",
                column: "gynecological_background_id",
                principalTable: "gynecological_backgrounds",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
