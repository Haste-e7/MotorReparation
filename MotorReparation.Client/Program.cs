using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MotorReparation.Client;
using MotorReparation.Client.Services;
using MotorReparation.Client.Services.IServices;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7272") });

//services
builder.Services.AddScoped<ITicketService, TicketService>();

await builder.Build().RunAsync();
