using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.SharedLib;

namespace Domain.MedicalFiles.Repositories
{
    public interface IMedicalAppointmentRepository : IRepository<MedicalAppointment, Guid>
    {
        Task Save(string patientId, string doctorId, MedicalAppointment appointment, CancellationToken cancellation);
        Task<List<MedicalAppointment>> GetByPatientId(string patientId, CancellationToken cancellation);
        Task ToggleAppointmentState(Guid appointmentId, CancellationToken cancellation);

        Task<IEnumerable<MedicalAppointment>> GetAll(CancellationToken cancellation,
            bool withFilter);
    }
}
