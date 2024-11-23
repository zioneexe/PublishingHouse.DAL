using Microsoft.EntityFrameworkCore;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.DAL.Mapper;

namespace PublishingHouse.DAL.Repository;

public class RegionRepository(PublishingHouseDbContext context) : IRegionRepository
{
    public async Task<List<IRegion>> GetAllAsync()
    {
        var regions = await context.Regions.ToListAsync();

        return regions.Cast<IRegion>().ToList();
    }

    public async Task<IRegion?> GetByIdAsync(int id)
    {
        return await context.Regions
            .FirstOrDefaultAsync(a => a.RegionId == id);
    }

    public async Task<IRegion> AddAsync(IRegion region)
    {
        ArgumentNullException.ThrowIfNull(region, nameof(region));

        var entity = region.ToEntity();
        await context.Regions.AddAsync(entity);
        await context.SaveChangesAsync();

        return entity;
    }

    public async Task<IRegion?> UpdateAsync(int id, IRegion region)
    {
        ArgumentNullException.ThrowIfNull(region, nameof(region));

        var existingRegion = await context.Regions.FindAsync(id);
        if (existingRegion == null) return null;

        var updatedEntity = region.ToEntity();
        updatedEntity.RegionId = id;

        context.Entry(existingRegion).CurrentValues.SetValues(updatedEntity);
        await context.SaveChangesAsync();

        return existingRegion;
    }

    public async Task<IRegion?> DeleteAsync(int id)
    {
        var region = await context.Regions.FindAsync(id);
        if (region == null) return null;

        context.Regions.Remove(region);
        await context.SaveChangesAsync();

        return region;
    }
}