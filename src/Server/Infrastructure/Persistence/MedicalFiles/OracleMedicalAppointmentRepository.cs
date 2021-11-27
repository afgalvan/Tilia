﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.MedicalFiles;
using Domain.MedicalFiles.Repositories;
using Microsoft.EntityFrameworkCore;
using SharedLib.Persistence;

namespace Infrastructure.Persistence.MedicalFiles
{
    public class OracleMedicalAppointmentRepository : IMedicalAppointmentRepository
    {
        private readonly TiliaDbContext _dbContext;

        public OracleMedicalAppointmentRepository(TiliaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<MedicalAppointment>> GetAll(
            CancellationToken cancellation)
        {
            return await _dbContext.MedicalAppointments.ToListAsync(cancellation);
        }

        public async Task Save(string patientId, string doctorId, MedicalAppointment appointment,
            CancellationToken cancellation)
        {
            await _dbContext.MedicalAppointments.AddAsync(appointment, cancellation);
            await _dbContext.SaveChangesAsync(cancellation);
            await LinkPeople(patientId, doctorId, appointment.AppointmentId, cancellation);
        }

        private async Task LinkPeople(string patientId, string doctorId, Guid appointmentId,
            CancellationToken cancellation)
        {
            await _dbContext.Database.ExecuteSqlInterpolatedAsync(
                $"UPDATE \"medical_appointments\" SET \"patient_id\" = {patientId}, \"doctor_id\" = {doctorId} WHERE \"appointment_id\" = {appointmentId}",
                cancellation
            );
            await _dbContext.SaveChangesAsync(cancellation);
        }

        public async Task<MedicalAppointment> FindById(Guid id, CancellationToken cancellation)
        {
            return await _dbContext.MedicalAppointments
                .Include(appointment => appointment.MedicalNote)
                .Include(appointment => appointment.Patient)
                .Include(appointment => appointment.DoctorCaring)
                .Include(appointment => appointment.Anamnesis)
                .Include(appointment => appointment.Patient)
                .Include(appointment => appointment.MedicalNote.Diagnostics)
                .Include(appointment => appointment.MedicalNote.Referrals)
                .Include(appointment => appointment.MedicalNote.EvolutionSheet)
                .FirstOrDefaultAsync(appointment =>
                        appointment.AppointmentId == id, cancellation
                );
        }

        public Task RemoveById(Guid id, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MedicalAppointment>> GetByPatientId(string patientId,
            CancellationToken cancellation)
        {
            return await _dbContext.MedicalAppointments
                .Include(appointment => appointment.Patient)
                .AsNoTracking()
                .Where(appointment => appointment.Patient.PersonId == patientId)
                .ToListAsync(cancellation);
        }

        public async Task Save(MedicalAppointment entity, CancellationToken cancellation)
        {
            await _dbContext.MedicalAppointments.AddAsync(entity, cancellation);
            await _dbContext.SaveChangesAsync(cancellation);
        }
    }
}