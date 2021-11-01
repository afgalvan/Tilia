using System;
using Domain.Patients;
using Domain.People;

namespace Domain.Employees
{
    public class Employee : Person
    {
        public Employee(string code, string idType, string firstName, string lastName,
            Genre genre, string locationId, string city, string department) : base(code,
            idType, firstName, lastName, genre, locationId, city, department)
        {
        }

        public void ScheduleMeeting(Patient patient, DateTime dateTime)
        {
        }
    }
}
