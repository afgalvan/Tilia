namespace Requests.Patients
{
    public class PatientResponse
    {
        public string IdType    { get; set; }
        public string PersonId  { get; set; }
        public string FirstName { get; set; }
        public string LastName  { get; set; }
        public int    Age       { get; set; }
        public string Sport     { get; set; }
    }
}
