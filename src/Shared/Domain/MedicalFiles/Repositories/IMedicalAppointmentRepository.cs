using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.SharedLib;

namespace Domain.MedicalFiles.Repositories
{
    public interface IMedicalAppointmentRepository : IRepository<MedicalAppointment, Guid>
    {
        Task<List<MedicalAppointment>> GetByPatientId(string patientId, CancellationToken cancellation);
    }
}
