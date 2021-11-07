using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.MedicalFiles.MedicalRecords
{
    public class PhysicalExam
    {
        [Key]
        public Guid Id { get; set; }

        public VitalSign             VitalSignResults { get; set; }
        public IList<BodyPartRecord> BodyPartRecords  { get; set; }

        public PhysicalExam(VitalSign vitalSignResults, IList<BodyPartRecord> bodyPartRecords)
        {
            VitalSignResults = vitalSignResults;
            BodyPartRecords  = bodyPartRecords;
        }

        public PhysicalExam()
        {
            // For EF
        }
    }
}
