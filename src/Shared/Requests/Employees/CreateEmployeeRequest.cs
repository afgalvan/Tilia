using System;
using Requests.People;

namespace Requests.Employees
{
    public class CreateEmployeeRequest : PersonDto
    {
        public Guid SanitaryRoleId { get; set; }
    }
}
