using Microsoft.EntityFrameworkCore;
using PublishingHouse.Abstractions.Entity;
using PublishingHouse.Abstractions.Exception;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.DAL.Data;
using PublishingHouse.DAL.Model;

namespace PublishingHouse.DAL.Repository
{
    public class CityRepository(PublishingHouseDbContext context) : ICityRepository
    {
        public async Task AddAsync(ICity entity)
        {
            if (entity is City cityEntity)
            {
                await context.Cities.AddAsync(cityEntity);
            }
            else
            {
                throw new InvalidOperationException("The provided entity is not of type City.");
            }
        }

        public async Task DeleteAsync(int id)
        {
            var city = await context.Cities.FindAsync(id);
            if (city is null)
            {
                throw new RepositoryException($"City with id {id} was not found.");
            }

            context.Cities.Remove(city);
        }

        public async Task<IEnumerable<ICity>> GetAllAsync()
        {
            return await context.Cities.Include(c => c.Region).ToListAsync();
        }

        public async Task<ICity> GetByIdAsync(int id)
        {
            var city = await context.Cities.Include(c => c.Region)
                .FirstOrDefaultAsync(c => c.CityId == id);
            if (city is null)
            {
                throw new RepositoryException($"City with id {id} was not found.");
            }

            return city;
        }

        public async Task UpdateAsync(int id, ICity entity)
        {
            var existingCity = await context.Cities.FindAsync(id);
            if (existingCity is null)
            {
                throw new RepositoryException($"City with id {id} was not found.");
            }

            if (entity is City cityEntity)
            {
                existingCity.RegionId = cityEntity.RegionId;
                existingCity.Name = cityEntity.Name;
                existingCity.UpdateDateTime = cityEntity.UpdateDateTime;
            }
            else
            {
                throw new InvalidOperationException("The provided entity is not of type City.");
            }
        }

        public async Task<IEnumerable<ICity>> GetByRegionIdAsync(int regionId)
        {
            return await context.Cities
                .Where(c => c.RegionId == regionId)
                .Include(c => c.Region)
                .ToListAsync();
        }
    }
}
