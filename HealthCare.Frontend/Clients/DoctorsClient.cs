using System;
using HealthCare.Frontend.Models;

namespace HealthCare.Frontend.Clients;

public class DoctorsClient
{
    private readonly Doctor[] doctors = 
    [
        new(){
            DoctorId = 1, 
            DoctorName = "Dr. Smith"},
        new() { 
            DoctorId = 2, 
            DoctorName = "Dr. Johnson" },
        new() { 
            DoctorId = 3, 
            DoctorName = "Dr. Williams" },
        new() { 
            DoctorId = 4, 
            DoctorName = "Dr. Brown" },
        new() { 
            DoctorId = 5, 
            DoctorName = "Dr. Davis" }
    ];

    public Doctor[] GetDoctors() => doctors;
}
