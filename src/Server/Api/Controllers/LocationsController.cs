using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Locations;
using Domain.Locations.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("locations")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationsRepository _repository;

        public LocationsController(ILocationsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("departments")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<Department>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllDepartments(CancellationToken cancellation)
        {
            return Ok(await _repository.GetAll(cancellation));
        }

        [HttpGet("cities")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<City>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCityOf([FromQuery] string departmentId, CancellationToken cancellation)
        {
            return Ok(await _repository.GetAllCitiesOf(departmentId, cancellation));
        }
    }
}
