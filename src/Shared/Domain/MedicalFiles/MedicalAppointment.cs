using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Employees;
using Domain.MedicalFiles.MedicalNotes;
using Domain.MedicalFiles.MedicalRecords;
using Domain.Patients;

namespace Domain.MedicalFiles
{
    public class MedicalAppointment
    {
        [Key]
        public Guid AppointmentId { get; set; } = Guid.NewGuid();

        public string   AppointmentReason { get; set; }
        public string   DiseaseHistory    { get; set; }
        public DateTime AppointmentDate   { get; set; }
        public bool     IsActive          { get; set; } = true;

        public Anamnesis Anamnesis { get; set; }

        [ForeignKey("medical_note_id")]
        public MedicalNote MedicalNote { get; set; }

        public AptitudeCertificate AptitudeCertificate { get; set; }

        [ForeignKey("patient_id")]
        public Patient Patient { get; set; }

        [ForeignKey("doctor_id")]
        public SanitaryEmployee DoctorCaring { get; set; }

        public MedicalAppointment(string appointmentReason, string diseaseHistory,
            DateTime appointmentDate, MedicalNote medicalNote)
        {
            AppointmentReason = appointmentReason;
            DiseaseHistory    = diseaseHistory;
            AppointmentDate   = appointmentDate;
            MedicalNote       = medicalNote;
        }

        public MedicalAppointment()
        {
            // For EF
        }

        public bool IsBetweenDates(DateTime initialDate, DateTime limitDate)
        {
            return AppointmentDate <= initialDate && AppointmentDate >= limitDate;
        }
    }
}
