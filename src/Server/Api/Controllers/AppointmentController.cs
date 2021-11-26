using System;
using System.Threading;
using System.Threading.Tasks;
using Application.MedicalFiles.Create;
using Application.MedicalFiles.Filter;
using Application.MedicalFiles.FindById;
using Application.MedicalFiles.GetAll;
using Domain.MedicalFiles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public AppointmentController(AppointmentCreator appointmentCreator,
            AppointmentsRetriever appointmentsRetriever, AppointmentFilter appointmentFilter,
            AppointmentFinder appointmentFinder)
        {
            _appointmentCreator    = appointmentCreator;
            _appointmentsRetriever = appointmentsRetriever;
            _appointmentFilter     = appointmentFilter;
            _appointmentFinder     = appointmentFinder;
        }

        [HttpPost()]
        public async Task<IActionResult> AddAppointment(MedicalAppointment medicalAppointment,
            CancellationToken cancellation)
        {
            try
            {
                await _appointmentCreator.CreateAppointment(medicalAppointment, cancellation);
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
        public async Task<IActionResult> GetAppointments(
            CancellationToken cancellation)
        {
            return Ok(await _appointmentsRetriever.GetAllAppointments(cancellation));
        }

        [HttpGet("patient")]
        public async Task<IActionResult> FilterAppointmentsByPatient([FromQuery] string id,
            CancellationToken cancellation)
        {
            return Ok(await _appointmentFilter.FilterByPatientId(id, cancellation));
        }

        [HttpGet("find")]
        public async Task<IActionResult> FindAppointmentById([FromQuery] string id,
            CancellationToken cancellation)
        {
            return Ok(await _appointmentFinder.FindAppointmentById(id, cancellation));
        }
    }
}
