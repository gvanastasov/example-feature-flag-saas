using ExampleFeatureFlagService.Api.Interfaces;
using ExampleFeatureFlagService.Api.Data;
using ExampleFeatureFlagService.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ExampleFeatureFlagService.Api.Services;

public class FeatureFlagService : IFeatureFlagService
{
    private readonly FeatureFlagDbContext _context;

    public FeatureFlagService(FeatureFlagDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<FeatureFlag>> GetAllAsync()
    {
        return await _context.FeatureFlags.ToListAsync();
    }

    public async Task<FeatureFlag?> GetByIdAsync(int id)
    {
        return await _context.FeatureFlags.FindAsync(id);
    }

    public async Task<FeatureFlag> CreateAsync(FeatureFlag flag)
    {
        _context.FeatureFlags.Add(flag);
        await _context.SaveChangesAsync();
        return flag;
    }

    public async Task<FeatureFlag?> UpdateAsync(FeatureFlag flag)
    {
        var existingFlag = await _context.FeatureFlags.FindAsync(flag.Id);
        if (existingFlag == null) return null;

        existingFlag.Name = flag.Name;
        existingFlag.Description = flag.Description;
        existingFlag.IsEnabled = flag.IsEnabled;
        existingFlag.Environment = flag.Environment;
        existingFlag.Application = flag.Application;

        await _context.SaveChangesAsync();
        return existingFlag;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var flag = await _context.FeatureFlags.FindAsync(id);
        if (flag == null) return false;

        _context.FeatureFlags.Remove(flag);
        await _context.SaveChangesAsync();
        return true;
    }
}