using ExampleFeatureFlagService.Client;
using ExampleFeatureFlagService.SDK.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5048/") };
builder.Services.AddScoped(sp => new FeatureFlagService(httpClient));

await builder.Build().RunAsync();