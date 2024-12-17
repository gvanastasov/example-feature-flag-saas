using System.Net.Http.Json;
using ExampleFeatureFlagService.ExampleApp.Models;

namespace ExampleFeatureFlagService.ExampleApp.Services;

public class FeatureFlagService
{
    private readonly HttpClient _httpClient;

    public FeatureFlagService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<FeatureFlag>> GetFlagsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<FeatureFlag>>($"api/flags")
               ?? new List<FeatureFlag>();
    }
}