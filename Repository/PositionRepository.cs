using Microsoft.EntityFrameworkCore;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.DAL.Mapper;

namespace PublishingHouse.DAL.Repository;

public class PositionRepository(PublishingHouseDbContext context) : IPositionRepository
{
    public async Task<List<IPosition>> GetAllAsync()
    {
        var positions = await context.Positions.ToListAsync();

        return positions.Cast<IPosition>().ToList();
    }

    public async Task<IPosition?> GetByIdAsync(int id)
    {
        return await context.Positions
            .FirstOrDefaultAsync(a => a.PositionId == id);
    }

    public async Task<IPosition> AddAsync(IPosition position)
    {
        ArgumentNullException.ThrowIfNull(position, nameof(position));

        var entity = position.ToEntity();
        await context.Positions.AddAsync(entity);
        await context.SaveChangesAsync();

        return entity;
    }

    public async Task<IPosition?> UpdateAsync(int id, IPosition position)
    {
        ArgumentNullException.ThrowIfNull(position, nameof(position));

        var existingPosition = await context.Positions.FindAsync(id);
        if (existingPosition == null) return null;

        var updatedEntity = position.ToEntity();
        updatedEntity.PositionId = id;

        context.Entry(existingPosition).CurrentValues.SetValues(updatedEntity);
        await context.SaveChangesAsync();

        return existingPosition;
    }

    public async Task<IPosition?> DeleteAsync(int id)
    {
        var position = await context.Positions.FindAsync(id);
        if (position == null) return null;

        context.Positions.Remove(position);
        await context.SaveChangesAsync();

        return position;
    }

    public Task<IPosition?> GetByNameAsync(string name)
    {
        throw new NotImplementedException();
    }
}