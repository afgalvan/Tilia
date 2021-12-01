using System.Collections.Generic;

namespace Requests.Appointments.MedicalNotes
{
    public class MedicalNoteDto
    {
        public string                   EvolutionSheet  { get; set; }
        public IList<ManagementPlanDto> ManagementPlans { get; set; }
        public IList<DiagnosisDto>      Diagnostics     { get; set; }
        public IList<ReferralDto>       Referrals       { get; set; }
    }
}
