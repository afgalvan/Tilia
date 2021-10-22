using Domain.People;

namespace Domain.Patients
{
    public class Patient : Person
    {
        public string     Occupation { get; set; }
        public string     Studies    { get; set; }
        public SportsData SportsData { get; set; }

    }
}
