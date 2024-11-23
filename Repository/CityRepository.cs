using Microsoft.EntityFrameworkCore;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.DAL.Mapper;

namespace PublishingHouse.DAL.Repository;

public class CityRepository(PublishingHouseDbContext context) : ICityRepository
{
    public async Task<List<ICity>> GetAllAsync()
    {
        var cities = await context.Cities.Include(r => r.Region).ToListAsync();

        return cities.Cast<ICity>().ToList();
    }

    public async Task<ICity?> GetByIdAsync(int id)
    {
        return await context.Cities.Include(r => r.Region)
            .FirstOrDefaultAsync(a => a.CityId == id);
    }

    public async Task<ICity> AddAsync(ICity city)
    {
        ArgumentNullException.ThrowIfNull(city, nameof(city));

        var entity = city.ToEntity();
        await context.Cities.AddAsync(entity);
        await context.SaveChangesAsync();

        return entity;
    }

    public async Task<ICity?> UpdateAsync(int id, ICity city)
    {
        ArgumentNullException.ThrowIfNull(city, nameof(city));

        var existingCity = await context.Cities.FindAsync(id);
        if (existingCity == null) return null;

        var updatedEntity = city.ToEntity();
        updatedEntity.CityId = id;

        context.Entry(existingCity).CurrentValues.SetValues(updatedEntity);
        await context.SaveChangesAsync();

        return existingCity;
    }

    public async Task<ICity?> DeleteAsync(int id)
    {
        var city = await context.Cities.FindAsync(id);
        if (city == null) return null;

        context.Cities.Remove(city);
        await context.SaveChangesAsync();

        return city;
    }

    public Task<List<ICity>> GetByRegionIdAsync(int regionId)
    {
        throw new NotImplementedException();
    }
}