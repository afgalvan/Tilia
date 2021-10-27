using System;
using System.Collections.Generic;
using Domain.MedicalFiles.Background;
using Domain.MedicalFiles.MedicalNotes;
using Domain.MedicalFiles.MedicalOrders;
using Domain.MedicalFiles.MedicalRecords;

namespace Domain.MedicalFiles
{
    public class MedicalAppointment
    {
        public string AppointmentReason { get; set; }
        public string DiseaseHistory { get; set; }
        public DateTime AppointmentDate { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
        public MedicalNote MedicalNote { get; set; }
        public MedicalOrder MedicalOrder { get; set; }
        public IList<MedicalBackground> MedicalBackgrounds { get; set; }
#nullable enable
        public IList<GynecologicalBackground> GynecologicalBackgrounds { get; set; }
#nullable disable

        public MedicalAppointment(string appointmentReason, string diseaseHistory,
            DateTime appointmentDate, MedicalRecord medicalRecord, MedicalNote medicalNote)
        {
            AppointmentReason  = appointmentReason;
            DiseaseHistory     = diseaseHistory;
            AppointmentDate    = appointmentDate;
            MedicalRecord      = medicalRecord;
            MedicalNote        = medicalNote;
            MedicalBackgrounds = new List<MedicalBackground>();
            GynecologicalBackgrounds = new List<GynecologicalBackground>();
        }

        public void AddMedicalBackground(string name, bool state,
            string observation)
        {
            var medicalBackground = new MedicalBackground(name, state, observation);
            MedicalBackgrounds.Add(medicalBackground);
        }

        public void AddGynecologycalBackground(DateTime menarchy, int cycle, bool isRegular,
            bool hasDysmenorrhea, bool hasAmenorrhea, DateTime lastMenstrualPeriod,
            DateTime estimatedDateConfinement, bool hasPlanning, string method)
        {
            var gynecologicalBackground = new GynecologicalBackground(menarchy, cycle,
                isRegular, hasDysmenorrhea, hasAmenorrhea, lastMenstrualPeriod,
                estimatedDateConfinement, hasPlanning, method);

            GynecologicalBackgrounds.Add(gynecologicalBackground);
        }
      
        public void AddMedicalOrder(AptitudeCertificate aptitudeCertificate)
        {
            MedicalOrder = new MedicalOrder(aptitudeCertificate);
        }
    }
}
