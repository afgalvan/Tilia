using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.SharedLib;

namespace Domain.MedicalFiles.Repositories
{
    public interface IAttentionHistoryRepository : IRepository<AttentionHistory, int>
    {
        public Task Save(Guid appointmentId, CancellationToken cancellation);
    }
}
