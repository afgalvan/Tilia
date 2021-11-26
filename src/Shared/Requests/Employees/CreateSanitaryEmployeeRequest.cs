using System;
using Requests.People;

namespace Requests.Employees
{
    public class CreateSanitaryEmployeeRequest : PersonDto
    {
        public Guid SanitaryRoleId { get; set; }
    }
}
