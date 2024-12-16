using ExampleFeatureFlagService.Client;
using ExampleFeatureFlagService.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:5001/") // URL of the Web API
});

builder.Services.AddScoped<FeatureFlagService>();

await builder.Build().RunAsync();