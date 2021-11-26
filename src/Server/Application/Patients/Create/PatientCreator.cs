using System.Threading;
using System.Threading.Tasks;
using Domain.Patients;
using Domain.Patients.Repositories;
using MapsterMapper;

namespace Application.Patients.Create
{
    public class PatientCreator
    {
        private readonly IPatientsRepository _repository;
        private readonly IMapper             _mapper;

        public PatientCreator(IPatientsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper     = mapper;
        }

        public async Task CreatePatient(CreatePatientCommand patientCommand,
            CancellationToken cancellation)
        {
            await _repository.Save(
                _mapper.From(patientCommand).AdaptToType<Patient>(),
                cancellation
            );
        }
    }
}
