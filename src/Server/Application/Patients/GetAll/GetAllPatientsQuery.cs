using System.Collections.Generic;
using Domain.Patients;
using SharedLib.Domain.Bus.Query;

namespace Application.Patients.GetAll
{
    public class GetAllPatientsQuery : IQuery<IEnumerable<Patient>>
    {
    }
}
