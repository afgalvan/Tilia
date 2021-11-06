using System;
using System.Collections.Generic;

namespace Domain.MedicalFiles.MedicalRecords
{
    public class MedicalRecord
    {
        public Guid         Id            { get; set; }
        public Anamnesis    Anamnesis     { get; set; }
        public PhysicalExam PhysicalExams { get; set; }

        public MedicalRecord(string description)
        {
            Anamnesis = new Anamnesis(description);
        }

        public void AddPhysicalExam(VitalSign vitalSignResults,
            IList<BodyPartRecord> bodyPartRecords)
        {
            PhysicalExams = new PhysicalExam(vitalSignResults, bodyPartRecords);
        }
    }
}
