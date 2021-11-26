using System;
using Domain.SharedLib;

namespace Domain.MedicalFiles.Repositories
{
    public interface IMedicalAppointment : IRepository<MedicalAppointment, Guid>
    {
    }
}
