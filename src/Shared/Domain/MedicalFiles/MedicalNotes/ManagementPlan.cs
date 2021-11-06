namespace Domain.MedicalFiles.MedicalNotes
{
    public class ManagementPlan
    {
        public string Description { get; set; }

        public ManagementPlan(string description)
        {
            Description = description;
        }
    }
}
