using System;
using Requests.Appointments.MedicalNotes;

namespace Requests.Appointments
{
    public class CreateMedicalAppointmentRequest
    {
        public string         AppointmentReason    { get; set; }
        public string         DiseaseHistory       { get; set; }
        public DateTime       AppointmentDate      { get; set; }
        public string         AnamnesisDescription { get; set; }
        public MedicalNoteDto MedicalNote          { get; set; }
        public string         PatientId            { get; set; }
        public string         DoctorId             { get; set; }
    }
}
