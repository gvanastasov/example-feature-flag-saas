using ExampleFeatureFlagService.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ExampleFeatureFlagService.Api.Data;

public class FeatureFlagDbContext : DbContext
{
    public FeatureFlagDbContext(DbContextOptions<FeatureFlagDbContext> options) 
        : base(options) 
    { 
        FeatureFlags = Set<FeatureFlag>();
    }

    public DbSet<FeatureFlag> FeatureFlags { get; set; }
}