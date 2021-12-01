using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.MedicalFiles.Repositories;

namespace Application.MedicalFiles.Remove
{
    public class AppointmentRemover
    {
        private readonly IMedicalAppointmentRepository _repository;

        public AppointmentRemover(IMedicalAppointmentRepository repository)
        {
            _repository = repository;
        }

        public async Task RemoveAppointment(string appointmentId, CancellationToken cancellation)
        {
            await _repository.RemoveById(Guid.Parse(appointmentId), cancellation);
        }
    }
}
