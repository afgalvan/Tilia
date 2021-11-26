using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Patients.Create;
using Application.Patients.FindById;
using Application.Patients.GetAll;
using Domain.Patients;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Requests.Responses;

namespace Api.Controllers
{
    [Route("patients")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddPatient(CreatePatientCommand patientCommand,
            CancellationToken cancellationToken)
        {
            try
            {
                await _mediator.Send(patientCommand, cancellationToken);
                return Ok();
            }
            catch (DbUpdateException)
            {
                return BadRequest(new { Message = "Cédula del paciente registrada" });
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Patient>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPatients(CancellationToken cancellation)
        {
            IEnumerable<Patient> patients =
                await _mediator.Send(new GetAllPatientsQuery(), cancellation);
            return Ok(patients);
        }

        [HttpGet("find")]
        [ProducesResponseType(typeof(Patient), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPatientById([FromQuery] string id, CancellationToken cancellation)
        {
            Patient patient =
                await _mediator.Send(new FindPatientByIdQuery(id), cancellation);
            return Ok(patient);
        }
    }
}
