using System.Collections.Generic;

namespace Requests.Appointments.MedicalNotes
{
    public class MedicalNoteDto
    {
        public string              EvolutionSheet { get; set; }
        public string              ManagementPlan { get; set; }
        public IList<DiagnosisDto> Diagnostics    { get; set; }
        public IList<ReferralDto>  Referrals      { get; set; }
    }
}
