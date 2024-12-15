using FeatureFlagService.Api.Models;

namespace ExampleFeatureFlagService.Api.Interfaces;

public interface IFeatureFlagService
{
    Task<IEnumerable<FeatureFlag>> GetAllAsync();
    Task<FeatureFlag?> GetByIdAsync(int id);
    Task<FeatureFlag> CreateAsync(FeatureFlag flag);
    Task<FeatureFlag?> UpdateAsync(FeatureFlag flag);
    Task<bool> DeleteAsync(int id);
}