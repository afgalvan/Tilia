﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using SharedLib.Persistence;

namespace Server.Migrations
{
    [DbContext(typeof(TiliaDbContext))]
    partial class TiliaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AccessRolePrivilege", b =>
                {
                    b.Property<Guid>("AccessRolesId")
                        .HasColumnType("RAW(16)")
                        .HasColumnName("access_roles_id");

                    b.Property<int>("PrivilegesId")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("privileges_id");

                    b.HasKey("AccessRolesId", "PrivilegesId")
                        .HasName("pk_access_role_privilege");

                    b.HasIndex("PrivilegesId")
                        .HasDatabaseName("ix_access_role_privilege_privileges_id");

                    b.ToTable("access_role_privilege");
                });

            modelBuilder.Entity("Domain.Employees.SanitaryRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("RAW(16)")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_sanitary_roles");

                    b.ToTable("sanitary_roles");
                });

            modelBuilder.Entity("Domain.Locations.City", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("NVARCHAR2(450)")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("name");

                    b.Property<string>("department_id")
                        .HasColumnType("NVARCHAR2(450)")
                        .HasColumnName("department_id");

                    b.HasKey("Id")
                        .HasName("pk_cities");

                    b.HasIndex("department_id")
                        .HasDatabaseName("ix_cities_department_id");

                    b.ToTable("cities");
                });

            modelBuilder.Entity("Domain.Locations.Department", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("NVARCHAR2(450)")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_departments");

                    b.ToTable("departments");
                });

            modelBuilder.Entity("Domain.MedicalFiles.Background.MedicalBackground", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("RAW(16)")
                        .HasColumnName("id");

                    b.Property<Guid?>("MedicalAppointmentAppointmentId")
                        .HasColumnType("RAW(16)")
                        .HasColumnName("medical_appointment_appointment_id");

                    b.Property<string>("Name")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("name");

                    b.Property<string>("Observations")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("observations");

                    b.Property<bool>("State")
                        .HasColumnType("NUMBER(1)")
                        .HasColumnName("state");

                    b.HasKey("Id")
                        .HasName("pk_medical_backgrounds");

                    b.HasIndex("MedicalAppointmentAppointmentId")
                        .HasDatabaseName("ix_medical_backgrounds_medical_appointment_appointment_id");

                    b.ToTable("medical_backgrounds");
                });

            modelBuilder.Entity("Domain.MedicalFiles.MedicalAppointment", b =>
                {
                    b.Property<Guid>("AppointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("RAW(16)")
                        .HasColumnName("appointment_id");

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("appointment_date");

                    b.Property<string>("AppointmentReason")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("appointment_reason");

                    b.Property<int>("AptitudeCertificate")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("aptitude_certificate");

                    b.Property<string>("DiseaseHistory")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("disease_history");

                    b.Property<string>("doctor_id")
                        .HasColumnType("NVARCHAR2(450)")
                        .HasColumnName("doctor_id");

                    b.Property<Guid?>("medical_note_id")
                        .HasColumnType("RAW(16)")
                        .HasColumnName("medical_note_id");

                    b.Property<Guid?>("medical_record_id")
                        .HasColumnType("RAW(16)")
                        .HasColumnName("medical_record_id");

                    b.Property<string>("patient_id")
                        .HasColumnType("NVARCHAR2(450)")
                        .HasColumnName("patient_id");

                    b.HasKey("AppointmentId")
                        .HasName("pk_medical_appointments");

                    b.HasIndex("doctor_id")
                        .HasDatabaseName("ix_medical_appointments_doctor_id");

                    b.HasIndex("medical_note_id")
                        .HasDatabaseName("ix_medical_appointments_medical_note_id");

                    b.HasIndex("medical_record_id")
                        .HasDatabaseName("ix_medical_appointments_medical_record_id");

                    b.HasIndex("patient_id")
                        .HasDatabaseName("ix_medical_appointments_patient_id");

                    b.ToTable("medical_appointments");
                });

            modelBuilder.Entity("Domain.MedicalFiles.MedicalNotes.Diagnosis", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("RAW(16)")
                        .HasColumnName("id");

                    b.Property<string>("CIE10")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("cie10");

                    b.Property<string>("Functional")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("functional");

                    b.Property<Guid?>("MedicalNoteId")
                        .HasColumnType("RAW(16)")
                        .HasColumnName("medical_note_id");

                    b.HasKey("Id")
                        .HasName("pk_diagnostics");

                    b.HasIndex("MedicalNoteId")
                        .HasDatabaseName("ix_diagnostics_medical_note_id");

                    b.ToTable("diagnostics");
                });

            modelBuilder.Entity("Domain.MedicalFiles.MedicalNotes.EvolutionSheet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("RAW(16)")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("description");

                    b.HasKey("Id")
                        .HasName("pk_evolution_sheets");

                    b.ToTable("evolution_sheets");
                });

            modelBuilder.Entity("Domain.MedicalFiles.MedicalNotes.ManagementPlan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("RAW(16)")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("description");

                    b.HasKey("Id")
                        .HasName("pk_management_plans");

                    b.ToTable("management_plans");
                });

            modelBuilder.Entity("Domain.MedicalFiles.MedicalNotes.MedicalNote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("RAW(16)")
                        .HasColumnName("id");

                    b.Property<Guid?>("evolution_sheet_id")
                        .HasColumnType("RAW(16)")
                        .HasColumnName("evolution_sheet_id");

                    b.Property<Guid?>("management_plan_id")
                        .HasColumnType("RAW(16)")
                        .HasColumnName("management_plan_id");

                    b.HasKey("Id")
                        .HasName("pk_medical_notes");

                    b.HasIndex("evolution_sheet_id")
                        .HasDatabaseName("ix_medical_notes_evolution_sheet_id");

                    b.HasIndex("management_plan_id")
                        .HasDatabaseName("ix_medical_notes_management_plan_id");

                    b.ToTable("medical_notes");
                });

            modelBuilder.Entity("Domain.MedicalFiles.MedicalNotes.Referral", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("RAW(16)")
                        .HasColumnName("id");

                    b.Property<string>("Department")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("department");

                    b.Property<string>("Description")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("description");

                    b.Property<Guid?>("MedicalNoteId")
                        .HasColumnType("RAW(16)")
                        .HasColumnName("medical_note_id");

                    b.HasKey("Id")
                        .HasName("pk_referrals");

                    b.HasIndex("MedicalNoteId")
                        .HasDatabaseName("ix_referrals_medical_note_id");

                    b.ToTable("referrals");
                });

            modelBuilder.Entity("Domain.MedicalFiles.MedicalRecords.BodyPartRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("RAW(16)")
                        .HasColumnName("id");

                    b.Property<string>("Observations")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("observations");

                    b.Property<Guid?>("PhysicalExamId")
                        .HasColumnType("RAW(16)")
                        .HasColumnName("physical_exam_id");

                    b.Property<string>("Region")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("region");

                    b.Property<string>("Segment")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("segment");

                    b.HasKey("Id")
                        .HasName("pk_body_part_records");

                    b.HasIndex("PhysicalExamId")
                        .HasDatabaseName("ix_body_part_records_physical_exam_id");

                    b.ToTable("body_part_records");
                });

            modelBuilder.Entity("Domain.MedicalFiles.MedicalRecords.MedicalRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("RAW(16)")
                        .HasColumnName("id");

                    b.Property<Guid?>("physical_exam_id")
                        .HasColumnType("RAW(16)")
                        .HasColumnName("physical_exam_id");

                    b.HasKey("Id")
                        .HasName("pk_medical_records");

                    b.HasIndex("physical_exam_id")
                        .HasDatabaseName("ix_medical_records_physical_exam_id");

                    b.ToTable("medical_records");
                });

            modelBuilder.Entity("Domain.MedicalFiles.MedicalRecords.PhysicalExam", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("RAW(16)")
                        .HasColumnName("id");

                    b.HasKey("Id")
                        .HasName("pk_physical_exams");

                    b.ToTable("physical_exams");
                });

            modelBuilder.Entity("Domain.People.IdType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_id_types");

                    b.ToTable("id_types");
                });

            modelBuilder.Entity("Domain.People.Person", b =>
                {
                    b.Property<string>("PersonId")
                        .HasColumnType("NVARCHAR2(450)")
                        .HasColumnName("person_id");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("birth_date");

                    b.Property<string>("CityId")
                        .HasColumnType("NVARCHAR2(450)")
                        .HasColumnName("city_id");

                    b.Property<string>("FirstName")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("first_name");

                    b.Property<int>("Genre")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("genre");

                    b.Property<string>("LastName")
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("last_name");

                    b.Property<int?>("identification_type_id")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("identification_type_id");

                    b.HasKey("PersonId");

                    b.HasIndex("CityId")
                        .HasDatabaseName("ix_people_city_id");

                    b.HasIndex("identification_type_id")
                        .HasDatabaseName("ix_people_identification_type_id");

                    b.ToTable("people");
                });

            modelBuilder.Entity("Domain.Users.AccessRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("RAW(16)")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_access_roles");

                    b.ToTable("access_roles");
                });

            modelBuilder.Entity("Domain.Users.Privilege", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id")
                        .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_privileges");

                    b.ToTable("privileges");
                });

            modelBuilder.Entity("Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("RAW(16)")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)")
                        .HasColumnName("password");

                    b.Property<Guid?>("access_role_id")
                        .HasColumnType("RAW(16)")
                        .HasColumnName("access_role_id");

                    b.Property<string>("employee_id")
                        .HasColumnType("NVARCHAR2(450)")
                        .HasColumnName("employee_id");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("ix_users_email");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("ix_users_name");

                    b.HasIndex("access_role_id")
                        .HasDatabaseName("ix_users_access_role_id");

                    b.HasIndex("employee_id")
                        .HasDatabaseName("ix_users_employee_id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Domain.Employees.Employee", b =>
                {
                    b.HasBaseType("Domain.People.Person");

                    b.ToTable("employees");
                });

            modelBuilder.Entity("Domain.Patients.Patient", b =>
                {
                    b.HasBaseType("Domain.People.Person");

                    b.Property<string>("Occupation")
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)")
                        .HasColumnName("occupation");

                    b.Property<string>("Studies")
                        .HasMaxLength(255)
                        .HasColumnType("NVARCHAR2(255)")
                        .HasColumnName("studies");

                    b.ToTable("patients");
                });

            modelBuilder.Entity("Domain.Employees.SanitaryEmployee", b =>
                {
                    b.HasBaseType("Domain.Employees.Employee");

                    b.Property<Guid?>("SanitaryRoleId")
                        .HasColumnType("RAW(16)")
                        .HasColumnName("sanitary_role_id");

                    b.HasIndex("SanitaryRoleId")
                        .HasDatabaseName("ix_sanitary_employees_sanitary_role_id");

                    b.ToTable("sanitary_employees");
                });

            modelBuilder.Entity("AccessRolePrivilege", b =>
                {
                    b.HasOne("Domain.Users.AccessRole", null)
                        .WithMany()
                        .HasForeignKey("AccessRolesId")
                        .HasConstraintName("fk_access_role_privilege_access_roles_access_roles_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Users.Privilege", null)
                        .WithMany()
                        .HasForeignKey("PrivilegesId")
                        .HasConstraintName("fk_access_role_privilege_privileges_privileges_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Locations.City", b =>
                {
                    b.HasOne("Domain.Locations.Department", "Department")
                        .WithMany()
                        .HasForeignKey("department_id")
                        .HasConstraintName("fk_cities_departments_department_id");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Domain.MedicalFiles.Background.MedicalBackground", b =>
                {
                    b.HasOne("Domain.MedicalFiles.MedicalAppointment", null)
                        .WithMany("MedicalBackgrounds")
                        .HasForeignKey("MedicalAppointmentAppointmentId")
                        .HasConstraintName("fk_medical_backgrounds_medical_appointments_medical_appointment_appointment_id");
                });

            modelBuilder.Entity("Domain.MedicalFiles.MedicalAppointment", b =>
                {
                    b.HasOne("Domain.Employees.SanitaryEmployee", "DoctorCaring")
                        .WithMany()
                        .HasForeignKey("doctor_id")
                        .HasConstraintName("fk_medical_appointments_sanitary_employees_doctor_id");

                    b.HasOne("Domain.MedicalFiles.MedicalNotes.MedicalNote", "MedicalNote")
                        .WithMany()
                        .HasForeignKey("medical_note_id")
                        .HasConstraintName("fk_medical_appointments_medical_notes_medical_note_id");

                    b.HasOne("Domain.MedicalFiles.MedicalRecords.MedicalRecord", "MedicalRecord")
                        .WithMany()
                        .HasForeignKey("medical_record_id")
                        .HasConstraintName("fk_medical_appointments_medical_records_medical_record_id");

                    b.HasOne("Domain.Patients.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("patient_id")
                        .HasConstraintName("fk_medical_appointments_patients_patient_id");

                    b.Navigation("DoctorCaring");

                    b.Navigation("MedicalNote");

                    b.Navigation("MedicalRecord");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Domain.MedicalFiles.MedicalNotes.Diagnosis", b =>
                {
                    b.HasOne("Domain.MedicalFiles.MedicalNotes.MedicalNote", null)
                        .WithMany("Diagnostics")
                        .HasForeignKey("MedicalNoteId")
                        .HasConstraintName("fk_diagnostics_medical_notes_medical_note_id");
                });

            modelBuilder.Entity("Domain.MedicalFiles.MedicalNotes.MedicalNote", b =>
                {
                    b.HasOne("Domain.MedicalFiles.MedicalNotes.EvolutionSheet", "EvolutionSheet")
                        .WithMany()
                        .HasForeignKey("evolution_sheet_id")
                        .HasConstraintName("fk_medical_notes_evolution_sheets_evolution_sheet_id");

                    b.HasOne("Domain.MedicalFiles.MedicalNotes.ManagementPlan", "ManagementPlan")
                        .WithMany()
                        .HasForeignKey("management_plan_id")
                        .HasConstraintName("fk_medical_notes_management_plans_management_plan_id");

                    b.Navigation("EvolutionSheet");

                    b.Navigation("ManagementPlan");
                });

            modelBuilder.Entity("Domain.MedicalFiles.MedicalNotes.Referral", b =>
                {
                    b.HasOne("Domain.MedicalFiles.MedicalNotes.MedicalNote", null)
                        .WithMany("Referrals")
                        .HasForeignKey("MedicalNoteId")
                        .HasConstraintName("fk_referrals_medical_notes_medical_note_id");
                });

            modelBuilder.Entity("Domain.MedicalFiles.MedicalRecords.BodyPartRecord", b =>
                {
                    b.HasOne("Domain.MedicalFiles.MedicalRecords.PhysicalExam", null)
                        .WithMany("BodyPartRecords")
                        .HasForeignKey("PhysicalExamId")
                        .HasConstraintName("fk_body_part_records_physical_exams_physical_exam_id");
                });

            modelBuilder.Entity("Domain.MedicalFiles.MedicalRecords.MedicalRecord", b =>
                {
                    b.HasOne("Domain.MedicalFiles.MedicalRecords.PhysicalExam", "PhysicalExams")
                        .WithMany()
                        .HasForeignKey("physical_exam_id")
                        .HasConstraintName("fk_medical_records_physical_exams_physical_exam_id");

                    b.OwnsOne("Domain.MedicalFiles.MedicalRecords.Anamnesis", "Anamnesis", b1 =>
                        {
                            b1.Property<Guid>("MedicalRecordId")
                                .HasColumnType("RAW(16)")
                                .HasColumnName("id");

                            b1.Property<string>("Description")
                                .HasColumnType("NVARCHAR2(2000)")
                                .HasColumnName("anamnesis_description");

                            b1.HasKey("MedicalRecordId")
                                .HasName("pk_medical_records");

                            b1.ToTable("medical_records");

                            b1.WithOwner()
                                .HasForeignKey("MedicalRecordId")
                                .HasConstraintName("fk_medical_records_medical_records_id");
                        });

                    b.Navigation("Anamnesis");

                    b.Navigation("PhysicalExams");
                });

            modelBuilder.Entity("Domain.MedicalFiles.MedicalRecords.PhysicalExam", b =>
                {
                    b.OwnsOne("Domain.MedicalFiles.MedicalRecords.VitalSign", "VitalSignResults", b1 =>
                        {
                            b1.Property<Guid>("PhysicalExamId")
                                .HasColumnType("RAW(16)")
                                .HasColumnName("id");

                            b1.Property<double>("Height")
                                .HasColumnType("BINARY_DOUBLE")
                                .HasColumnName("vital_sign_results_height");

                            b1.Property<double>("Temperature")
                                .HasColumnType("BINARY_DOUBLE")
                                .HasColumnName("vital_sign_results_temperature");

                            b1.Property<double>("Weight")
                                .HasColumnType("BINARY_DOUBLE")
                                .HasColumnName("vital_sign_results_weight");

                            b1.HasKey("PhysicalExamId")
                                .HasName("pk_physical_exams");

                            b1.ToTable("physical_exams");

                            b1.WithOwner()
                                .HasForeignKey("PhysicalExamId")
                                .HasConstraintName("fk_physical_exams_physical_exams_id");
                        });

                    b.Navigation("VitalSignResults");
                });

            modelBuilder.Entity("Domain.People.Person", b =>
                {
                    b.HasOne("Domain.Locations.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .HasConstraintName("fk_people_cities_city_id");

                    b.HasOne("Domain.People.IdType", "IdType")
                        .WithMany()
                        .HasForeignKey("identification_type_id")
                        .HasConstraintName("fk_people_id_types_identification_type_id");

                    b.Navigation("City");

                    b.Navigation("IdType");
                });

            modelBuilder.Entity("Domain.Users.User", b =>
                {
                    b.HasOne("Domain.Users.AccessRole", "AccessRole")
                        .WithMany()
                        .HasForeignKey("access_role_id")
                        .HasConstraintName("fk_users_access_roles_access_role_id");

                    b.HasOne("Domain.Employees.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("employee_id")
                        .HasConstraintName("fk_users_employees_employee_id");

                    b.Navigation("AccessRole");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Domain.Employees.Employee", b =>
                {
                    b.HasOne("Domain.People.Person", null)
                        .WithOne()
                        .HasForeignKey("Domain.Employees.Employee", "PersonId")
                        .HasConstraintName("fk_employees_people_person_id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Patients.Patient", b =>
                {
                    b.HasOne("Domain.People.Person", null)
                        .WithOne()
                        .HasForeignKey("Domain.Patients.Patient", "PersonId")
                        .HasConstraintName("fk_patients_people_person_id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.OwnsOne("Domain.Patients.ContactData", "ContactData", b1 =>
                        {
                            b1.Property<string>("PatientPersonId")
                                .HasColumnType("NVARCHAR2(450)")
                                .HasColumnName("person_id");

                            b1.Property<string>("Address")
                                .HasColumnType("NVARCHAR2(2000)")
                                .HasColumnName("contact_data_address");

                            b1.Property<string>("Landline")
                                .HasColumnType("NVARCHAR2(2000)")
                                .HasColumnName("contact_data_landline");

                            b1.Property<string>("PhoneNumber")
                                .HasColumnType("NVARCHAR2(2000)")
                                .HasColumnName("contact_data_phone_number");

                            b1.Property<int>("Stratum")
                                .HasColumnType("NUMBER(10)")
                                .HasColumnName("contact_data_stratum");

                            b1.Property<string>("city_id")
                                .HasColumnType("NVARCHAR2(450)")
                                .HasColumnName("contact_data_city_id");

                            b1.HasKey("PatientPersonId");

                            b1.HasIndex("city_id")
                                .HasDatabaseName("ix_patients_contact_data_city_id");

                            b1.ToTable("patients");

                            b1.WithOwner()
                                .HasForeignKey("PatientPersonId")
                                .HasConstraintName("fk_patients_patients_person_id");

                            b1.HasOne("Domain.Locations.City", "LivingCity")
                                .WithMany()
                                .HasForeignKey("city_id")
                                .HasConstraintName("fk_patients_cities_contact_data_city_id");

                            b1.Navigation("LivingCity");
                        });

                    b.OwnsOne("Domain.Patients.SportsData", "SportsData", b1 =>
                        {
                            b1.Property<string>("PatientPersonId")
                                .HasColumnType("NVARCHAR2(450)")
                                .HasColumnName("person_id");

                            b1.Property<string>("Coach")
                                .HasColumnType("NVARCHAR2(2000)")
                                .HasColumnName("sports_data_coach");

                            b1.Property<bool>("ContinuousTraining")
                                .HasColumnType("NUMBER(1)")
                                .HasColumnName("sports_data_continuous_training");

                            b1.Property<int>("Dominance")
                                .HasColumnType("NUMBER(10)")
                                .HasColumnName("sports_data_dominance");

                            b1.Property<string>("Modality")
                                .HasColumnType("NVARCHAR2(2000)")
                                .HasColumnName("sports_data_modality");

                            b1.Property<string>("Sport")
                                .HasColumnType("NVARCHAR2(2000)")
                                .HasColumnName("sports_data_sport");

                            b1.Property<DateTime>("StartDate")
                                .HasColumnType("TIMESTAMP(7)")
                                .HasColumnName("sports_data_start_date");

                            b1.Property<bool>("TrainingPlan")
                                .HasColumnType("NUMBER(1)")
                                .HasColumnName("sports_data_training_plan");

                            b1.HasKey("PatientPersonId");

                            b1.ToTable("patients");

                            b1.WithOwner()
                                .HasForeignKey("PatientPersonId")
                                .HasConstraintName("fk_patients_patients_person_id");
                        });

                    b.Navigation("ContactData");

                    b.Navigation("SportsData");
                });

            modelBuilder.Entity("Domain.Employees.SanitaryEmployee", b =>
                {
                    b.HasOne("Domain.Employees.Employee", null)
                        .WithOne()
                        .HasForeignKey("Domain.Employees.SanitaryEmployee", "PersonId")
                        .HasConstraintName("fk_sanitary_employees_employees_person_id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("Domain.Employees.SanitaryRole", "SanitaryRole")
                        .WithMany()
                        .HasForeignKey("SanitaryRoleId")
                        .HasConstraintName("fk_sanitary_employees_sanitary_roles_sanitary_role_id");

                    b.Navigation("SanitaryRole");
                });

            modelBuilder.Entity("Domain.MedicalFiles.MedicalAppointment", b =>
                {
                    b.Navigation("MedicalBackgrounds");
                });

            modelBuilder.Entity("Domain.MedicalFiles.MedicalNotes.MedicalNote", b =>
                {
                    b.Navigation("Diagnostics");

                    b.Navigation("Referrals");
                });

            modelBuilder.Entity("Domain.MedicalFiles.MedicalRecords.PhysicalExam", b =>
                {
                    b.Navigation("BodyPartRecords");
                });
#pragma warning restore 612, 618
        }
    }
}
