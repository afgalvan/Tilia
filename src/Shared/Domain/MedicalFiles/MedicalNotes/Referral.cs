namespace Domain.MedicalFiles.MedicalNotes
{
    public class Referral
    {
        public string Department  { get; set; }
        public string Description { get; set; }

        public Referral(string department, string description)
        {
            Department  = department;
            Description = description;
        }
    }
}
