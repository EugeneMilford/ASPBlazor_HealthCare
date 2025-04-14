using System;
using HealthCare.Backend.Dtos;
using HealthCare.Backend.Entities;

namespace HealthCare.Backend.Mapping;

public static class DoctorMapping
{
    public static DoctorDto ToDoctorDto(this Doctor doctor)
    {
        return new DoctorDto(doctor.DoctorId, doctor.Name);
    }
}
