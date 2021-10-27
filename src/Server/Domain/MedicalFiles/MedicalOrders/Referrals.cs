namespace Domain.MedicalFiles.MedicalOrders
{
    public class Referrals
    {
        public string Description { get; set; }

        public Referrals(string description)
        {
            Description = description;
        }
    }
}
