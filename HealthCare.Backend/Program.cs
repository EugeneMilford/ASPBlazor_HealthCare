using HealthCare.Backend.Data;
using HealthCare.Backend.Dtos;
using HealthCare.Backend.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("HealthCare");
builder.Services.AddSqlite<HealthCareContext>(connString);

var app = builder.Build();

app.MapAppointmentsEndpoints();

app.MigrateDb();

app.Run();

