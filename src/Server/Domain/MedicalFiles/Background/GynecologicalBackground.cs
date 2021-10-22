using System;

namespace Domain.MedicalFiles.Background
{
    public class GynecologicalBackground
    {
        public DateTime Menarchy                 { get; set; }
        public int      Cycle                    { get; set; }
        public bool     IsRegular                { get; set; }
        public bool     HasDysmenorrhea          { get; set; }
        public bool     HasAmenorrhea            { get; set; }
        public DateTime LastMenstrualPeriod      { get; set; }
        public DateTime EstimatedDateConfinement { get; set; }
        public bool     HasPlanning              { get; set; }
        public string   Method                   { get; set; }
    }
}
