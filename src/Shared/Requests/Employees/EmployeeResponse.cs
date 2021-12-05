using Requests.People;

namespace Requests.Employees
{
    public class EmployeeResponse : PersonResponse
    {
        public string RoleName { get; set; }
    }
}
