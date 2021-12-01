using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class M2M_ManagementPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_medical_notes_management_plans_management_plan_id",
                table: "medical_notes");

            migrationBuilder.DropIndex(
                name: "ix_medical_notes_management_plan_id",
                table: "medical_notes");

            migrationBuilder.DropColumn(
                name: "management_plan_id",
                table: "medical_notes");

            migrationBuilder.DropColumn(
                name: "anamnesis_id",
                table: "medical_appointments");

            migrationBuilder.AddColumn<Guid>(
                name: "medical_note_id",
                table: "management_plans",
                type: "RAW(16)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_management_plans_medical_note_id",
                table: "management_plans",
                column: "medical_note_id");

            migrationBuilder.AddForeignKey(
                name: "fk_management_plans_medical_notes_medical_note_id",
                table: "management_plans",
                column: "medical_note_id",
                principalTable: "medical_notes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_management_plans_medical_notes_medical_note_id",
                table: "management_plans");

            migrationBuilder.DropIndex(
                name: "ix_management_plans_medical_note_id",
                table: "management_plans");

            migrationBuilder.DropColumn(
                name: "medical_note_id",
                table: "management_plans");

            migrationBuilder.AddColumn<Guid>(
                name: "management_plan_id",
                table: "medical_notes",
                type: "RAW(16)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "anamnesis_id",
                table: "medical_appointments",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_medical_notes_management_plan_id",
                table: "medical_notes",
                column: "management_plan_id");

            migrationBuilder.AddForeignKey(
                name: "fk_medical_notes_management_plans_management_plan_id",
                table: "medical_notes",
                column: "management_plan_id",
                principalTable: "management_plans",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
