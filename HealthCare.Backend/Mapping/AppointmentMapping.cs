using System;
using HealthCare.Backend.Dtos;
using HealthCare.Backend.Entities;

namespace HealthCare.Backend.Mapping;

public static class AppointmentMapping
{
    public static Appointment ToEntity(this CreateAppointmentDto appointment)
    {
        return new Appointment()
        {
            Name = appointment.Name,
            DoctorId = appointment.DoctorId,
            AppointmentDateTime = appointment.AppointmentDateTime,
            Duration = appointment.Duration,
            AppointmentType = appointment.AppointmentType,
            Notes = appointment.Notes,
            StatusId = appointment.StatusId,
            CreatedAt = appointment.CreatedAt
        };

    }    

    public static AppointmentDto ToDto(this Appointment appointment)
    {
        return new(
            appointment.PatientId,
            appointment.Name,
            appointment.Doctor!.Name,
            appointment.AppointmentDateTime,
            appointment.Duration,
            appointment.AppointmentType,
            appointment.Notes,
            appointment.Status!.CurrentStatus,
            appointment.CreatedAt
        );
    }
}
