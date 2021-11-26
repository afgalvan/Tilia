using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class RedesignEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_medical_records_physical_exams_physical_exam_id",
                table: "medical_records");

            migrationBuilder.DropTable(
                name: "body_part_records");

            migrationBuilder.DropTable(
                name: "medical_backgrounds");

            migrationBuilder.DropTable(
                name: "physical_exams");

            migrationBuilder.DropIndex(
                name: "ix_medical_records_physical_exam_id",
                table: "medical_records");

            migrationBuilder.DropColumn(
                name: "physical_exam_id",
                table: "medical_records");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "physical_exam_id",
                table: "medical_records",
                type: "RAW(16)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "medical_backgrounds",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    medical_appointment_appointment_id = table.Column<Guid>(type: "RAW(16)", nullable: true),
                    name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    observations = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    state = table.Column<bool>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_medical_backgrounds", x => x.id);
                    table.ForeignKey(
                        name: "fk_medical_backgrounds_medical_appointments_medical_appointment_appointment_id",
                        column: x => x.medical_appointment_appointment_id,
                        principalTable: "medical_appointments",
                        principalColumn: "appointment_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "physical_exams",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    vital_sign_results_height = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    vital_sign_results_temperature = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    vital_sign_results_weight = table.Column<double>(type: "BINARY_DOUBLE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_physical_exams", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "body_part_records",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    observations = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    physical_exam_id = table.Column<Guid>(type: "RAW(16)", nullable: true),
                    region = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    segment = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_body_part_records", x => x.id);
                    table.ForeignKey(
                        name: "fk_body_part_records_physical_exams_physical_exam_id",
                        column: x => x.physical_exam_id,
                        principalTable: "physical_exams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_medical_records_physical_exam_id",
                table: "medical_records",
                column: "physical_exam_id");

            migrationBuilder.CreateIndex(
                name: "ix_body_part_records_physical_exam_id",
                table: "body_part_records",
                column: "physical_exam_id");

            migrationBuilder.CreateIndex(
                name: "ix_medical_backgrounds_medical_appointment_appointment_id",
                table: "medical_backgrounds",
                column: "medical_appointment_appointment_id");

            migrationBuilder.AddForeignKey(
                name: "fk_medical_records_physical_exams_physical_exam_id",
                table: "medical_records",
                column: "physical_exam_id",
                principalTable: "physical_exams",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
