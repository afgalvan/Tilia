using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.MedicalFiles.MedicalNotes
{
    public class ManagementPlan
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Description { get; set; }

        public ManagementPlan(string description)
        {
            Description = description;
        }

        public ManagementPlan()
        {
            // For EF
        }
    }
}
