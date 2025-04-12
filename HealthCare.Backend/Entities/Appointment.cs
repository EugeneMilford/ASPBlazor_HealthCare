using System;

namespace HealthCare.Backend.Entities;

public class Appointment
{
    public int PatientId { get; set; }
    public required string Name { get; set; }
    public int DoctorId { get; set; }
    public Doctor? Doctor { get; set; }
    public required DateTime AppointmentDateTime { get; set; }
    public TimeSpan Duration { get; set; }
    public required string AppointmentType { get; set; }
    public string? Notes { get; set; }
    public int StatusId { get; set; }
    public Status? Status { get; set; }
    public required DateTime CreatedAt { get; set; }
}
