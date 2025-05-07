using HealthCare.Frontend.Clients;
using HealthCare.Frontend.Components;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var healthCareAPIUrl = builder.Configuration["HealthCareAPIUrl"] ??
    throw new Exception("HealthCareAPIUrl is not set");

// Configure default JsonSerializerOptions for HttpClient requests
var jsonOptions = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
};

// Register JsonSerializerOptions as a singleton
builder.Services.AddSingleton(jsonOptions);

// Configure HTTP clients
builder.Services.AddHttpClient<AppointmentClient>(client => 
{
    client.BaseAddress = new Uri(healthCareAPIUrl);
    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
});

builder.Services.AddHttpClient<DoctorsClient>(client => 
{
    client.BaseAddress = new Uri(healthCareAPIUrl);
    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
});

builder.Services.AddHttpClient<StatusClient>(client => 
{
    client.BaseAddress = new Uri(healthCareAPIUrl);
    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

app.Run();