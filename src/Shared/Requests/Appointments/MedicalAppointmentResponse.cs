using System;

namespace Requests.Appointments
{
    public class MedicalAppointmentResponse
    {
        public string   AppointmentReason { get; set; }
        public string   DiseaseHistory    { get; set; }
        public DateTime AppointmentDate   { get; set; }
        public string   Patient           { get; set; }
        public string   Doctor            { get; set; }
    }
}
