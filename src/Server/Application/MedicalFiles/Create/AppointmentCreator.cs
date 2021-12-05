using System.Threading;
using System.Threading.Tasks;
using Domain.MedicalFiles;
using Domain.MedicalFiles.Repositories;

namespace Application.MedicalFiles.Create
{
    public class AppointmentCreator
    {
        private readonly IMedicalAppointmentRepository _appointmentRepository;
        private readonly IAttentionHistoryRepository _attentionHistory;

        public AppointmentCreator(IMedicalAppointmentRepository appointmentRepository, IAttentionHistoryRepository attentionHistory)
        {
            _appointmentRepository = appointmentRepository;
            _attentionHistory = attentionHistory;
        }

        public async Task CreateAppointment(string patientId, string doctorId,
            MedicalAppointment medicalAppointment,
            CancellationToken cancellation)
        {
            await _appointmentRepository.Save(patientId, doctorId, medicalAppointment, cancellation);
            await _attentionHistory.Save(medicalAppointment.AppointmentId, cancellation);
        }
    }
}
