using System;
using HealthCare.Backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Backend.Data;

public class HealthCareContext(DbContextOptions<HealthCareContext> options)
    : DbContext(options)

{
    public DbSet<Appointment> Appointments => Set<Appointment>();

    public DbSet<Doctor> Doctors => Set<Doctor>();
    public DbSet<Status> Statusses => Set<Status>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>()
            .HasKey(a => a.PatientId);  

        modelBuilder.Entity<Doctor>().HasData(
            new { DoctorId = 1, Name = "Dr. Smith" },
            new { DoctorId = 2, Name = "Dr. Johnson" },
            new { DoctorId = 3, Name = "Dr. Williams" },
            new { DoctorId = 4, Name = "Dr. Brown" },
            new { DoctorId = 5, Name = "Dr. Davis" }
        );

        modelBuilder.Entity<Status>().HasData(
            new { StatusId = 1, CurrentStatus = "Scheduled" },
            new { StatusId = 2, CurrentStatus = "Confirmed" },
            new { StatusId = 3, CurrentStatus = "Completed" },
            new { StatusId = 4, CurrentStatus = "Cancelled" },
            new { StatusId = 5, CurrentStatus = "No-Show" }
        );

    }
}



