using System;
using System.Collections.Generic;
using System.Linq;
using HealthCare.Frontend.Models;

namespace HealthCare.Frontend.Clients;

public class AppointmentClient(HttpClient httpClient)
{
    public async Task <AppointmentSummary[]> GetAppointmentsAsync() 
        => await httpClient.GetFromJsonAsync<AppointmentSummary[]>("appointments") ?? [];

    public async Task AddAppointmentAsync(AppointmentDetails appointment)
        => await httpClient.PostAsJsonAsync("appointments", appointment);

    // Return Appointment Details
    public async Task<AppointmentDetails> GetAppointmentAsync(int id)
        => await httpClient.GetFromJsonAsync<AppointmentDetails>($"appointments/{id}")
        ?? throw new Exception("Could not find appointment...");

    // Update an Appointment
    public async Task UpdateAppointmentAsync(AppointmentDetails updatedAppointment)
        => await httpClient.PutAsJsonAsync($"appointments/{updatedAppointment.PatientId}", updatedAppointment);

    public async Task DeleteAppointmentAsync(int id)
        => await httpClient.DeleteAsync($"appointments/{id}");
}




