using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Patients;
using Domain.Patients.Repositories;

namespace Application.Patients.FindById
{
    public class PatientsFinder
    {
        private readonly IPatientsRepository _repository;

        public PatientsFinder(IPatientsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Patient> FindUserById(string id, CancellationToken cancellation)
        {
            return await _repository.FindById(id, cancellation);
        }
    }
}
