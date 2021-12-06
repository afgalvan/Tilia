using System;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Locations;
using Domain.Meetings;
using Domain.Patients;
using Domain.People;

namespace Domain.Employees
{
    [Table("employees")]
    public class Employee : Person
    {
        public Employee(string personId, string idType, string firstName, string lastName,
            Genre genre, string locationId, string city, Department department) : base(personId,
            idType, firstName, lastName, genre, locationId, city, department)
        {
        }

        public Employee()
        {
            // For EF
        }

        public Meeting ScheduleMeeting(DateTime dateTime, Patient patient)
        {
            if (dateTime < DateTime.Now.Add(Meeting.MinimumMeetingDaysBetween))
            {
                throw new ArgumentException(
                    "La fecha sobrepasa el mínimo de días para una cita");
            }

            return new Meeting(dateTime, patient);
        }
    }
}
