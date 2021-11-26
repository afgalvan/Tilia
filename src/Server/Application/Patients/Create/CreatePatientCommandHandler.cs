using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SharedLib.Domain.Bus.Command;

namespace Application.Patients.Create
{
    public class CreatePatientCommandHandler : ICommandHandler<CreatePatientCommand, Unit>
    {
        private readonly PatientCreator _patientCreator;

        public CreatePatientCommandHandler(PatientCreator patientCreator)
        {
            _patientCreator = patientCreator;
        }

        public async Task<Unit> Handle(CreatePatientCommand request,
            CancellationToken cancellationToken)
        {
            await _patientCreator.CreatePatient(request, cancellationToken);
            return Unit.Value;
        }
    }
}
