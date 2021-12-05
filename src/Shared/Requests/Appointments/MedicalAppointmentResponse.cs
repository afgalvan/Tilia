using System;

namespace Requests.Appointments
{
    public class MedicalAppointmentResponse
    {
        public int      Index             { get; set; }
        public Guid     AppointmentId     { get; set; }
        public string   AppointmentReason { get; set; }
        public DateTime AppointmentDate   { get; set; }
        public string   Patient           { get; set; }
        public string   Doctor            { get; set; }
    }
}
