using System;
using Requests.People;

namespace Requests.Patients
{
    public class CreatePatientRequest : PersonDto
    {
        public string   Occupation         { get; set; }
        public string   Studies            { get; set; }
        public string   Sport              { get; set; }
        public string   Modality           { get; set; }
        public string   Coach              { get; set; }
        public DateTime StartDate          { get; set; }
        public bool     ContinuousTraining { get; set; }
        public bool     TrainingPlan       { get; set; }
        public int      Dominance          { get; set; }
        public string   Address            { get; set; }
        public string   LivingCity         { get; set; }
        public int      Stratum            { get; set; }
        public string   PhoneNumber        { get; set; }
        public string   Landline           { get; set; }
    }
}
