using System.Threading;
using System.Threading.Tasks;
using Domain.Employees;
using Domain.Employees.Repositories;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Requests.Employees;

namespace Api.Controllers
{
    [Route("employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ISanitaryEmployeesRepository _employeeRepository;
        private readonly IMapper                      _mapper;

        public EmployeesController(ISanitaryEmployeesRepository employeeRepository,
            IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper             = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(CreateEmployeeRequest request,
            CancellationToken cancellation)
        {
            await _employeeRepository.Save(_mapper.Map<SanitaryEmployee>(request),
                cancellation);
            return Ok();
        }
    }
}
