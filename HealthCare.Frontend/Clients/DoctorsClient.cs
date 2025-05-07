using System;
using HealthCare.Frontend.Models;

namespace HealthCare.Frontend.Clients;

public class DoctorsClient(HttpClient httpClient)
{
    public async Task <Doctor[]> GetDoctorsAsync() 
        => await httpClient.GetFromJsonAsync<Doctor[]>("doctors") ?? [];
}