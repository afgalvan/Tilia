using System;
using System.Collections.Generic;
using System.Linq;
using Domain.MedicalFiles;
using Domain.People;

namespace Domain.Patients
{
    public class Patient : Person
    {
        public string      Occupation  { get; set; }
        public string      Studies     { get; set; }
        public SportsData  SportsData  { get; set; }
        public ContactData ContactData { get; set; }
        public MedicalFile MedicalFile { get; set; }

        public Patient(string code, string idType, string firstName, string lastName,
            Genre genre, string locationId, string city, string department,
            SportsData sportsData, ContactData contactData) : base(code, idType, firstName,
            lastName, genre, locationId, city, department)
        {
            SportsData  = sportsData;
            ContactData = contactData;
        }

        public IEnumerable<MedicalAppointment> GetMedicalAppointmentsBetweenDates(
            DateTime initialDate,
            DateTime limitDate)
        {
            return MedicalFile.MedicalAppointments.Where(appointment =>
                appointment.IsBetweenDates(initialDate, limitDate)
            );
        }
    }
}
