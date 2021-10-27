namespace Domain.MedicalFiles.MedicalNotes
{
    public class MedicalNote
    {
        public Diagnosis      Diagnosis      { get; set; }
        public EvolutionSheet EvolutionSheet { get; set; }
        public ManagementPlan ManagementPlan { get; set; }

        public MedicalNote(string CIE10, string functionalDiagnosis,
            string evolutionSheetDescription,
            string managementPlanDescription)
        {
            Diagnosis      = new Diagnosis(CIE10, functionalDiagnosis);
            EvolutionSheet = new EvolutionSheet(evolutionSheetDescription);
            ManagementPlan = new ManagementPlan(managementPlanDescription);
        }
    }
}
