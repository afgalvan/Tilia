namespace Domain.People
{
    public class PersonName
    {
        public string FirstName { get; set; }
        public string LastName  { get; set; }

        public PersonName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName  = lastName;
        }
    }
}
