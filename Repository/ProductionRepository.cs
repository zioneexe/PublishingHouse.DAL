using Microsoft.EntityFrameworkCore;
using PublishingHouse.Abstractions.Entity;
using PublishingHouse.Abstractions.Exception;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.DAL.Data;
using PublishingHouse.DAL.Model;

namespace PublishingHouse.DAL.Repository
{
    public class ProductionRepository(PublishingHouseDbContext context) : IProductionRepository
    {
        public async Task AddAsync(IProduction entity)
        {
            if (entity is Production productionEntity)
            {
                await context.Productions.AddAsync(productionEntity);
            }
            else
            {
                throw new InvalidOperationException("The provided entity is not of type Production.");
            }
        }

        public async Task DeleteAsync(int id)
        {
            var production = await context.Productions.FindAsync(id);
            if (production is null)
            {
                throw new RepositoryException($"Production with id {id} was not found.");
            }

            context.Productions.Remove(production);
        }

        public async Task<IEnumerable<IProduction>> GetAllAsync()
        {
            return await context.Productions
                .Include(p => p.ProductionType)
                .Include(p => p.City)
                .ToListAsync();
        }

        public async Task<IProduction> GetByIdAsync(int id)
        {
            var production = await context.Productions
                .Include(p => p.ProductionType)
                .Include(p => p.City)
                .FirstOrDefaultAsync(p => p.ProductionId == id);

            if (production is null)
            {
                throw new RepositoryException($"Production with id {id} was not found.");
            }

            return production;
        }

        public async Task UpdateAsync(int id, IProduction entity)
        {
            var existingProduction = await context.Productions.FindAsync(id);
            if (existingProduction is null)
            {
                throw new RepositoryException($"Production with id {id} was not found.");
            }

            if (entity is Production productionEntity)
            {
                existingProduction.ProductionTypeId = productionEntity.ProductionTypeId;
                existingProduction.CityId = productionEntity.CityId;
                existingProduction.Address = productionEntity.Address;
                existingProduction.UpdateDateTime = productionEntity.UpdateDateTime;
            }
            else
            {
                throw new InvalidOperationException("The provided entity is not of type Production.");
            }
        }

        public async Task<IEnumerable<IProduction>> GetByCityIdAsync(int cityId)
        {
            return await context.Productions
                .Where(p => p.CityId == cityId)
                .Include(p => p.ProductionType)
                .Include(p => p.City)
                .ToListAsync();
        }

        public async Task<IEnumerable<IProduction>> GetByProductionTypeIdAsync(int productionTypeId)
        {
            return await context.Productions
                .Where(p => p.ProductionTypeId == productionTypeId)
                .Include(p => p.ProductionType)
                .Include(p => p.City)
                .ToListAsync();
        }
    }
}
