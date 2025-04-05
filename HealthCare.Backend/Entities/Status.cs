using System;

namespace HealthCare.Backend.Entities;

public class Status
{
    public int StatusId{ get; set; }

    public required string CurrentStatus{ get; set; }
}
