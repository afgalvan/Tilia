namespace Requests.People
{
    public class PersonResponse
    {
        public string IdType    { get; set; }
        public string PersonId  { get; set; }
        public string FirstName { get; set; }
        public string LastName  { get; set; }
        public int    Age       { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
