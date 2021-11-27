using System.Threading;
using System.Threading.Tasks;
using Domain.MedicalFiles;
using Domain.MedicalFiles.Repositories;

namespace Application.MedicalFiles.Create
{
    public class AppointmentCreator
    {
        private readonly IMedicalAppointmentRepository _repository;

        public AppointmentCreator(IMedicalAppointmentRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateAppointment(string patientId, string doctorId,
            MedicalAppointment medicalAppointment,
            CancellationToken cancellation)
        {
            await _repository.Save(patientId, doctorId, medicalAppointment, cancellation);
        }
    }
}
