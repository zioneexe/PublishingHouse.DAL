using Microsoft.EntityFrameworkCore;
using PublishingHouse.Abstractions.Entity;
using PublishingHouse.Abstractions.Exception;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.DAL.Data;
using PublishingHouse.DAL.Model;

namespace PublishingHouse.DAL.Repository
{
    public class RegionRepository(PublishingHouseDbContext context) : IRegionRepository
    {
        public async Task AddAsync(IRegion entity)
        {
            if (entity is Region regionEntity)
            {
                await context.Regions.AddAsync(regionEntity);
            }
            else
            {
                throw new InvalidOperationException("The provided entity is not of type Region.");
            }
        }

        public async Task DeleteAsync(int id)
        {
            var region = await context.Regions.FindAsync(id);
            if (region is null)
            {
                throw new RepositoryException($"Region with id {id} was not found");
            }

            context.Regions.Remove(region);
        }

        public async Task<IEnumerable<IRegion>> GetAllAsync()
        {
            return await context.Regions.ToListAsync();
        }

        public async Task<IRegion> GetByIdAsync(int id)
        {
            var region = await context.Regions.FindAsync(id);
            if (region is null)
            {
                throw new RepositoryException($"Region with id {id} was not found");
            }

            return region;
        }

        public async Task UpdateAsync(int id, IRegion entity)
        {
            var existingRegion = await context.Regions.FindAsync(id);
            if (existingRegion is null)
            {
                throw new RepositoryException($"Region with id {id} was not found.");
            }

            if (entity is Region regionEntity)
            {
                existingRegion.Name = regionEntity.Name;
                existingRegion.UpdateDateTime = regionEntity.UpdateDateTime;
            }
            else
            {
                throw new InvalidOperationException("The provided entity is not of type Region.");
            }
        }
    }
}