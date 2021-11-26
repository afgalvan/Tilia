using Domain.SharedLib;

namespace Domain.Employees.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee, string>
    {
    }
}
