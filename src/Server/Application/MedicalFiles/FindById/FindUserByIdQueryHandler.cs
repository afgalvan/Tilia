using System.Threading;
using System.Threading.Tasks;
using Domain.Patients;
using SharedLib.Domain.Bus.Query;

namespace Application.MedicalFiles.FindById
{
    public class FindUserByIdQueryHandler : IQueryHandler<Patients.FindById.FindPatientByIdQuery, Patient>
    {
        private readonly AppointmentFinder _appointmentFinder;

        public FindUserByIdQueryHandler(AppointmentFinder appointmentFinder)
        {
            _appointmentFinder = appointmentFinder;
        }

        public async Task<Patient> Handle(Patients.FindById.FindPatientByIdQuery request, CancellationToken cancellationToken)
        {
            return await _appointmentFinder.FindUserById(request.Id, cancellationToken);
        }
    }
}
