using System;
using Domain.MedicalFiles.Background;
using Domain.MedicalFiles.MedicalNotes;
using Domain.MedicalFiles.MedicalOrders;
using Domain.MedicalFiles.MedicalRecords;

namespace Domain.MedicalFiles
{
    public class MedicalAppointment
    {
        public string            AppointmentReason { get; set; }
        public string            DiseaseHistory    { get; set; }
        public DateTime          AppointmentDate   { get; set; }
        public MedicalRecord     MedicalRecord     { get; set; }
        public MedicalNote       MedicalNote       { get; set; }
        public MedicalOrder      MedicalOrder      { get; set; }
        public MedicalBackground MedicalBackground { get; set; }
#nullable enable
        public GynecologicalBackground? GynecologicalBackground { get; set; }

        public MedicalAppointment(string appointmentReason, string diseaseHistory,
            DateTime appointmentDate, MedicalRecord medicalRecord, MedicalNote medicalNote,
            MedicalOrder medicalOrder)
        {
            AppointmentReason = appointmentReason;
            DiseaseHistory    = diseaseHistory;
            AppointmentDate   = appointmentDate;
            MedicalRecord     = medicalRecord;
            MedicalNote       = medicalNote;
            MedicalOrder      = medicalOrder;
        }
    }
}
