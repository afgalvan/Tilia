using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.MedicalFiles.MedicalNotes
{
    public class EvolutionSheet
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Description { get; set; }

        public EvolutionSheet(string description)
        {
            Description = description;
        }

        public EvolutionSheet()
        {
            // For EF
        }
    }
}
