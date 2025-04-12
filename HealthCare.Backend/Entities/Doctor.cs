using System;

namespace HealthCare.Backend.Entities;

public class Doctor
{
    public int DoctorId { get; set; }

    public required string Name { get; set; }
}
