using System;

namespace Domain.Patients
{
    public class SportsData
    {
        public string    Sport              { get; set; }
        public string    Modality           { get; set; }
        public string    Coach              { get; set; }
        public DateTime  StartDate          { get; set; }
        public bool      ContinuousTraining { get; set; }
        public bool      TrainingPlan       { get; set; }
        public Dominance Dominance          { get; set; }

        public SportsData(string sport, string coach, DateTime startDate, Dominance dominance)
        {
            Sport     = sport;
            Coach     = coach;
            StartDate = startDate;
            Dominance = dominance;
        }

        public SportsData()
        {
        }
    }
}
