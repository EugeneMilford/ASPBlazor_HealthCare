namespace HealthCare.Backend.Dtos;

public record class AppointmentSummaryDto
(
    int PatientId,
    string Name, 
    string Doctor,
    DateTime AppointmentDateTime,
    TimeSpan Duration,
    string AppointmentType,
    string Notes,
    string Status,
    DateTime CreatedAt
);
