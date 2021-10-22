using System.Collections.Generic;

namespace Domain.MedicalFiles
{
    public class MedicalFile
    {
        public IEnumerable<MedicalAppointment> MedicalAppointments { get; set; }
    }
}
