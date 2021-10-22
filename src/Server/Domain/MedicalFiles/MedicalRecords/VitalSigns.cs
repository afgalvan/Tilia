namespace Domain.MedicalFiles.MedicalRecords
{
    public class VitalSigns
    {
        public double Temperature { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }

        public VitalSigns()
        {
        }

        public VitalSigns(double temperature, double weight, double height)
        {
            Temperature = temperature;
            Weight = weight;
            Height = height;
        }
    }
}
