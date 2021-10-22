using Domain.Locations;
using Domain.People;

namespace Domain.Employees
{
    public class SanitaryEmployee : Employee
    {
        public SanitaryRole SanitaryRole { get; set; }

        public SanitaryEmployee(string code, string idType, string firstName, string lastName,
            Genre genre, string locationId, string city, string department,
            SanitaryRole sanitaryRole) : base(code, idType, firstName, lastName, genre,
            locationId, city, department)
        {
            SanitaryRole = sanitaryRole;
        }
    }
}
