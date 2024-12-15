using FeatureFlagService.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace FeatureFlagService.Api.Data;

public class FeatureFlagDbContext : DbContext
{
    public FeatureFlagDbContext(DbContextOptions<FeatureFlagDbContext> options) 
        : base(options) { }

    public DbSet<FeatureFlag> FeatureFlags { get; set; }
}