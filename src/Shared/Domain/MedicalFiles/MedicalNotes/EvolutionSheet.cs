namespace Domain.MedicalFiles.MedicalNotes
{
    public class EvolutionSheet
    {
        public string Description { get; set; }

        public EvolutionSheet(string description)
        {
            Description = description;
        }
    }
}
