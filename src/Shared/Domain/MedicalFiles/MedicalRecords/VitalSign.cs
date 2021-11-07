namespace Domain.MedicalFiles.MedicalRecords
{
    public class VitalSign
    {
        public double Temperature { get; set; }
        public double Weight      { get; set; }
        public double Height      { get; set; }

        public VitalSign(double temperature, double weight, double height)
        {
            Temperature = temperature;
            Weight      = weight;
            Height      = height;
        }

        public VitalSign()
        {
            // For EF
        }
    }
}
