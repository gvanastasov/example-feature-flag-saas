using System.Net.Http.Headers;
using ExampleFeatureFlagService.Client;
using ExampleFeatureFlagService.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("FeatureFlagService", client =>
{
    client.BaseAddress = new Uri("http://localhost:5048/");
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});

builder.Services.AddScoped<FeatureFlagService>();

await builder.Build().RunAsync();