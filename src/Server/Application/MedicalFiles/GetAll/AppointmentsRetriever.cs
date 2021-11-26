using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Patients;
using Domain.Patients.Repositories;

namespace Application.MedicalFiles.GetAll
{
    public class AppointmentsRetriever
    {
        private readonly IPatientsRepository _repository;

        public AppointmentsRetriever(IPatientsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Patient>> GetAllUsers(CancellationToken cancellation)
        {
            return await _repository.GetAll(cancellation);
        }
    }
}
