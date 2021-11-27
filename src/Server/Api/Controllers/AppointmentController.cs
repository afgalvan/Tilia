﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.MedicalFiles.Create;
using Application.MedicalFiles.Filter;
using Application.MedicalFiles.FindById;
using Application.MedicalFiles.GetAll;
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
        private readonly IMapper               _mapper;

        public AppointmentController(AppointmentCreator appointmentCreator,
            AppointmentsRetriever appointmentsRetriever, AppointmentFilter appointmentFilter,
            AppointmentFinder appointmentFinder, IMapper mapper)
        {
            _appointmentCreator    = appointmentCreator;
            _appointmentsRetriever = appointmentsRetriever;
            _appointmentFilter     = appointmentFilter;
            _appointmentFinder     = appointmentFinder;
            _mapper                = mapper;
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
        [ProducesResponseType(typeof(IEnumerable<MedicalAppointmentResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAppointments(
            CancellationToken cancellation)
        {
            IEnumerable<MedicalAppointment> appointments = await _appointmentsRetriever.GetAllAppointments(cancellation);
            return Ok(_mapper.From(appointments).AdaptToType<IEnumerable<MedicalAppointmentResponse>>());
        }

        [HttpGet("patient")]
        [ProducesResponseType(typeof(IEnumerable<MedicalAppointmentResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> FilterAppointmentsByPatient([FromQuery] string id,
            CancellationToken cancellation)
        {
            IEnumerable<MedicalAppointment> appointments = await _appointmentFilter.FilterByPatientId(id, cancellation);
            return Ok(_mapper.From(appointments).AdaptToType<IEnumerable<MedicalAppointmentResponse>>());
        }

        [HttpGet("find")]
        [ProducesResponseType(typeof(MedicalAppointment), StatusCodes.Status200OK)]
        public async Task<IActionResult> FindAppointmentById([FromQuery] string id,
            CancellationToken cancellation)
        {
            return Ok(await _appointmentFinder.FindAppointmentById(id, cancellation));
        }
    }
}