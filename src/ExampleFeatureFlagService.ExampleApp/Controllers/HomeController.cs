using ExampleFeatureFlagService.SDK.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExampleFeatureFlagService.ExampleApp.Controllers;

public class HomeController : Controller
{
    private readonly FeatureFlagService _flagService;

    public HomeController(FeatureFlagService flagService)
    {
        _flagService = flagService;
    }

    public async Task<IActionResult> Index()
    {
        // Fetch feature flags from the API
        var flags = await _flagService.GetFlagsAsync();

        // Pass them to the view
        return View(flags);
    }
}
