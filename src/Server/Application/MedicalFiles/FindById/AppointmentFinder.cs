using System.Threading;
using System.Threading.Tasks;
using Domain.Patients;
using Domain.Patients.Repositories;

namespace Application.MedicalFiles.FindById
{
    public class AppointmentFinder
    {
        private readonly IPatientsRepository _repository;

        public AppointmentFinder(IPatientsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Patient> FindUserById(string id, CancellationToken cancellation)
        {
            return await _repository.FindById(id, cancellation);
        }
    }
}
