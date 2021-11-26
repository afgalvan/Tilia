using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.MedicalFiles.MedicalRecords
{
    public class MedicalRecord
    {
        [Key]
        public Guid Id { get; set; }

        public Anamnesis Anamnesis { get; set; }

        public MedicalRecord(string description)
        {
            Anamnesis = new Anamnesis(description);
        }

        public MedicalRecord()
        {
            // For EF
        }
    }
}
