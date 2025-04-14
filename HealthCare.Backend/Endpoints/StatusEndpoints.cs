using System;
using HealthCare.Backend.Data;
using HealthCare.Backend.Mapping;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Backend.Endpoints;

public static class StatusEndpoints
{
    public static RouteGroupBuilder MapStatusEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("statusses");

        group.MapGet("/", async (HealthCareContext dbContext) =>
            await dbContext.Statusses
                .Select(status => status.ToStatusDto())
                .AsNoTracking()
                .ToListAsync());

        return group;
    }
}
