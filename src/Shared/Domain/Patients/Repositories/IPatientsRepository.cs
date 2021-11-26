using Domain.SharedLib;

namespace Domain.Patients.Repositories
{
    public interface IPatientsRepository : IRepository<Patient, string>
    {
    }
}
