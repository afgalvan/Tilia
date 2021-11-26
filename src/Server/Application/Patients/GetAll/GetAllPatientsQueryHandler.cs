using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Patients;
using SharedLib.Domain.Bus.Query;

namespace Application.Patients.GetAll
{
    public class GetAllPatientsQueryHandler
        : IQueryHandler<GetAllPatientsQuery, IEnumerable<Patient>>
    {
        private readonly PatientsRetriever _patientsRetriever;

        public GetAllPatientsQueryHandler(PatientsRetriever patientsRetriever)
        {
            _patientsRetriever = patientsRetriever;
        }

        public async Task<IEnumerable<Patient>> Handle(GetAllPatientsQuery request,
            CancellationToken cancellationToken)
        {
            return await _patientsRetriever.GetAllUsers(cancellationToken);
        }
    }
}
