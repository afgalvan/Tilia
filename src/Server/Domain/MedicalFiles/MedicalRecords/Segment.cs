using System.Collections.Generic;

namespace Domain.MedicalFiles.MedicalRecords
{
    public class Segment
    {
        public IEnumerable<string>  PostureObservations { get; set; }
        public string NeckObservation { get; set; }
        public IEnumerable<string> UpperMemberObservations { get; set; }
        public IEnumerable<string> ColumnObservations { get; set; }
        public IEnumerable<string> LowerMemberObservations { get; set; }

        public Segment()
        {
        }

        public Segment(IEnumerable<string> postureObservations, string neckObservation, IEnumerable<string> upperMemberObservations, IEnumerable<string> columnObservations, IEnumerable<string> lowerMemberObservations)
        {
            PostureObservations = postureObservations;
            NeckObservation = neckObservation;
            UpperMemberObservations = upperMemberObservations;
            ColumnObservations = columnObservations;
            LowerMemberObservations = lowerMemberObservations;
        }
    }
}
