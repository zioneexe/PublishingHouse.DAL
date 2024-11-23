using Microsoft.EntityFrameworkCore;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.DAL.Mapper;

namespace PublishingHouse.DAL.Repository;

public class ProductionTypeRepository(PublishingHouseDbContext context) : IProductionTypeRepository
{
    public async Task<List<IProductionType>> GetAllAsync()
    {
        var productionType = await context.ProductionTypes.ToListAsync();

        return productionType.Cast<IProductionType>().ToList();
    }

    public async Task<IProductionType?> GetByIdAsync(int id)
    {
        return await context.ProductionTypes
            .FirstOrDefaultAsync(a => a.ProductionTypeId == id);
    }

    public async Task<IProductionType> AddAsync(IProductionType productionType)
    {
        ArgumentNullException.ThrowIfNull(productionType, nameof(productionType));

        var entity = productionType.ToEntity();
        await context.ProductionTypes.AddAsync(entity);
        await context.SaveChangesAsync();

        return entity;
    }

    public async Task<IProductionType?> UpdateAsync(int id, IProductionType productionType)
    {
        ArgumentNullException.ThrowIfNull(productionType, nameof(productionType));

        var existingProductionType = await context.ProductionTypes.FindAsync(id);
        if (existingProductionType == null) return null;

        var updatedEntity = productionType.ToEntity();
        updatedEntity.ProductionTypeId = id;

        context.Entry(existingProductionType).CurrentValues.SetValues(updatedEntity);
        await context.SaveChangesAsync();

        return existingProductionType;
    }

    public async Task<IProductionType?> DeleteAsync(int id)
    {
        var productionType = await context.ProductionTypes.FindAsync(id);
        if (productionType == null) return null;

        context.ProductionTypes.Remove(productionType);
        await context.SaveChangesAsync();

        return productionType;
    }
}