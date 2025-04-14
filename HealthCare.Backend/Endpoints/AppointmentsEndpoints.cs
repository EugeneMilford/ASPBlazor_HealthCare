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
        group.MapGet("/", async (HealthCareContext dbContext) => 
            await dbContext.Appointments
                .Include(appointment => appointment.Doctor)
                .Include(appointment => appointment.Status)
                .Select(appointment => appointment.ToAppointmentSummaryDto())
                .AsNoTracking()
                .ToListAsync());

        // GET /appointments/1
        group.MapGet("/{id}", async (int id, HealthCareContext dbContext) => 
        { 
            // Find the Appointment object instead of AppointmentSummaryDto
            Appointment? appointment = await dbContext.Appointments.FindAsync(id);
            
            return appointment is null ? 
                Results.NotFound() : 
                Results.Ok(appointment.ToAppointmentDetailsDto());
        }).WithName(GetAppointmentEndpointName);

        // POST /appointments
        group.MapPost("/", async (CreateAppointmentDto newAppointment, HealthCareContext dbContext) => 
        {
            Appointment appointment = newAppointment.ToEntity();

            dbContext.Appointments.Add(appointment);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(
                GetAppointmentEndpointName, 
                new { id = appointment.PatientId }, 
                appointment.ToAppointmentDetailsDto());
        });

        // PUT /appointments
        group.MapPut("/{id}", async (int id, UpdateAppointmentDto updatedAppointment, HealthCareContext dbContext) => {
            Console.WriteLine($"Looking for appointment with ID: {id}");
            var existingAppointment = await dbContext.Appointments.FindAsync(id);
    
            if (existingAppointment == null) {
                Console.WriteLine("Appointment not found");
                return Results.NotFound();
            }

            dbContext.Entry(existingAppointment)
                .CurrentValues
                .SetValues(updatedAppointment.ToEntity(id));

            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        // DELETE /games/1
        group.MapDelete("/{id}", async (int id, HealthCareContext dbContext) =>
        {
            await dbContext.Appointments
                .Where(appointment => appointment.PatientId == id)
                .ExecuteDeleteAsync();

            return Results.NoContent();
        });

        return group;
    }
}
