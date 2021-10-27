namespace Domain.MedicalFiles.MedicalOrders
{
    public class Inability
    {
        public string Description { get; set; }

        public Inability(string description)
        {
            Description = description;
        }
    }
}
