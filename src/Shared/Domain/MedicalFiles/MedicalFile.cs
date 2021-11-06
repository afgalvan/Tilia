using System.Collections.Generic;

namespace Domain.MedicalFiles
{
    public class MedicalFile
    {
        public IList<MedicalAppointment> MedicalAppointments { get; set; }

        public void AddMedicalAppointment(MedicalAppointment medicalAppointment)
        {
            MedicalAppointments.Add(medicalAppointment);
        }
    }
}
