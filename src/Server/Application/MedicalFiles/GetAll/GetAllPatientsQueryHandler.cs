using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MapsterMapper;
using Requests.Patients;
using SharedLib.Domain.Bus.Query;

namespace Application.MedicalFiles.GetAll
{
    public class GetAllPatientsQueryHandler
        : IQueryHandler<GetAllPatientsQuery, IEnumerable<PatientResponse>>
    {
        private readonly AppointmentsRetriever _appointmentsRetriever;
        private readonly IMapper           _mapper;

        public GetAllPatientsQueryHandler(AppointmentsRetriever appointmentsRetriever, IMapper mapper)
        {
            _appointmentsRetriever = appointmentsRetriever;
            _mapper            = mapper;
        }

        public async Task<IEnumerable<PatientResponse>> Handle(GetAllPatientsQuery request,
            CancellationToken cancellationToken)
        {
            var patients = await _appointmentsRetriever.GetAllUsers(cancellationToken);
            return _mapper.From(patients).AdaptToType<IEnumerable<PatientResponse>>();
        }
    }
}
