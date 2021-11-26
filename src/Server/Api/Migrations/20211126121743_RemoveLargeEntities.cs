using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class RemoveLargeEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_medical_appointments_medical_records_medical_record_id",
                table: "medical_appointments");

            migrationBuilder.DropTable(
                name: "medical_records");

            migrationBuilder.DropIndex(
                name: "ix_medical_appointments_medical_record_id",
                table: "medical_appointments");

            migrationBuilder.DropColumn(
                name: "medical_record_id",
                table: "medical_appointments");

            migrationBuilder.AddColumn<string>(
                name: "anamnesis_description",
                table: "medical_appointments",
                type: "NVARCHAR2(2000)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "anamnesis_id",
                table: "medical_appointments",
                type: "NUMBER(10)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "anamnesis_description",
                table: "medical_appointments");

            migrationBuilder.DropColumn(
                name: "anamnesis_id",
                table: "medical_appointments");

            migrationBuilder.AddColumn<Guid>(
                name: "medical_record_id",
                table: "medical_appointments",
                type: "RAW(16)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "medical_records",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    anamnesis_description = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_medical_records", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_medical_appointments_medical_record_id",
                table: "medical_appointments",
                column: "medical_record_id");

            migrationBuilder.AddForeignKey(
                name: "fk_medical_appointments_medical_records_medical_record_id",
                table: "medical_appointments",
                column: "medical_record_id",
                principalTable: "medical_records",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
