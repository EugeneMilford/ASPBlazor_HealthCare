namespace HealthCare.Backend.Dtos;

public record class AppointmentDetailsDto(
    int PatientId,
    string Name, 
    int DoctorId,
    DateTime AppointmentDateTime,
    TimeSpan Duration,
    string AppointmentType,
    string Notes,
    int StatusId,
    DateTime CreatedAt
);

