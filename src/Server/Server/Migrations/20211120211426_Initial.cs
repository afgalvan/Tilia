using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "access_roles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_access_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_departments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "evolution_sheets",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    description = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_evolution_sheets", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "gynecological_backgrounds",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    menarchy = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    cycle = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    is_regular = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    has_dysmenorrhea = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    has_amenorrhea = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    last_menstrual_period = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    estimated_date_confinement = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    has_planning = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    method = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_gynecological_backgrounds", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "id_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_id_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "management_plans",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    description = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_management_plans", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "physical_exams",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    vital_sign_results_temperature = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    vital_sign_results_weight = table.Column<double>(type: "BINARY_DOUBLE", nullable: true),
                    vital_sign_results_height = table.Column<double>(type: "BINARY_DOUBLE", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_physical_exams", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sanitary_roles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sanitary_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "privileges",
                columns: table => new
                {
                    id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    access_role_id = table.Column<Guid>(type: "RAW(16)", nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    department_id = table.Column<string>(type: "NVARCHAR2(450)", nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "medical_notes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    evolution_sheet_id = table.Column<Guid>(type: "RAW(16)", nullable: true),
                    management_plan_id = table.Column<Guid>(type: "RAW(16)", nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "body_part_records",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    segment = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    region = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    observations = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    physical_exam_id = table.Column<Guid>(type: "RAW(16)", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "medical_records",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    anamnesis_description = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    physical_exam_id = table.Column<Guid>(type: "RAW(16)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_medical_records", x => x.id);
                    table.ForeignKey(
                        name: "fk_medical_records_physical_exams_physical_exam_id",
                        column: x => x.physical_exam_id,
                        principalTable: "physical_exams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "people",
                columns: table => new
                {
                    person_id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    identification_type_id = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    first_name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    last_name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    genre = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    city_id = table.Column<string>(type: "NVARCHAR2(450)", nullable: true),
                    birth_date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_people", x => x.person_id);
                    table.ForeignKey(
                        name: "fk_people_cities_city_id",
                        column: x => x.city_id,
                        principalTable: "cities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_people_id_types_identification_type_id",
                        column: x => x.identification_type_id,
                        principalTable: "id_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "diagnostics",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    cie10 = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    functional = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    medical_note_id = table.Column<Guid>(type: "RAW(16)", nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "referrals",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    department = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    description = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    medical_note_id = table.Column<Guid>(type: "RAW(16)", nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    person_id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.person_id);
                    table.ForeignKey(
                        name: "fk_employees_people_person_id",
                        column: x => x.person_id,
                        principalTable: "people",
                        principalColumn: "person_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "patients",
                columns: table => new
                {
                    person_id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    occupation = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    studies = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    sports_data_sport = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    sports_data_modality = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    sports_data_coach = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    sports_data_start_date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    sports_data_continuous_training = table.Column<bool>(type: "NUMBER(1)", nullable: true),
                    sports_data_training_plan = table.Column<bool>(type: "NUMBER(1)", nullable: true),
                    sports_data_dominance = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    contact_data_address = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    contact_data_city_id = table.Column<string>(type: "NVARCHAR2(450)", nullable: true),
                    contact_data_stratum = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    contact_data_phone_number = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    contact_data_landline = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patients", x => x.person_id);
                    table.ForeignKey(
                        name: "fk_patients_cities_contact_data_city_id",
                        column: x => x.contact_data_city_id,
                        principalTable: "cities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_patients_people_person_id",
                        column: x => x.person_id,
                        principalTable: "people",
                        principalColumn: "person_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sanitary_employees",
                columns: table => new
                {
                    person_id = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    sanitary_role_id = table.Column<Guid>(type: "RAW(16)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sanitary_employees", x => x.person_id);
                    table.ForeignKey(
                        name: "fk_sanitary_employees_employees_person_id",
                        column: x => x.person_id,
                        principalTable: "employees",
                        principalColumn: "person_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_sanitary_employees_sanitary_roles_sanitary_role_id",
                        column: x => x.sanitary_role_id,
                        principalTable: "sanitary_roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    name = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    password = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    access_role_id = table.Column<Guid>(type: "RAW(16)", nullable: true),
                    employee_id = table.Column<string>(type: "NVARCHAR2(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => new { x.id, x.name });
                    table.ForeignKey(
                        name: "fk_users_access_roles_access_role_id",
                        column: x => x.access_role_id,
                        principalTable: "access_roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_users_employees_employee_id",
                        column: x => x.employee_id,
                        principalTable: "employees",
                        principalColumn: "person_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "medical_appointments",
                columns: table => new
                {
                    appointment_id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    appointment_reason = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    disease_history = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    appointment_date = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    medical_record_id = table.Column<Guid>(type: "RAW(16)", nullable: true),
                    medical_note_id = table.Column<Guid>(type: "RAW(16)", nullable: true),
                    aptitude_certificate = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    patient_id = table.Column<string>(type: "NVARCHAR2(450)", nullable: true),
                    doctor_id = table.Column<string>(type: "NVARCHAR2(450)", nullable: true),
                    scheduler_id = table.Column<string>(type: "NVARCHAR2(450)", nullable: true),
                    gynecological_background_id = table.Column<Guid>(type: "RAW(16)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_medical_appointments", x => x.appointment_id);
                    table.ForeignKey(
                        name: "fk_medical_appointments_employees_scheduler_id",
                        column: x => x.scheduler_id,
                        principalTable: "employees",
                        principalColumn: "person_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_medical_appointments_gynecological_backgrounds_gynecological_background_id",
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
                        name: "fk_medical_appointments_patients_patient_id",
                        column: x => x.patient_id,
                        principalTable: "patients",
                        principalColumn: "person_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_medical_appointments_sanitary_employees_doctor_id",
                        column: x => x.doctor_id,
                        principalTable: "sanitary_employees",
                        principalColumn: "person_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "medical_backgrounds",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    state = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    observations = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    medical_appointment_appointment_id = table.Column<Guid>(type: "RAW(16)", nullable: true)
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
                name: "ix_patients_contact_data_city_id",
                table: "patients",
                column: "contact_data_city_id");

            migrationBuilder.CreateIndex(
                name: "ix_people_city_id",
                table: "people",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "ix_people_identification_type_id",
                table: "people",
                column: "identification_type_id");

            migrationBuilder.CreateIndex(
                name: "ix_privileges_access_role_id",
                table: "privileges",
                column: "access_role_id");

            migrationBuilder.CreateIndex(
                name: "ix_referrals_medical_note_id",
                table: "referrals",
                column: "medical_note_id");

            migrationBuilder.CreateIndex(
                name: "ix_sanitary_employees_sanitary_role_id",
                table: "sanitary_employees",
                column: "sanitary_role_id");

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
                name: "patients");

            migrationBuilder.DropTable(
                name: "sanitary_employees");

            migrationBuilder.DropTable(
                name: "evolution_sheets");

            migrationBuilder.DropTable(
                name: "management_plans");

            migrationBuilder.DropTable(
                name: "physical_exams");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "sanitary_roles");

            migrationBuilder.DropTable(
                name: "people");

            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropTable(
                name: "id_types");

            migrationBuilder.DropTable(
                name: "departments");
        }
    }
}
