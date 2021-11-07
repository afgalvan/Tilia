using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class MedicalSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "access_roles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_access_roles", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_departments", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "evolution_sheets",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_evolution_sheets", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "gynecological_backgrounds",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    menarchy = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    cycle = table.Column<int>(type: "int", nullable: false),
                    is_regular = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    has_dysmenorrhea = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    has_amenorrhea = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    last_menstrual_period = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    estimated_date_confinement = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    has_planning = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    method = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_gynecological_backgrounds", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "management_plans",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_management_plans", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "physical_exam",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    vital_sign_results_temperature = table.Column<double>(type: "double", nullable: true),
                    vital_sign_results_weight = table.Column<double>(type: "double", nullable: true),
                    vital_sign_results_height = table.Column<double>(type: "double", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_physical_exam", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "sanitary_roles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sanitary_roles", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "privileges",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    access_role_id = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_privileges", x => x.id);
                    table.ForeignKey(
                        name: "fk_privileges_access_roles_access_role_id",
                        column: x => x.access_role_id,
                        principalTable: "access_roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    department_id = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cities", x => x.id);
                    table.ForeignKey(
                        name: "fk_cities_departments_department_id",
                        column: x => x.department_id,
                        principalTable: "departments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "medical_notes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    evolution_sheet_id = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    management_plan_id = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_medical_notes", x => x.id);
                    table.ForeignKey(
                        name: "fk_medical_notes_evolution_sheets_evolution_sheet_id",
                        column: x => x.evolution_sheet_id,
                        principalTable: "evolution_sheets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_medical_notes_management_plans_management_plan_id",
                        column: x => x.management_plan_id,
                        principalTable: "management_plans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "body_part_records",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    segment = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    region = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    observations = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    physical_exam_id = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_body_part_records", x => x.id);
                    table.ForeignKey(
                        name: "fk_body_part_records_physical_exam_physical_exam_id",
                        column: x => x.physical_exam_id,
                        principalTable: "physical_exam",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "medical_records",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    anamnesis_description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    physical_exam_id = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_medical_records", x => x.id);
                    table.ForeignKey(
                        name: "fk_medical_records_physical_exam_physical_exam_id",
                        column: x => x.physical_exam_id,
                        principalTable: "physical_exam",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "people",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    id_type_name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    names_first_name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    names_last_name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    genre = table.Column<int>(type: "int", nullable: false),
                    city_id = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    birth_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    discriminator = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sanitary_role_id = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    occupation = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    studies = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sports_data_sport = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sports_data_modality = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sports_data_coach = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sports_data_start_date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    sports_data_continuous_training = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    sports_data_training_plan = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    sports_data_dominance = table.Column<int>(type: "int", nullable: true),
                    contact_data_address = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    contact_data_city_id = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    contact_data_stratum = table.Column<int>(type: "int", nullable: true),
                    contact_data_phone_number = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    contact_data_landline = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_people", x => x.id);
                    table.ForeignKey(
                        name: "fk_people_cities_city_id",
                        column: x => x.city_id,
                        principalTable: "cities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_people_cities_contact_data_city_id",
                        column: x => x.contact_data_city_id,
                        principalTable: "cities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_people_sanitary_roles_sanitary_role_id",
                        column: x => x.sanitary_role_id,
                        principalTable: "sanitary_roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "diagnostics",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    cie10 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    functional = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    medical_note_id = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_diagnostics", x => x.id);
                    table.ForeignKey(
                        name: "fk_diagnostics_medical_notes_medical_note_id",
                        column: x => x.medical_note_id,
                        principalTable: "medical_notes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "referrals",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    department = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    medical_note_id = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_referrals", x => x.id);
                    table.ForeignKey(
                        name: "fk_referrals_medical_notes_medical_note_id",
                        column: x => x.medical_note_id,
                        principalTable: "medical_notes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "medical_appointments",
                columns: table => new
                {
                    appointment_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    appointment_reason = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    disease_history = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    appointment_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    medical_record_id = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    medical_note_id = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    aptitude_certificate = table.Column<int>(type: "int", nullable: false),
                    patient_id = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    doctor_id = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    scheduler_id = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    gynecological_background_id = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_medical_appointments", x => x.appointment_id);
                    table.ForeignKey(
                        name: "fk_medical_appointments_gynecological_backgrounds_gynecological",
                        column: x => x.gynecological_background_id,
                        principalTable: "gynecological_backgrounds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_medical_appointments_medical_notes_medical_note_id",
                        column: x => x.medical_note_id,
                        principalTable: "medical_notes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_medical_appointments_medical_records_medical_record_id",
                        column: x => x.medical_record_id,
                        principalTable: "medical_records",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_medical_appointments_people_doctor_id",
                        column: x => x.doctor_id,
                        principalTable: "people",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_medical_appointments_people_patient_id",
                        column: x => x.patient_id,
                        principalTable: "people",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_medical_appointments_people_scheduler_id",
                        column: x => x.scheduler_id,
                        principalTable: "people",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    access_role_id = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    employee_id = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                    table.ForeignKey(
                        name: "fk_users_access_roles_access_role_id",
                        column: x => x.access_role_id,
                        principalTable: "access_roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_users_people_employee_id",
                        column: x => x.employee_id,
                        principalTable: "people",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "medical_backgrounds",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    state = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    observations = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    medical_appointment_appointment_id = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_medical_backgrounds", x => x.id);
                    table.ForeignKey(
                        name: "fk_medical_backgrounds_medical_appointments_medical_appointment",
                        column: x => x.medical_appointment_appointment_id,
                        principalTable: "medical_appointments",
                        principalColumn: "appointment_id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "ix_body_part_records_physical_exam_id",
                table: "body_part_records",
                column: "physical_exam_id");

            migrationBuilder.CreateIndex(
                name: "ix_cities_department_id",
                table: "cities",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "ix_diagnostics_medical_note_id",
                table: "diagnostics",
                column: "medical_note_id");

            migrationBuilder.CreateIndex(
                name: "ix_medical_appointments_doctor_id",
                table: "medical_appointments",
                column: "doctor_id");

            migrationBuilder.CreateIndex(
                name: "ix_medical_appointments_gynecological_background_id",
                table: "medical_appointments",
                column: "gynecological_background_id");

            migrationBuilder.CreateIndex(
                name: "ix_medical_appointments_medical_note_id",
                table: "medical_appointments",
                column: "medical_note_id");

            migrationBuilder.CreateIndex(
                name: "ix_medical_appointments_medical_record_id",
                table: "medical_appointments",
                column: "medical_record_id");

            migrationBuilder.CreateIndex(
                name: "ix_medical_appointments_patient_id",
                table: "medical_appointments",
                column: "patient_id");

            migrationBuilder.CreateIndex(
                name: "ix_medical_appointments_scheduler_id",
                table: "medical_appointments",
                column: "scheduler_id");

            migrationBuilder.CreateIndex(
                name: "ix_medical_backgrounds_medical_appointment_appointment_id",
                table: "medical_backgrounds",
                column: "medical_appointment_appointment_id");

            migrationBuilder.CreateIndex(
                name: "ix_medical_notes_evolution_sheet_id",
                table: "medical_notes",
                column: "evolution_sheet_id");

            migrationBuilder.CreateIndex(
                name: "ix_medical_notes_management_plan_id",
                table: "medical_notes",
                column: "management_plan_id");

            migrationBuilder.CreateIndex(
                name: "ix_medical_records_physical_exam_id",
                table: "medical_records",
                column: "physical_exam_id");

            migrationBuilder.CreateIndex(
                name: "ix_people_city_id",
                table: "people",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "ix_people_contact_data_city_id",
                table: "people",
                column: "contact_data_city_id");

            migrationBuilder.CreateIndex(
                name: "ix_people_sanitary_role_id",
                table: "people",
                column: "sanitary_role_id");

            migrationBuilder.CreateIndex(
                name: "ix_privileges_access_role_id",
                table: "privileges",
                column: "access_role_id");

            migrationBuilder.CreateIndex(
                name: "ix_referrals_medical_note_id",
                table: "referrals",
                column: "medical_note_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_access_role_id",
                table: "users",
                column: "access_role_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_employee_id",
                table: "users",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "ix_users_name",
                table: "users",
                column: "name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "body_part_records");

            migrationBuilder.DropTable(
                name: "diagnostics");

            migrationBuilder.DropTable(
                name: "medical_backgrounds");

            migrationBuilder.DropTable(
                name: "privileges");

            migrationBuilder.DropTable(
                name: "referrals");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "medical_appointments");

            migrationBuilder.DropTable(
                name: "access_roles");

            migrationBuilder.DropTable(
                name: "gynecological_backgrounds");

            migrationBuilder.DropTable(
                name: "medical_notes");

            migrationBuilder.DropTable(
                name: "medical_records");

            migrationBuilder.DropTable(
                name: "people");

            migrationBuilder.DropTable(
                name: "evolution_sheets");

            migrationBuilder.DropTable(
                name: "management_plans");

            migrationBuilder.DropTable(
                name: "physical_exam");

            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropTable(
                name: "sanitary_roles");

            migrationBuilder.DropTable(
                name: "departments");
        }
    }
}
