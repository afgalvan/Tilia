﻿using System;
using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<MedicalBackground> MedicalBackgrounds { get; set; }
#nullable enable
        public GynecologicalBackground? GynecologicalBackground { get; set; }

        public MedicalAppointment(string appointmentReason, string diseaseHistory,
            DateTime appointmentDate, MedicalRecord medicalRecord, MedicalNote medicalNote,
            MedicalOrder medicalOrder)
        {
            AppointmentReason = appointmentReason;
            DiseaseHistory = diseaseHistory;
            AppointmentDate = appointmentDate;
            MedicalRecord = medicalRecord;
            MedicalNote = medicalNote;
            MedicalOrder = medicalOrder;
        }

        public IEnumerable<MedicalBackground> AddMedicalBackground(string name, bool state,
            string observation)
        {
            var medicalBackground = new MedicalBackground(name, state, observation);
            return MedicalBackgrounds.Append(medicalBackground);
        }
    }
}
