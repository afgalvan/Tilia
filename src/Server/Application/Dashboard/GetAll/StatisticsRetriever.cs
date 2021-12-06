using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.MedicalFiles;
using Domain.MedicalFiles.Repositories;
using Domain.Patients.Repositories;
using MapsterMapper;
using Requests.Appointments;
using Requests.Dashboard;

namespace Application.Dashboard.GetAll
{
    public class StatisticsRetriever
    {
        private readonly IAttentionHistoryRepository   _attentionHistoryRepository;
        private readonly IMedicalAppointmentRepository _appointmentRepository;
        private readonly IPatientsRepository           _patientsRepository;
        private readonly IMapper                       _mapper;

        public StatisticsRetriever(IAttentionHistoryRepository attentionHistoryRepository,
            IPatientsRepository patientsRepository,
            IMedicalAppointmentRepository appointmentRepository, IMapper mapper)
        {
            _attentionHistoryRepository = attentionHistoryRepository;
            _patientsRepository         = patientsRepository;
            _appointmentRepository      = appointmentRepository;
            _mapper                     = mapper;
        }

        public async Task<DashboardInformationResponse> GetDashboardStatistics(
            CancellationToken cancellation)
        {
            Task<int> getPatientsTask = _patientsRepository.CountPatients(cancellation);
            Task<IEnumerable<AttentionHistory>> attentionsTask = _attentionHistoryRepository
                .GetAll(cancellation);
            Task<IEnumerable<MedicalAppointment>> filteredAppointmentsTask = _appointmentRepository
                .GetAll(cancellation);
            Task<IEnumerable<MedicalAppointment>> appointmentsTask = _appointmentRepository
                .GetAll(cancellation, withFilter: false);

            await Task.WhenAll(getPatientsTask, attentionsTask, filteredAppointmentsTask, appointmentsTask);
            int[] historic = (await attentionsTask).Select(history => history.Attendants)
                .ToArray();

            return new DashboardInformationResponse
            {
                PatientsAmount    = await getPatientsTask,
                AttentionHistoric = historic,
                GrowPercent       = ComputeGrowthPercentage(historic[^1], historic[^2]),
                RecentAppointments = _mapper.From((await filteredAppointmentsTask).Take(3))
                    .AdaptToType<IEnumerable<MedicalAppointmentResponse>>(),
                AptitudeCertificatesMap = MapPatientsAptitudes(await appointmentsTask)
            };
        }

        private static string ComputeGrowthPercentage(int newValue, int original)
        {
            double growth = (newValue - original) / (double)original * 100.0;
            char   sign   = growth > 0 ? '+' : ' ';
            return $"{sign}{growth}%";
        }

        private static IDictionary<string, double> MapPatientsAptitudes(
            IEnumerable<MedicalAppointment> appointments)
        {
            return appointments.GroupBy(appointment => appointment.AptitudeCertificate)
                .ToDictionary(g => g.Key.AsString(), g => (double)g.Count());
        }
    }
}
