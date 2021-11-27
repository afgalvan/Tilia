using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.MedicalFiles.MedicalNotes
{
    public class Referral
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Department  { get; set; }
        public string Description { get; set; }

        public Referral(string department, string description)
        {
            Department  = department;
            Description = description;
        }

        public Referral()
        {
            // For EF
        }
    }
}
