using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Patients.Create;
using Application.Patients.FindById;
using Application.Patients.GetAll;
using Domain.Patients;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Requests.Patients;
using Requests.Responses;

namespace Api.Controllers
{
    [Route("patients")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper   _mapper;

        public PatientsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper   = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddPatient(CreatePatientRequest patientRequest,
            CancellationToken cancellationToken)
        {
            try
            {
                var command = _mapper.Map<CreatePatientCommand>(patientRequest);
                await _mediator.Send(command, cancellationToken);
                return Ok();
            }
            catch (DbUpdateException)
            {
                return BadRequest(new { Message = "Cédula del paciente registrada" });
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PatientResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPatients(CancellationToken cancellation)
        {
            IEnumerable<PatientResponse> patients =
                await _mediator.Send(new GetAllPatientsQuery(), cancellation);
            return Ok(patients);
        }

        [HttpGet("find")]
        [ProducesResponseType(typeof(Patient), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPatientById([FromQuery] string id,
            CancellationToken cancellation)
        {
            Patient patient =
                await _mediator.Send(new FindPatientByIdQuery(id), cancellation);
            return Ok(patient);
        }
    }
}
