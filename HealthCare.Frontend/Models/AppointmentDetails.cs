using System;

namespace HealthCare.Frontend.Models;

public class AppointmentDetails
{
    public int PatientId { get; set; }
    public string Name { get; set; }
    public string DoctorId { get; set; }
    public DateTime AppointmentDateTime { get; set; }
    public TimeSpan Duration { get; set; }
    public string AppointmentType { get; set; }
    public string Notes { get; set; }
    public string StatusId { get; set; }
    public DateTime CreatedAt { get; set; }
}
