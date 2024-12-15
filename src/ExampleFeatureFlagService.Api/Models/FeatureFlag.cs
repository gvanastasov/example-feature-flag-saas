namespace FeatureFlagService.Api.Models;

public class FeatureFlag
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsEnabled { get; set; }
    public string Environment { get; set; } = "Production";
    public string Application { get; set; } = "DefaultApp";
}