using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.MedicalFiles.MedicalNotes
{
    public class Diagnosis
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string CIE10      { get; set; }
        public string Functional { get; set; }

        public Diagnosis(string cie10, string functional)
        {
            CIE10      = cie10;
            Functional = functional;
        }

        public Diagnosis()
        {
            // For EF
        }
    }
}
