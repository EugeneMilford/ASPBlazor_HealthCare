using System;
using System.Collections.Generic;
using System.Linq;
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
            Doctor = "Dr. Michael Smith",
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
            Doctor = "Dr. Michelle Brown",
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
            Doctor = "Dr. Henry Davis",
            AppointmentDateTime = new DateTime(2023, 12, 18, 16, 0, 0),
            Duration = TimeSpan.FromMinutes(20),
            AppointmentType = "Vaccination",
            Notes = "Flu shot",
            Status = "Cancelled",
            CreatedAt = DateTime.Now.AddDays(-5)
        }
    ];

    private readonly Doctor[] doctors = new DoctorsClient().GetDoctors();
    private readonly Status[] statuses = new StatusClient().GetStatusses();

    public AppointmentSummary[] GetAppointments() => [.. appointments];

    public void AddAppointment(AppointmentDetails appointment)
    {
        if (appointment == null)
            throw new ArgumentNullException(nameof(appointment));

        if (string.IsNullOrWhiteSpace(appointment.DoctorId))
            throw new ArgumentException("Doctor ID is required", nameof(appointment.DoctorId));

        if (string.IsNullOrWhiteSpace(appointment.StatusId))
            throw new ArgumentException("Status ID is required", nameof(appointment.StatusId));

        var doctor = GetDoctorById(appointment.DoctorId);
        var status = GetStatusById(appointment.StatusId);

        if (appointment.PatientId > 0)
        {
            var existingIndex = appointments.FindIndex(a => a.PatientId == appointment.PatientId);
            if (existingIndex >= 0)
            {
                appointments[existingIndex] = new AppointmentSummary
                {
                    PatientId = appointment.PatientId,
                    Name = appointment.Name,
                    Doctor = doctor.DoctorName,
                    AppointmentDateTime = appointment.AppointmentDateTime,
                    Duration = appointment.Duration,
                    AppointmentType = appointment.AppointmentType,
                    Notes = appointment.Notes,
                    Status = status.CurrentStatus,
                    CreatedAt = appointment.CreatedAt
                };
                return;
            }
        }

        int nextId = appointments.Count > 0 ? appointments.Max(a => a.PatientId) + 1 : 1;

        appointments.Add(new AppointmentSummary
        {
            PatientId = nextId,
            Name = appointment.Name,
            Doctor = doctor.DoctorName,
            AppointmentDateTime = appointment.AppointmentDateTime,
            Duration = appointment.Duration,
            AppointmentType = appointment.AppointmentType,
            Notes = appointment.Notes,
            Status = status.CurrentStatus,
            CreatedAt = appointment.CreatedAt
        });
    }

    private Doctor GetDoctorById(string id)
    {
        if (!int.TryParse(id, out int doctorId))
            throw new ArgumentException("Invalid Doctor ID format", nameof(id));

        var doctor = doctors.FirstOrDefault(d => d.DoctorId == doctorId);
        return doctor ?? throw new KeyNotFoundException($"Doctor with ID {id} not found");
    }

    private Status GetStatusById(string id)
    {
        if (!int.TryParse(id, out int statusId))
            throw new ArgumentException("Invalid Status ID format", nameof(id));

        var status = statuses.FirstOrDefault(s => s.StatusId == statusId);
        return status ?? throw new KeyNotFoundException($"Status with ID {id} not found");
    }

    public AppointmentDetails GetAppointment(int id)
    {
        if (id <= 0)
            throw new ArgumentException("Invalid appointment ID", nameof(id));

        var appointment = appointments.FirstOrDefault(a => a.PatientId == id) ?? 
            throw new KeyNotFoundException($"Appointment with ID {id} not found");

        var doctor = doctors.FirstOrDefault(d => d.DoctorName.Equals(appointment.Doctor, StringComparison.OrdinalIgnoreCase));
        var status = statuses.FirstOrDefault(s => s.CurrentStatus.Equals(appointment.Status, StringComparison.OrdinalIgnoreCase));

        return new AppointmentDetails
        {
            PatientId = appointment.PatientId,
            Name = appointment.Name,
            DoctorId = doctor?.DoctorId.ToString() ?? string.Empty,
            AppointmentDateTime = appointment.AppointmentDateTime,
            Duration = appointment.Duration,
            AppointmentType = appointment.AppointmentType,
            Notes = appointment.Notes,
            StatusId = status?.StatusId.ToString() ?? string.Empty,
            CreatedAt = appointment.CreatedAt
        };
    }

    public AppointmentSummary GetAppointmentById(string patientId)
    {
        if (!int.TryParse(patientId, out int id) || id <= 0)
            return null;

        return appointments.FirstOrDefault(a => a.PatientId == id);
    }

    public void UpdateAppointment(AppointmentDetails updatedAppointment)
{
    if (updatedAppointment == null)
        throw new ArgumentNullException(nameof(updatedAppointment));

    // Validate the appointment date is not default
    if (updatedAppointment.AppointmentDateTime == default)
        throw new ArgumentException("Appointment date/time is required", nameof(updatedAppointment.AppointmentDateTime));

    // Validate duration is positive
    if (updatedAppointment.Duration <= TimeSpan.Zero)
        throw new ArgumentException("Duration must be positive", nameof(updatedAppointment.Duration));

    var doctor = GetDoctorById(updatedAppointment.DoctorId);
    var status = GetStatusById(updatedAppointment.StatusId);
    var existingAppointment = GetAppointmentSummaryById(updatedAppointment.PatientId);

    // Update all fields including date/time and duration
    existingAppointment.Name = updatedAppointment.Name;
    existingAppointment.Doctor = doctor.DoctorName;
    existingAppointment.AppointmentDateTime = updatedAppointment.AppointmentDateTime;
    existingAppointment.Duration = updatedAppointment.Duration;
    existingAppointment.AppointmentType = updatedAppointment.AppointmentType;
    existingAppointment.Notes = updatedAppointment.Notes;
    existingAppointment.Status = status.CurrentStatus;
    existingAppointment.CreatedAt = updatedAppointment.CreatedAt;
}

    private AppointmentSummary GetAppointmentSummaryById(int id)
    {
        return appointments.FirstOrDefault(a => a.PatientId == id) ?? 
            throw new KeyNotFoundException($"Appointment with ID {id} not found");
    }

    public bool DeleteAppointment(int id)
    {
        int index = appointments.FindIndex(a => a.PatientId == id);
        if (index >= 0)
        {
            appointments.RemoveAt(index);
            return true;
        }
        return false;
    }
}

