using System.Collections.Generic;

namespace Domain.MedicalFiles.MedicalRecords
{
    public class PhysicalExam
    {
        public VitalSign             VitalSignResults { get; set; }
        public IList<BodyPartRecord> BodyPartRecords  { get; set; }

        public PhysicalExam(VitalSign vitalSignResults, IList<BodyPartRecord> bodyPartRecords)
        {
            VitalSignResults = vitalSignResults;
            BodyPartRecords = bodyPartRecords;
        }
    }
}
