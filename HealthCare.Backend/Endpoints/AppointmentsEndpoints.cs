using System;
using HealthCare.Backend.Data;
using HealthCare.Backend.Dtos;
using HealthCare.Backend.Entities;
using HealthCare.Backend.Mapping;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Backend.Endpoints;

public static class AppointmentsEndpoints
{
    const string GetAppointmentEndpointName = "GetAppointment";

    public static RouteGroupBuilder MapAppointmentsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("appointments").WithParameterValidation();

        // GET /appointments
        group.MapGet("/", (HealthCareContext dbContext) => 
            dbContext.Appointments
                .Include(appointment => appointment.Doctor)
                .Select(appointment => appointment.ToAppointmentSummaryDto())
                .AsNoTracking());

        // GET /appointments/1
        group.MapGet("/{id}", (int id, HealthCareContext dbContext) => 
        { 
            // Find the Appointment object instead of AppointmentSummaryDto
            Appointment? appointment = dbContext.Appointments.Find(id);
            
            return appointment is null ? 
                Results.NotFound() : 
                Results.Ok(appointment.ToAppointmentDetailsDto());
        }).WithName(GetAppointmentEndpointName);

        // POST /appointments
        group.MapPost("/", (CreateAppointmentDto newAppointment, HealthCareContext dbContext) => 
        {
            Appointment appointment = newAppointment.ToEntity();

            dbContext.Appointments.Add(appointment);
            dbContext.SaveChanges();

            return Results.CreatedAtRoute(
                GetAppointmentEndpointName, 
                new { id = appointment.PatientId }, 
                appointment.ToAppointmentDetailsDto());
        });

        // PUT /appointments/{id}
        group.MapPut("/{id}", (int id, UpdateAppointmentDto updatedAppointment, HealthCareContext dbContext) =>
        {
            var existingAppointment = dbContext.Appointments.Find(id);

            if (existingAppointment == null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingAppointment)
                .CurrentValues
                .SetValues(updatedAppointment.ToEntity(id));

            dbContext.SaveChanges();

            return Results.NoContent();
        });

        // DELETE /games/1
        group.MapDelete("/{id}", (int id, HealthCareContext dbContext) =>
        {
            dbContext.Appointments
                .Where(appointment => appointment.PatientId == id)
                .ExecuteDelete();

            return Results.NoContent();
        });

        return group;
    }
}
