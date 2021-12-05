using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Api.Extensions;
using Application.MedicalFiles.Create;
using Application.MedicalFiles.Filter;
using Application.MedicalFiles.FindById;
using Application.MedicalFiles.GetAll;
using Application.MedicalFiles.Remove;
using Application.MedicalFiles.Toggle;
using Domain.MedicalFiles;
using MapsterMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Requests.Appointments;

namespace Api.Controllers
{
    [Route("appointments")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly AppointmentCreator    _appointmentCreator;
        private readonly AppointmentsRetriever _appointmentsRetriever;
        private readonly AppointmentFilter     _appointmentFilter;
        private readonly AppointmentFinder     _appointmentFinder;
        private readonly AppointmentRemover    _appointmentRemover;
        private readonly AppointmentToggler    _appointmentToggler;
        private readonly IMapper               _mapper;

        public AppointmentController(AppointmentCreator appointmentCreator,
            AppointmentsRetriever appointmentsRetriever, AppointmentFilter appointmentFilter,
            AppointmentFinder appointmentFinder, IMapper mapper,
            AppointmentRemover appointmentRemover, AppointmentToggler appointmentToggler)
        {
            _appointmentCreator    = appointmentCreator;
            _appointmentsRetriever = appointmentsRetriever;
            _appointmentFilter     = appointmentFilter;
            _appointmentFinder     = appointmentFinder;
            _mapper                = mapper;
            _appointmentRemover    = appointmentRemover;
            _appointmentToggler    = appointmentToggler;
        }

        [HttpPost]
        public async Task<IActionResult> AddAppointment(
            CreateMedicalAppointmentRequest request,
            CancellationToken cancellation)
        {
            var medicalAppointment = _mapper.From(request).AdaptToType<MedicalAppointment>();
            try
            {
                await _appointmentCreator.CreateAppointment(request.PatientId,
                    request.DoctorId, medicalAppointment, cancellation);
                return Ok();
            }
            catch (DbUpdateException)
            {
                return BadRequest(new { Message = "Datos inválidos" });
            }
            catch (Exception)
            {
                return BadRequest(new { Message = "Error inesperado en el servidor" });
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MedicalAppointmentResponse>),
            StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAppointments(
            CancellationToken cancellation)
        {
            IEnumerable<MedicalAppointment> appointments =
                await _appointmentsRetriever.GetAllAppointments(cancellation);
            return Respond(appointments);
        }

        [HttpGet("patient")]
        [ProducesResponseType(typeof(IEnumerable<MedicalAppointmentResponse>),
            StatusCodes.Status200OK)]
        public async Task<IActionResult> FilterAppointmentsByPatient([FromQuery] string id,
            CancellationToken cancellation)
        {
            IEnumerable<MedicalAppointment> appointments =
                await _appointmentFilter.FilterByPatientId(id, cancellation);
            return Respond(appointments);
        }

        private IActionResult Respond(IEnumerable<MedicalAppointment> appointments)
        {
            var response = _mapper.From(appointments)
                .AdaptToType<IEnumerable<MedicalAppointmentResponse>>();
            return Ok(response.ForEach((appointment, index) => appointment.Index = index + 1));
        }

        [HttpGet("find")]
        [ProducesResponseType(typeof(MedicalAppointment), StatusCodes.Status200OK)]
        public async Task<IActionResult> FindAppointmentById([FromQuery] string id,
            CancellationToken cancellation)
        {
            return Ok(await _appointmentFinder.FindAppointmentById(id, cancellation));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAppointmentById([FromQuery] string id,
            CancellationToken cancellation)
        {
            try
            {
                await _appointmentRemover.RemoveAppointment(id, cancellation);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPatch("toggle")]
        public async Task<IActionResult> ToggleAppointmentState([FromQuery] string id,
            CancellationToken cancellation)
        {
            await _appointmentToggler.ToggleAppointmentState(id, cancellation);
            return Ok();
        }
    }
}
