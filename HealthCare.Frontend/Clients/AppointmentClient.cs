using System;
using HealthCare.Frontend.Models;

namespace HealthCare.Frontend.Clients;

public class AppointmentClient
{
    private readonly List<AppointmentSummary> appointments = 
    [
        new() {
            PatientId = 1,
            Name = "John Smith",
            Doctor = "Dr. Emily Johnson",
            AppointmentDateTime = new DateTime(2023, 12, 15, 14, 30, 0),
            Duration = TimeSpan.FromMinutes(30),
            AppointmentType = "General Checkup",
            Notes = "Annual physical examination",
            Status = "Confirmed",
            CreatedAt = DateTime.Now.AddDays(-7)
        },
        new() {
            PatientId = 2,
            Name = "Sarah Williams",
            Doctor = "Dr. Michael Chen",
            AppointmentDateTime = new DateTime(2023, 12, 16, 10, 0, 0),
            Duration = TimeSpan.FromMinutes(60),
            AppointmentType = "Consultation",
            Notes = "Follow-up for test results",
            Status = "Pending",
            CreatedAt = DateTime.Now.AddDays(-3)
        },
        new() {
            PatientId = 3,
            Name = "Robert Johnson",
            Doctor = "Dr. Lisa Park",
            AppointmentDateTime = new DateTime(2023, 12, 17, 9, 15, 0),
            Duration = TimeSpan.FromMinutes(45),
            AppointmentType = "Dental Cleaning",
            Notes = "No extra notes",
            Status = "Completed",
            CreatedAt = DateTime.Now.AddDays(-14)
        },
        new() {
            PatientId = 4,
            Name = "Maria Garcia",
            Doctor = "Dr. David Wilson",
            AppointmentDateTime = new DateTime(2023, 12, 18, 16, 0, 0),
            Duration = TimeSpan.FromMinutes(20),
            AppointmentType = "Vaccination",
            Notes = "Flu shot",
            Status = "Cancelled",
            CreatedAt = DateTime.Now.AddDays(-5)
        }
    ];

    public AppointmentSummary[] GetAppointments() => [.. appointments];
}
