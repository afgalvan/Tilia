using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.MedicalFiles;
using Domain.MedicalFiles.Repositories;
using Domain.Patients.Repositories;
using Requests.Dashboard;

namespace Application.Dashboard.GetAll
{
    public class StatisticsRetriever
    {
        private readonly IAttentionHistoryRepository _attentionHistoryRepository;
        private readonly IPatientsRepository         _patientsRepository;

        public StatisticsRetriever(IAttentionHistoryRepository attentionHistoryRepository,
            IPatientsRepository patientsRepository)
        {
            _attentionHistoryRepository = attentionHistoryRepository;
            _patientsRepository         = patientsRepository;
        }

        public async Task<DashboardInformationResponse> GetDashboardStatistics(
            CancellationToken cancellation)
        {
            Task<int> getPatientsTask = _patientsRepository.CountPatients(cancellation);
            Task<IEnumerable<AttentionHistory>> attentionsTask = _attentionHistoryRepository
                .GetAll(cancellation);
            await Task.WhenAll(getPatientsTask, attentionsTask);
            int[] historic = (await attentionsTask).Select(history => history.Attendants).ToArray();

            return new DashboardInformationResponse
            {
                PatientsAmount    = await getPatientsTask,
                AttentionHistoric = historic,
                GrowPercent = ComputeGrowthPercentage(historic[^1], historic[^2])
            };
        }

        private static string ComputeGrowthPercentage(int newValue, int original)
        {
            double growth = (newValue - original) / (double)original * 100.0;
            char   sign   = growth > 0 ? '+' : ' ';
            return $"{sign}{growth}%";
        }
    }
}
