using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.MedicalFiles.MedicalRecords
{
    public class MedicalRecord
    {
        [Key]
        public Guid Id { get; set; }

        public Anamnesis Anamnesis { get; set; }

        [ForeignKey("physical_exam_id")]
        public PhysicalExam PhysicalExams { get; set; }

        public MedicalRecord(string description)
        {
            Anamnesis = new Anamnesis(description);
        }

        public MedicalRecord()
        {
            // For EF
        }

        public void AddPhysicalExam(VitalSign vitalSignResults,
            IList<BodyPartRecord> bodyPartRecords)
        {
            PhysicalExams = new PhysicalExam(vitalSignResults, bodyPartRecords);
        }
    }
}
