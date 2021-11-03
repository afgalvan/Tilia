using System;
using Domain.Patients;

namespace Domain.Meetings
{
    public class Meeting
    {
        public        DateTime DateTime { get; set; }
        public        Patient  Patient  { get; set; }
        public static TimeSpan MinimumMeetingDaysBetween = new(5);

        public Meeting(DateTime dateTime, Patient patient)
        {
            DateTime = dateTime;
            Patient  = patient;
        }
    }
}
