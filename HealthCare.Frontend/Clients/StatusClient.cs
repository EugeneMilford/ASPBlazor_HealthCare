using System;
using HealthCare.Frontend.Models;

namespace HealthCare.Frontend.Clients;

public class StatusClient
{
    private readonly Status[] statusses = 
    [
        new() { 
            StatusId = 1, 
            CurrentStatus = "Scheduled" },
        new() { 
            StatusId = 2, 
            CurrentStatus = "Confirmed" },
        new() { 
            StatusId = 3, 
            CurrentStatus = "Completed" },
        new() { 
            StatusId = 4, 
            CurrentStatus = "Cancelled" },
        new() { 
            StatusId = 5, 
            CurrentStatus = "No-Show" }
    ];

    public Status[] GetStatusses() => statusses;
}
