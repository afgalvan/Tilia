namespace Domain.MedicalFiles.MedicalNotes
{
    public class Diagnosis
    {
        public string CIE10      { get; set; }
        public string Functional { get; set; }

        public Diagnosis(string cie10, string functional)
        {
            CIE10      = cie10;
            Functional = functional;
        }
    }
}
