using HealthCare.Backend.Dtos;
using HealthCare.Backend.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapAppointmentsEndpoints();

app.Run();
