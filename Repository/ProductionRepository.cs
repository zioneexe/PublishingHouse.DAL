using Microsoft.EntityFrameworkCore;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.DAL.Mapper;

namespace PublishingHouse.DAL.Repository;

public class ProductionRepository(PublishingHouseDbContext context) : IProductionRepository
{
    public async Task<List<IProduction>> GetAllAsync()
    {
        var productions = await context.Productions
            .Include(p => p.ProductionType)
            .Include(p => p.City)
            .ToListAsync();

        return productions.Cast<IProduction>().ToList();
    }

    public async Task<IProduction?> GetByIdAsync(int id)
    {
        return await context.Productions
            .Include(p => p.ProductionType)
            .Include(p => p.City)
            .FirstOrDefaultAsync(a => a.ProductionId == id);
    }

    public async Task<IProduction> AddAsync(IProduction production)
    {
        ArgumentNullException.ThrowIfNull(production, nameof(production));

        var entity = production.ToEntity();
        await context.Productions.AddAsync(entity);
        await context.SaveChangesAsync();

        return entity;
    }

    public async Task<IProduction?> UpdateAsync(int id, IProduction production)
    {
        ArgumentNullException.ThrowIfNull(production, nameof(production));

        var existingProduction = await context.Productions.FindAsync(id);
        if (existingProduction == null) return null;

        var updatedEntity = production.ToEntity();
        updatedEntity.ProductionId = id;

        context.Entry(existingProduction).CurrentValues.SetValues(updatedEntity);
        await context.SaveChangesAsync();

        return existingProduction;
    }

    public async Task<IProduction?> DeleteAsync(int id)
    {
        var production = await context.Productions.FindAsync(id);
        if (production == null) return null;

        context.Productions.Remove(production);
        await context.SaveChangesAsync();

        return production;
    }

    public Task<List<IProduction>> GetByCityIdAsync(int cityId)
    {
        throw new NotImplementedException();
    }

    public Task<List<IProduction>> GetByProductionTypeIdAsync(int productionTypeId)
    {
        throw new NotImplementedException();
    }
}