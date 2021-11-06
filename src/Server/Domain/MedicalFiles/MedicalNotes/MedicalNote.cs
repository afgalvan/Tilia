using System.Collections.Generic;
using Domain.MedicalFiles.MedicalOrders;

namespace Domain.MedicalFiles.MedicalNotes
{
    public class MedicalNote
    {
        public IList<Diagnosis> Diagnostics    { get; set; }
        public EvolutionSheet   EvolutionSheet { get; set; }
        public ManagementPlan   ManagementPlan { get; set; }
        public IList<Referral>  Referrals      { get; set; }

        public MedicalNote(string cie10, string functionalDiagnosis,
            string evolutionSheetDescription,
            string managementPlanDescription)
        {
            Diagnostics = new List<Diagnosis>();
            AddDiagnosis(cie10, functionalDiagnosis);
            EvolutionSheet = new EvolutionSheet(evolutionSheetDescription);
            ManagementPlan = new ManagementPlan(managementPlanDescription);
            Referrals      = new List<Referral>();
        }

        public void AddReferrals(string referralDepartment, string description)
        {
            Referrals.Add(new Referral(referralDepartment, description));
        }

        public void AddDiagnosis(string cie10, string functionalDiagnosis)
        {
            Diagnostics.Add(new Diagnosis(cie10, functionalDiagnosis));
        }
    }
}
