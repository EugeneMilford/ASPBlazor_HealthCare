using System;
using HealthCare.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Backend.Data;

public static class DataExtensions
{
    public static async Task MigrateDbAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<HealthCareContext>();
        await dbContext.Database.MigrateAsync();
    }
}
