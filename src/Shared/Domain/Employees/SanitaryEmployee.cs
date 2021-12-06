using System.ComponentModel.DataAnnotations.Schema;
using Domain.Locations;
using Domain.People;

namespace Domain.Employees
{
    [Table("sanitary_employees")]
    public class SanitaryEmployee : Employee
    {
        public SanitaryRole SanitaryRole { get; set; }

        public SanitaryEmployee(string personId, string idType, string firstName, string lastName,
            Genre genre, string locationId, string city, SanitaryRole sanitaryRole,
            Department department) : base(personId, idType, firstName, lastName, genre, locationId,
            city, department)
        {
            SanitaryRole = sanitaryRole;
        }

        public SanitaryEmployee()
        {
            // For EF
        }

        public override string ToString()
        {
            return FirstName + LastName;
        }
    }
}
