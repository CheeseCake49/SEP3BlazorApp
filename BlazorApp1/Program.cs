using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorApp1;
using HttpClients.ClientInterfaces;
using HttpClients.Implementations;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddMudServices();
builder.Services.AddScoped<ICenterService, CenterHttpClient>();
builder.Services.AddScoped<ICourtService, CourtHttpClient>();
builder.Services.AddScoped<IBookingService, BookingHttpClient>();
builder.Services.AddScoped<IBookingAddOnService, BookingAddOnHttpClient>();
builder.Services.AddScoped<ITimeSlotService, TimeSlotHttpClient>();

builder.Services.AddScoped(
    sp => 
        new HttpClient { 
            BaseAddress = new Uri("https://localhost:7024")
        }
);

await builder.Build().RunAsync();