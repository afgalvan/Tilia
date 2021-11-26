using System.Collections.Generic;
using Requests.Patients;
using SharedLib.Domain.Bus.Query;

namespace Application.MedicalFiles.GetAll
{
    public class GetAllPatientsQuery : IQuery<IEnumerable<PatientResponse>>
    {
    }
}
