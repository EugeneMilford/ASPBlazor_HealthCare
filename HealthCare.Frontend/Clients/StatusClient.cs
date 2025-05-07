using System;
using HealthCare.Frontend.Models;

namespace HealthCare.Frontend.Clients;

public class StatusClient(HttpClient httpClient)
{
    public async Task <Status[]> GetStatussesAsync() 
        => await httpClient.GetFromJsonAsync<Status[]>("statusses") ?? [];
}