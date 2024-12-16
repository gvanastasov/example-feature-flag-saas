using System.Net.Http.Json;
using ExampleFeatureFlagService.Client.Models;

namespace ExampleFeatureFlagService.Client.Services;

public class FeatureFlagService
{
    private readonly HttpClient _httpClient;

    public FeatureFlagService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<FeatureFlag>> GetFlagsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<FeatureFlag>>("api/flags")
               ?? new List<FeatureFlag>();
    }

    public async Task<FeatureFlag?> GetFlagByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<FeatureFlag>($"api/flags/{id}");
    }

    public async Task CreateFlagAsync(FeatureFlag flag)
    {
        await _httpClient.PostAsJsonAsync("api/flags", flag);
    }

    public async Task UpdateFlagAsync(FeatureFlag flag)
    {
        await _httpClient.PutAsJsonAsync($"api/flags/{flag.Id}", flag);
    }

    public async Task DeleteFlagAsync(int id)
    {
        await _httpClient.DeleteAsync($"api/flags/{id}");
    }
}