using Domain.Locations;
using Domain.People;

namespace Domain.Employees
{
    public class SanitaryEmployee : Employee
    {
        public SanitaryRole SanitaryRole { get; set; }

        public SanitaryEmployee(string code, string idType, string firstName, string lastName,
            Genre genre, string locationId, string city, SanitaryRole sanitaryRole,
            Department department) : base(code, idType, firstName, lastName, genre, locationId,
            city, department)
        {
            SanitaryRole = sanitaryRole;
        }

        public SanitaryEmployee()
        {
            // For EF
        }
    }
}
