using System.Threading;
using System.Threading.Tasks;
using Domain.SharedLib;

namespace Domain.Patients.Repositories
{
    public interface IPatientsRepository : IRepository<Patient, string>
    {
        Task<int> CountPatients(CancellationToken cancellation);
    }
}
