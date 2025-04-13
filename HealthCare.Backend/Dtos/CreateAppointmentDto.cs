using System.ComponentModel.DataAnnotations;

namespace HealthCare.Backend.Dtos;

public record class CreateAppointmentDto
(
    [Required][StringLength(50)]string Name,
    int DoctorId,
    [Required]DateTime AppointmentDateTime,
    TimeSpan Duration,
    [Required][StringLength(50)]string AppointmentType,
    string? Notes,
    int StatusId,
    [Required]DateTime CreatedAt);


