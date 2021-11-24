using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.People;
using Domain.People.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("id-types")]
    [ApiController]
    public class IdTypesController : ControllerBase
    {
        private readonly IIdTypesRepository _repository;

        public IdTypesController(IIdTypesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<IdType>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllTypes(CancellationToken cancellationToken)
        {
            return Ok(await _repository.GetAll(cancellationToken));
        }
    }
}
