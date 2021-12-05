using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.MedicalFiles
{
    public class AttentionHistory
    {
        [Key]
        public int Id { get; set; }

        public int      Attendants    { get; set; }
        public DateTime Date          { get; set; } = DateTime.Now;
        public Guid     AppointmentId { get; set; }

        public AttentionHistory(int attendants, Guid appointmentId)
        {
            Attendants    = attendants;
            AppointmentId = appointmentId;
        }

        public AttentionHistory()
        {
        }
    }
}
