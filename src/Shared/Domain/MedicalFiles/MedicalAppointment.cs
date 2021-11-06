using System;
using System.Collections.Generic;
using Domain.Employees;
using Domain.MedicalFiles.Background;
using Domain.MedicalFiles.MedicalNotes;
using Domain.MedicalFiles.MedicalOrders;
using Domain.MedicalFiles.MedicalRecords;
using Domain.Patients;

namespace Domain.MedicalFiles
{
    public class MedicalAppointment
    {
        public Guid                     AppointmentId      { get; set; }
        public string                   AppointmentReason  { get; set; }
        public string                   DiseaseHistory     { get; set; }
        public DateTime                 AppointmentDate    { get; set; }
        public MedicalRecord            MedicalRecord      { get; set; }
        public MedicalNote              MedicalNote        { get; set; }
        public MedicalOrder             MedicalOrder       { get; set; }
        public Patient                  Patient            { get; set; }
        public SanitaryEmployee         DoctorCaring       { get; set; }
        public Employee                 Scheduler          { get; set; }
        public IList<MedicalBackground> MedicalBackgrounds { get; set; }
#nullable enable
        public IList<GynecologicalBackground>? GynecologicalBackgrounds { get; set; }
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
        }

        public void AddMedicalBackground(string name, bool state,
            string observation)
        {
            var medicalBackground = new MedicalBackground(name, state, observation);
            MedicalBackgrounds.Add(medicalBackground);
        }

        public void AddGynecologicalBackground(DateTime menarchy, int cycle, bool isRegular,
            bool hasDysmenorrhea, bool hasAmenorrhea, DateTime lastMenstrualPeriod,
            DateTime estimatedDateConfinement, bool hasPlanning, string method)
        {
            var gynecologicalBackground = new GynecologicalBackground(menarchy, cycle,
                isRegular, hasDysmenorrhea, hasAmenorrhea, lastMenstrualPeriod,
                estimatedDateConfinement, hasPlanning, method);
            GynecologicalBackgrounds?.Add(gynecologicalBackground);
        }

        public void AddMedicalOrder(AptitudeCertificate aptitudeCertificate)
        {
            MedicalOrder = new MedicalOrder(aptitudeCertificate);
        }

        public bool IsBetweenDates(DateTime initialDate, DateTime limitDate)
        {
            return AppointmentDate <= initialDate && AppointmentDate >= limitDate;
        }
    }
}
