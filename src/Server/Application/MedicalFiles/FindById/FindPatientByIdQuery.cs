using Domain.Patients;
using SharedLib.Domain.Bus.Query;

namespace Application.MedicalFiles.FindById
{
    public class FindPatientByIdQuery : IQuery<Patient>
    {
        public string Id { get; }

        public FindPatientByIdQuery(string id)
        {
            Id = id;
        }
    }
}
