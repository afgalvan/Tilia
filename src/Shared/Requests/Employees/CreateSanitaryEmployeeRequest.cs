using Requests.People;

namespace Requests.Employees
{
    public class CreateSanitaryEmployeeRequest : PersonDto
    {
        public string SanitaryRoleId { get; set; }
    }
}
