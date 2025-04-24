using System;
using System.ComponentModel.DataAnnotations;

namespace HealthCare.Frontend.Models;

public class AppointmentDetails
{
    public int PatientId { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }

    [Required(ErrorMessage = "The Doctor is required..")]
    public string DoctorId { get; set; }
    [Required]
    public DateTime AppointmentDateTime { get; set; }
    public TimeSpan Duration { get; set; }
    [Required]
    [StringLength(50)]
    public string AppointmentType { get; set; }
    public string Notes { get; set; }
    [Required]
    public string StatusId { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
}
