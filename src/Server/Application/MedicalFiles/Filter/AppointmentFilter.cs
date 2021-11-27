using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.MedicalFiles;
using Domain.MedicalFiles.Repositories;

namespace Application.MedicalFiles.Filter
{
    public class AppointmentFilter
    {
        private readonly IMedicalAppointmentRepository _repository;

        public AppointmentFilter(IMedicalAppointmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IReadOnlyList<MedicalAppointment>> FilterByPatientId(string id,
            CancellationToken cancellation)
        {
            return await _repository.GetByPatientId(id, cancellation);
        }

    }
}
