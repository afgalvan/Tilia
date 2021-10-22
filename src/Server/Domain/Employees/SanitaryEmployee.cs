using Domain.Locations;
using Domain.People;

namespace Domain.Employees
{
    public class SanitaryEmployee : Employee
    {
        public SanitaryRole SanitaryRole { get; set; }

        public SanitaryEmployee(PersonId id, PersonName names, Genre genre, Location location)
            : base(id, names, genre, location)
        {
        }
    }
}
