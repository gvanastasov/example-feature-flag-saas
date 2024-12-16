using System.Net.Http.Json;
using System.Text.Json;
using ExampleFeatureFlagService.Client.Models;

namespace ExampleFeatureFlagService.Client.Services;

public class FeatureFlagService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<FeatureFlagService> _logger;

        public FeatureFlagService(IHttpClientFactory httpClientFactory, ILogger<FeatureFlagService> logger)
        {
            _httpClient = httpClientFactory.CreateClient("FeatureFlagService");
            _logger = logger;
        }

        public async Task<List<FeatureFlag>> GetFlagsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/flags");
                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();
                _logger.LogInformation("API Response: {jsonResponse}", jsonResponse);

                var flags = JsonSerializer.Deserialize<List<FeatureFlag>>(jsonResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return flags ?? new List<FeatureFlag>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching flags.");
                return new List<FeatureFlag>();
            }
        }

        public async Task<FeatureFlag?> GetFlagByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/flags/{id}");
                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();
                _logger.LogInformation("API Response: {jsonResponse}", jsonResponse);

                var flag = JsonSerializer.Deserialize<FeatureFlag>(jsonResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return flag;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching flag by ID.");
                return null;
            }
        }

        public async Task CreateFlagAsync(FeatureFlag flag)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/flags", flag);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating flag.");
            }
        }

        public async Task UpdateFlagAsync(FeatureFlag flag)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"api/flags/{flag.Id}", flag);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating flag.");
            }
        }

        public async Task DeleteFlagAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/flags/{id}");
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting flag.");
            }
        }
    }