namespace Domain.MedicalFiles.Background
{
    public class MedicalBackground
    {
        public string Name         { get; set; }
        public bool   State        { get; set; }
        public string Observations { get; set; }

        public MedicalBackground(string name, bool state, string observations)
        {
            Name = name;
            State = state;
            Observations = observations;
        }
    }
}
