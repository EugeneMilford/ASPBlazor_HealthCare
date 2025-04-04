namespace HealthCare.Backend.Dtos;

public record class AppointmentDto(
    int PatientId,
    string Name,
    string Doctor,
    DateTime AppointmentDateTime,
    TimeSpan Duration,
    string AppointmentType,
    string? Notes,
    string Status,
    DateTime CreatedAt);
