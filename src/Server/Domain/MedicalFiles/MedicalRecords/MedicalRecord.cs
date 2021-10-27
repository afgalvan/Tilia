using System.Collections.Generic;

namespace Domain.MedicalFiles.MedicalRecords
{
    public class MedicalRecord
    {
        public Anamnesis Anamnesis { get; set; }
        public IList<PhysicalExam> PhysicalExams { get; set; }

        public MedicalRecord(string description)
        {
            Anamnesis = new Anamnesis(description);
            PhysicalExams = new List<PhysicalExam>();
        }

        public void AddPhysicalExam(VitalSign vitalSignResults,
            IList<BodyPartRecord> bodyPartRecords)
        {
            var physicalExam = new PhysicalExam(vitalSignResults, bodyPartRecords);
            PhysicalExams.Add(physicalExam);
        }
    }
}
