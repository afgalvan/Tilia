using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class PhysicalExams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_body_part_records_physical_exam_physical_exam_id",
                table: "body_part_records");

            migrationBuilder.DropForeignKey(
                name: "fk_medical_records_physical_exam_physical_exam_id",
                table: "medical_records");

            migrationBuilder.DropPrimaryKey(
                name: "pk_physical_exam",
                table: "physical_exam");

            migrationBuilder.RenameTable(
                name: "physical_exam",
                newName: "physical_exams");

            migrationBuilder.AddPrimaryKey(
                name: "pk_physical_exams",
                table: "physical_exams",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_body_part_records_physical_exams_physical_exam_id",
                table: "body_part_records",
                column: "physical_exam_id",
                principalTable: "physical_exams",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_medical_records_physical_exams_physical_exam_id",
                table: "medical_records",
                column: "physical_exam_id",
                principalTable: "physical_exams",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_body_part_records_physical_exams_physical_exam_id",
                table: "body_part_records");

            migrationBuilder.DropForeignKey(
                name: "fk_medical_records_physical_exams_physical_exam_id",
                table: "medical_records");

            migrationBuilder.DropPrimaryKey(
                name: "pk_physical_exams",
                table: "physical_exams");

            migrationBuilder.RenameTable(
                name: "physical_exams",
                newName: "physical_exam");

            migrationBuilder.AddPrimaryKey(
                name: "pk_physical_exam",
                table: "physical_exam",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_body_part_records_physical_exam_physical_exam_id",
                table: "body_part_records",
                column: "physical_exam_id",
                principalTable: "physical_exam",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_medical_records_physical_exam_physical_exam_id",
                table: "medical_records",
                column: "physical_exam_id",
                principalTable: "physical_exam",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
