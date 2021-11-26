using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.SharedLib;

namespace Domain.MedicalFiles.Repositories
{
    public interface IMedicalAppointmentRepository : IRepository<MedicalAppointment, Guid>
    {
        Task Save(string id, MedicalAppointment appointment, CancellationToken cancellation);
        Task<List<MedicalAppointment>> GetByPatientId(string patientId, CancellationToken cancellation);
    }
}
