using Microsoft.EntityFrameworkCore;
using PublishingHouse.Abstractions.Entity;
using PublishingHouse.Abstractions.Exception;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.DAL.Data;
using PublishingHouse.DAL.Model;

namespace PublishingHouse.DAL.Repository
{
    public class QualityMarkRepository(PublishingHouseDbContext context) : IQualityMarkRepository
    {
        public async Task AddAsync(IQualityMark entity)
        {
            if (entity is QualityMark qualityMarkEntity)
            {
                await context.QualityMarks.AddAsync(qualityMarkEntity);
            }
            else
            {
                throw new InvalidOperationException("The provided entity is not of type QualityMark.");
            }
        }

        public async Task DeleteAsync(int id)
        {
            var qualityMark = await context.QualityMarks.FindAsync(id);
            if (qualityMark is null)
            {
                throw new RepositoryException($"Quality mark with id {id} was not found");
            }

            context.QualityMarks.Remove(qualityMark);
        }

        public async Task<IEnumerable<IQualityMark>> GetAllAsync()
        {
            return await context.QualityMarks.ToListAsync();
        }

        public async Task<IQualityMark> GetByIdAsync(int id)
        {
            var qualityMark = await context.QualityMarks.FindAsync(id);
            if (qualityMark is null)
            {
                throw new RepositoryException($"Quality mark with id {id} was not found");
            }

            return qualityMark;
        }

        public async Task UpdateAsync(int id, IQualityMark entity)
        {
            var existingQualityMark = await context.QualityMarks.FindAsync(id);
            if (existingQualityMark is null)
            {
                throw new RepositoryException($"QualityMark with id {id} was not found.");
            }

            if (entity is QualityMark qualityMarkEntity)
            {
                existingQualityMark.Name = qualityMarkEntity.Name;
                existingQualityMark.UpdateDateTime = qualityMarkEntity.UpdateDateTime;
            }
            else
            {
                throw new InvalidOperationException("The provided entity is not of type QualityMark.");
            }
        }
    }
}