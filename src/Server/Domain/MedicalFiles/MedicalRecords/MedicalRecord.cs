namespace Domain.MedicalFiles.MedicalRecords
{
    public class MedicalRecord
    {
        public Anamnesis    Anamnesis    { get; set; }
        public PhysicalExam PhysicalExam { get; set; }

        public MedicalRecord(Anamnesis anamnesis)
        {
            Anamnesis = anamnesis;
        }
    }
}
