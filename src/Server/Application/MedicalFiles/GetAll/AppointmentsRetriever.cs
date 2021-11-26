using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.MedicalFiles;
using Domain.MedicalFiles.Repositories;
using Domain.Patients;
using Domain.Patients.Repositories;

namespace Application.MedicalFiles.GetAll
{
    public class AppointmentsRetriever
    {
        private readonly IMedicalAppointmentRepository _repository;

        public AppointmentsRetriever(IMedicalAppointmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<MedicalAppointment>> GetAllAppointments(CancellationToken cancellation)
        {
            return await _repository.GetAll(cancellation);
        }
    }
}
