using System;
using System.ComponentModel.DataAnnotations;
using Domain.Patients;

namespace Domain.Meetings
{
    public class Meeting
    {
        [Key]
        public                 Guid     Id       { get; set; }
        public                 DateTime DateTime { get; set; }
        public                 Patient  Patient  { get; set; }
        public static readonly TimeSpan MinimumMeetingDaysBetween = new(5);

        public Meeting(DateTime dateTime, Patient patient)
        {
            DateTime = dateTime;
            Patient  = patient;
        }
    }
}
