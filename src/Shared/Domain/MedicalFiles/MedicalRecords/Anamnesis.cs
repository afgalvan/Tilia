namespace Domain.MedicalFiles.MedicalRecords
{
    public class Anamnesis
    {
        public string Description { get; set; }

        public Anamnesis(string description)
        {
            Description = description;
        }

        public Anamnesis()
        {
            // For EF
        }
    }
}
