
using ExampleFeatureFlagService.SDK.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
var httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5048/") };
builder.Services.AddScoped(sp => new FeatureFlagService(httpClient));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
