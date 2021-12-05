using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class AttentionHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "attention_history",
                columns: table => new
                {
                    id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    attendants = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    appointment_id = table.Column<Guid>(type: "RAW(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_attention_history", x => x.id);
                    table.ForeignKey(
                        name: "fk_attention_history_medical_appointments_medical_appointment_appointment_id",
                        column: x => x.appointment_id,
                        principalTable: "medical_appointments",
                        principalColumn: "appointment_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_attention_history_appointment_id",
                table: "attention_history",
                column: "appointment_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "attention_history");
        }
    }
}
