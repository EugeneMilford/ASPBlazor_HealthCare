using System;
using HealthCare.Backend.Dtos;
using HealthCare.Backend.Entities;

namespace HealthCare.Backend.Mapping;

public static class StatusMapping
{
    public static StatusDto ToStatusDto(this Status status)
    {
        return new StatusDto(status.StatusId, status.CurrentStatus);
    }
}
