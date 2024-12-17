using System.Net.Http.Json;
using ExampleFeatureFlagService.SDK.Models;

namespace ExampleFeatureFlagService.SDK.Services;

public class FeatureFlagService
{
    private readonly HttpClient _httpClient;

    public FeatureFlagService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        Console.WriteLine($"HttpClient BaseAddress: {_httpClient.BaseAddress}");
    }

    // Fetch all feature flags
    public async Task<List<FeatureFlag>> GetFlagsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<FeatureFlag>>($"api/flags")
               ?? new List<FeatureFlag>();
    }

    // Fetch a single feature flag by ID
    public async Task<FeatureFlag?> GetFlagByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<FeatureFlag>($"api/flags/{id}");
    }

    // Create a new feature flag
    public async Task<FeatureFlag> CreateFlagAsync(FeatureFlag flag)
    {
        var response = await _httpClient.PostAsJsonAsync("api/flags", flag);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<FeatureFlag>();
    }

    // Update an existing feature flag
    public async Task UpdateFlagAsync(FeatureFlag flag)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/flags/{flag.Id}", flag);
        response.EnsureSuccessStatusCode();
    }

    // Delete a feature flag
    public async Task DeleteFlagAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/flags/{id}");
        response.EnsureSuccessStatusCode();
    }

    // Check if a feature is enabled
    public async Task<bool> IsFeatureEnabledAsync(string featureName)
    {
        var flags = await GetFlagsAsync();
        return flags.Any(f => f.Name == featureName && f.IsEnabled);
    }
}
