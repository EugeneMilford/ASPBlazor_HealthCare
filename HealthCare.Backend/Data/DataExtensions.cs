using System;
using HealthCare.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Backend.Data;

public static class DataExtensions
{
    public static void MigrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<HealthCareContext>();
        dbContext.Database.Migrate();
    }
}
