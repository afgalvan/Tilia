using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.MedicalFiles.Background
{
    public class GynecologicalBackground
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime Menarchy                 { get; set; }
        public int      Cycle                    { get; set; }
        public bool     IsRegular                { get; set; }
        public bool     HasDysmenorrhea          { get; set; }
        public bool     HasAmenorrhea            { get; set; }
        public DateTime LastMenstrualPeriod      { get; set; }
        public DateTime EstimatedDateConfinement { get; set; }
        public bool     HasPlanning              { get; set; }
        public string   Method                   { get; set; }

        public GynecologicalBackground(DateTime menarchy, int cycle, bool isRegular,
            bool hasDysmenorrhea, bool hasAmenorrhea, DateTime lastMenstrualPeriod,
            DateTime estimatedDateConfinement, bool hasPlanning, string method)
        {
            Menarchy                 = menarchy;
            Cycle                    = cycle;
            IsRegular                = isRegular;
            HasDysmenorrhea          = hasDysmenorrhea;
            HasAmenorrhea            = hasAmenorrhea;
            LastMenstrualPeriod      = lastMenstrualPeriod;
            EstimatedDateConfinement = estimatedDateConfinement;
            HasPlanning              = hasPlanning;
            Method                   = method;
        }

        public GynecologicalBackground()
        {
            // For EF
        }
    }
}
