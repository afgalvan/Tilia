using Domain.Locations;
using Domain.People;

namespace Domain.Employees
{
    public class Employee : Person
    {
        public Employee(PersonId id, PersonName names, Genre genre, Location location) : base(id, names, genre, location)
        {
        }
    }
}
