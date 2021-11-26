using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Employees;
using Domain.MedicalFiles.Background;
using Domain.MedicalFiles.MedicalNotes;
using Domain.MedicalFiles.MedicalRecords;
using Domain.Patients;

namespace Domain.MedicalFiles
{
    public class MedicalAppointment
    {
        [Key]
        public Guid AppointmentId { get; set; }

        public string   AppointmentReason { get; set; }
        public string   DiseaseHistory    { get; set; }
        public DateTime AppointmentDate   { get; set; }

        [ForeignKey("medical_record_id")]
        public MedicalRecord MedicalRecord { get; set; }

        [ForeignKey("medical_note_id")]
        public MedicalNote MedicalNote { get; set; }

        public AptitudeCertificate AptitudeCertificate { get; set; }

        [ForeignKey("patient_id")]
        public Patient Patient { get; set; }

        [ForeignKey("doctor_id")]
        public SanitaryEmployee DoctorCaring { get; set; }

        public IList<MedicalBackground> MedicalBackgrounds { get; set; }

        public MedicalAppointment(string appointmentReason, string diseaseHistory,
            DateTime appointmentDate, MedicalRecord medicalRecord, MedicalNote medicalNote)
        {
            AppointmentReason  = appointmentReason;
            DiseaseHistory     = diseaseHistory;
            AppointmentDate    = appointmentDate;
            MedicalRecord      = medicalRecord;
            MedicalNote        = medicalNote;
            MedicalBackgrounds = new List<MedicalBackground>();
        }

        public MedicalAppointment()
        {
            // For EF
        }

        public void AddMedicalBackground(string name, bool state,
            string observation)
        {
            var medicalBackground = new MedicalBackground(name, state, observation);
            MedicalBackgrounds.Add(medicalBackground);
        }

        public bool IsBetweenDates(DateTime initialDate, DateTime limitDate)
        {
            return AppointmentDate <= initialDate && AppointmentDate >= limitDate;
        }
    }
}
