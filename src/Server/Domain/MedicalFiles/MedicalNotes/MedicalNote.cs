namespace Domain.MedicalFiles.MedicalNotes
{
    public class MedicalNote
    {
        public Diagnosis      Diagnosis      { get; set; }
        public EvolutionSheet EvolutionSheet { get; set; }
        public ManagementPlan ManagementPlan { get; set; }

        public MedicalNote(Diagnosis diagnosis, EvolutionSheet evolutionSheet,
            ManagementPlan managementPlan)
        {
            Diagnosis      = diagnosis;
            EvolutionSheet = evolutionSheet;
            ManagementPlan = managementPlan;
        }
    }
}
