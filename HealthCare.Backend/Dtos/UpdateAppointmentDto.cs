using System.ComponentModel.DataAnnotations;

namespace HealthCare.Backend.Dtos;

public record class UpdateAppointmentDto
(
    [Required][StringLength(50)]string Name,
    [Required][StringLength(50)]string Doctor,
    [Required]DateTime AppointmentDateTime,
    TimeSpan Duration,
    [Required][StringLength(50)]string AppointmentType,
    string? Notes,
    [Required][StringLength(50)]string Status,
    [Required]DateTime CreatedAt);

