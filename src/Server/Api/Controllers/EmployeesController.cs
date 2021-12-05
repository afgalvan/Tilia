using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Employees;
using Domain.Employees.Repositories;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        [ProducesResponseType(typeof(EmployeeResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetEmployees(CancellationToken cancellation)
        {
            IEnumerable<SanitaryEmployee> employees = await _employeeRepository.GetAll(cancellation);
            return Ok(_mapper.From(employees).AdaptToType<IEnumerable<EmployeeResponse>>());
        }
    }
}
