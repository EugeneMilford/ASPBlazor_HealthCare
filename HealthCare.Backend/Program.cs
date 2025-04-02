using HealthCare.Backend.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string GetAppointmentEndpointName = "GetAppointment";

List<AppointmentDto> appointments = [
            new (
                1,
                "John Doe",
                "Dr. Smith",
                new DateTime(2025, 04, 08, 10, 30, 0),
                Duration: TimeSpan.FromHours(1),
                "Check-up",
                "Follow up on previous issues.",
                "Scheduled",
                new DateTime(2025, 04, 01, 11, 30, 0)
            ),
            new (
                2,
                "Jane Doe",
                "Dr. Adams",
                new DateTime(2025, 04, 09, 14, 00, 0),
                Duration: TimeSpan.FromHours(0.5),
                "Consultation",
                "New patient, first consultation.",
                "Confirmed",
                new DateTime(2025, 04, 01, 11, 30, 0)
            ),
            new (
                3,
                "Alice Johnson",
                "Dr. Lee",
                new DateTime(2025, 04, 10, 09, 00, 0),
                Duration: TimeSpan.FromHours(1),
                "Therapy",
                null,
                "Completed",
                new DateTime(2025, 04, 01, 11, 30, 0)
            ),
            new (
                4,
                "Bob Smith",
                "Dr. Clark",
                new DateTime(2025, 04, 11, 11, 15, 0),
                Duration: TimeSpan.FromHours(1.5),
                "Surgery Consultation",
                "Discuss surgery options.",
                "Pending",
                new DateTime(2025, 04, 01, 11, 30, 0)
            ),
            new (
                5,
                "Charlie Brown",
                "Dr. Wilson",
                new DateTime(2025, 04, 12, 16, 45, 0),
                Duration: TimeSpan.FromHours(1),
                "Routine Check",
                "Check blood pressure and cholesterol.",
                "Cancelled",
                new DateTime(2025, 04, 01, 11, 30, 0)
            )
];

// GET /appointments
app.MapGet("appointments", ()=> appointments);

//Get /appointments/1
app.MapGet("appointments/{id}", (int id) => 
{ 
     AppointmentDto? appointment = appointments.Find(appointment => appointment.PatientId == id);

    return appointment is null ? Results.NotFound() : Results.Ok(appointment);
}).WithName(GetAppointmentEndpointName);

// POST /appointments
app.MapPost("appointments", (CreateAppointmentDto newAppointment) => 
{
    AppointmentDto appointment = new(
        appointments.Count + 1,
        newAppointment.Name,
        newAppointment.Doctor,
        newAppointment.AppointmentDateTime,
        newAppointment.Duration,
        newAppointment.AppointmentType,
        newAppointment.Notes,
        newAppointment.Status,
        newAppointment.CreatedAt
    );

    appointments.Add(appointment);

    return Results.CreatedAtRoute(GetAppointmentEndpointName, new { id = appointment.PatientId }, appointment);
});

// PUT /appointments/{id}
app.MapPut("/appointments/{id}", (int id, UpdateAppointmentDto updatedAppointment) =>
{
    var index = appointments.FindIndex(appointment => appointment.PatientId == id);

    appointments[index] = new AppointmentDto(
        id,
        updatedAppointment.Name,
        updatedAppointment.Doctor,
        updatedAppointment.AppointmentDateTime,
        updatedAppointment.Duration,
        updatedAppointment.AppointmentType,
        updatedAppointment.Notes,
        updatedAppointment.Status,
        updatedAppointment.CreatedAt
        );

    return Results.NoContent();
});

// DELETE /appointments/1
app.MapDelete("appointments/{id}", (int id) => 
{
    appointments.RemoveAll(appointment => appointment.PatientId == id);

    return Results.NoContent();
});


app.Run();
