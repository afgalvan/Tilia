using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.MedicalFiles.Repositories;

namespace Application.MedicalFiles.Toggle
{
    public class AppointmentToggler
    {
        private readonly IMedicalAppointmentRepository _appointmentRepository;
        private readonly IAttentionHistoryRepository   _attentionHistoryRepository;

        public AppointmentToggler(IMedicalAppointmentRepository appointmentRepository,
            IAttentionHistoryRepository attentionHistoryRepository)
        {
            _appointmentRepository      = appointmentRepository;
            _attentionHistoryRepository = attentionHistoryRepository;
        }

        public async Task ToggleAppointmentState(string appointmentId,
            CancellationToken cancellation)
        {
            Guid id = Guid.Parse(appointmentId);
            await _appointmentRepository.ToggleAppointmentState(id,
                cancellation);
            await _attentionHistoryRepository.Save(id, cancellation);
        }
    }
}
