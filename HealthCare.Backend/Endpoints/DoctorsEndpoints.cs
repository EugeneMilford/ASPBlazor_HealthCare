using System;
using HealthCare.Backend.Data;
using HealthCare.Backend.Mapping;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Backend.Endpoints;

public static class DoctorsEndpoints
{
    public static RouteGroupBuilder MapDoctorsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("doctors");

        group.MapGet("/", async (HealthCareContext dbContext) =>
            await dbContext.Doctors
                .Select(doctor => doctor.ToDoctorDto())
                .AsNoTracking()
                .ToListAsync());

        return group;
    }
}
