using System.Collections.Generic;
using Requests.Appointments;

namespace Requests.Dashboard
{
    public class DashboardInformationResponse
    {
        public int                                     PatientsAmount          { get; set; }
        public string                                  GrowPercent             { get; set; }
        public IEnumerable<int>                        AttentionHistoric       { get; set; }
        public IEnumerable<MedicalAppointmentResponse> RecentAppointments      { get; set; }
        public IDictionary<string, double>             AptitudeCertificatesMap { get; set; }
    }
}
