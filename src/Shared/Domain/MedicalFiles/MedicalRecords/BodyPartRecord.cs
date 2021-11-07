using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.MedicalFiles.MedicalRecords
{
    public class BodyPartRecord
    {
        [Key]
        public Guid   Id           { get; set; }
        public string Segment      { get; set; }
        public string Region       { get; set; }
        public string Observations { get; set; }
    }
}
