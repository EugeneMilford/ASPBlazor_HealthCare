using System;

namespace HealthCare.Frontend.Models;

public class AppointmentSummary
{
    public int PatientId { get; set; }
    public string Name { get; set; } 
    public string Doctor { get; set; }
    public DateTime AppointmentDateTime { get; set; }
    public TimeSpan Duration { get; set; }
    public string AppointmentType { get; set; }
    public string Notes { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
}
