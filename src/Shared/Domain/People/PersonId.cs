namespace Domain.People
{
    public class PersonId
    {
        public string Code   { get; set; }
        public string IdType { get; set; }

        public PersonId(string code, string idType)
        {
            Code   = code;
            IdType = idType;
        }
    }
}
