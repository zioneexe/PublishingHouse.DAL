using Microsoft.EntityFrameworkCore;
using PublishingHouse.Abstractions.Entity;
using PublishingHouse.Abstractions.Exception;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.DAL.Data;
using PublishingHouse.DAL.Model;

namespace PublishingHouse.DAL.Repository
{
    public class ProductionTypeRepository(PublishingHouseDbContext context) : IProductionTypeRepository
    {
        public async Task AddAsync(IProductionType entity)
        {
            if (entity is ProductionType productionTypeEntity)
            {
                await context.ProductionTypes.AddAsync(productionTypeEntity);
            }
            else
            {
                throw new InvalidOperationException("The provided entity is not of type ProductionType.");
            }
        }

        public async Task DeleteAsync(int id)
        {
            var productionType = await context.ProductionTypes.FindAsync(id);
            if (productionType is null)
            {
                throw new RepositoryException($"ProductionType with id {id} was not found.");
            }

            context.ProductionTypes.Remove(productionType);
        }

        public async Task<IEnumerable<IProductionType>> GetAllAsync()
        {
            return await context.ProductionTypes.ToListAsync();
        }

        public async Task<IProductionType> GetByIdAsync(int id)
        {
            var productionType = await context.ProductionTypes.FindAsync(id);
            if (productionType is null)
            {
                throw new RepositoryException($"ProductionType with id {id} was not found.");
            }

            return productionType;
        }

        public async Task UpdateAsync(int id, IProductionType entity)
        {
            var existingProductionType = await context.ProductionTypes.FindAsync(id);
            if (existingProductionType is null)
            {
                throw new RepositoryException($"ProductionType with id {id} was not found.");
            }

            if (entity is ProductionType productionTypeEntity)
            {
                existingProductionType.Name = productionTypeEntity.Name;
                existingProductionType.UpdateDateTime = productionTypeEntity.UpdateDateTime;
            }
            else
            {
                throw new InvalidOperationException("The provided entity is not of type ProductionType.");
            }
        }
    }
}
