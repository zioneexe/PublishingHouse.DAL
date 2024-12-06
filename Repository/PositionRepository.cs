using Microsoft.EntityFrameworkCore;
using PublishingHouse.Abstractions.Entity;
using PublishingHouse.Abstractions.Exception;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.DAL.Data;
using PublishingHouse.DAL.Model;

namespace PublishingHouse.DAL.Repository
{
    public class PositionRepository(PublishingHouseDbContext context) : IPositionRepository
    {
        public async Task AddAsync(IPosition entity)
        {
            if (entity is Position positionEntity)
            {
                await context.Positions.AddAsync(positionEntity);
            }
            else
            {
                throw new InvalidOperationException("The provided entity is not of type Position.");
            }
        }

        public async Task DeleteAsync(int id)
        {
            var position = await context.Positions.FindAsync(id);
            if (position is null)
            {
                throw new RepositoryException($"Position with id {id} was not found.");
            }

            context.Positions.Remove(position);
        }

        public async Task<IEnumerable<IPosition>> GetAllAsync()
        {
            return await context.Positions.ToListAsync();
        }

        public async Task<IPosition> GetByIdAsync(int id)
        {
            var position = await context.Positions.FindAsync(id);
            if (position is null)
            {
                throw new RepositoryException($"Position with id {id} was not found.");
            }

            return position;
        }

        public async Task UpdateAsync(int id, IPosition entity)
        {
            var existingPosition = await context.Positions.FindAsync(id);
            if (existingPosition is null)
            {
                throw new RepositoryException($"Position with id {id} was not found.");
            }

            if (entity is Position positionEntity)
            {
                existingPosition.Name = positionEntity.Name;
                existingPosition.UpdateDateTime = positionEntity.UpdateDateTime;
            }
            else
            {
                throw new InvalidOperationException("The provided entity is not of type Position.");
            }
        }

        public async Task<IPosition?> GetByNameAsync(string name)
        {
            return await context.Positions
                .FirstOrDefaultAsync(p => p.Name == name);
        }
    }
}
