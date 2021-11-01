using System;
using Domain.Patients;

namespace Domain.Meetings
{
    public class Meeting
    {
        public DateTime DateTime { get; set; }
        public Patient  Patient  { get; set; }
    }
}
