using System;
using Domain.Patients;
using SharedLib.Domain.Bus.Query;

namespace Application.Patients.FindById
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
