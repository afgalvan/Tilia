using System;

namespace Requests.People
{
    public class PersonDto
    {
        public string   PersonId  { get; set; }
        public int      IdType    { get; set; }
        public string   FirstName { get; set; }
        public string   LastName  { get; set; }
        public int      Genre     { get; set; }
        public string   City      { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
