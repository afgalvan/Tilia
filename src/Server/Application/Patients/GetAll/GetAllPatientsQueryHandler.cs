using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MapsterMapper;
using Requests.Patients;
using SharedLib.Domain.Bus.Query;

namespace Application.Patients.GetAll
{
    public class GetAllPatientsQueryHandler
        : IQueryHandler<GetAllPatientsQuery, IEnumerable<PatientResponse>>
    {
        private readonly PatientsRetriever _patientsRetriever;
        private readonly IMapper           _mapper;

        public GetAllPatientsQueryHandler(PatientsRetriever patientsRetriever, IMapper mapper)
        {
            _patientsRetriever = patientsRetriever;
            _mapper            = mapper;
        }

        public async Task<IEnumerable<PatientResponse>> Handle(GetAllPatientsQuery request,
            CancellationToken cancellationToken)
        {
            var patients = await _patientsRetriever.GetAllUsers(cancellationToken);
            return _mapper.From(patients).AdaptToType<IEnumerable<PatientResponse>>();
        }
    }
}
