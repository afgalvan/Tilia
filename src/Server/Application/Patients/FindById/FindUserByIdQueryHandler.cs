using System.Threading;
using System.Threading.Tasks;
using Domain.Patients;
using SharedLib.Domain.Bus.Query;

namespace Application.Patients.FindById
{
    public class FindUserByIdQueryHandler : IQueryHandler<FindPatientByIdQuery, Patient>
    {
        private readonly PatientsFinder _patientsFinder;

        public FindUserByIdQueryHandler(PatientsFinder patientsFinder)
        {
            _patientsFinder = patientsFinder;
        }

        public async Task<Patient> Handle(FindPatientByIdQuery request, CancellationToken cancellationToken)
        {
            return await _patientsFinder.FindUserById(request.Id, cancellationToken);
        }
    }
}
