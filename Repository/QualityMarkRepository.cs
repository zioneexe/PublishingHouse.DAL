using Microsoft.EntityFrameworkCore;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.DAL.Mapper;

namespace PublishingHouse.DAL.Repository;

public class QualityMarkRepository(PublishingHouseDbContext context) : IQualityMarkRepository
{
    public async Task<List<IQualityMark>> GetAllAsync()
    {
        var qualityMarks = await context.QualityMarks.ToListAsync();

        return qualityMarks.Cast<IQualityMark>().ToList();
    }

    public async Task<IQualityMark?> GetByIdAsync(int id)
    {
        return await context.QualityMarks
            .FirstOrDefaultAsync(a => a.QualityMarkId == id);
    }

    public async Task<IQualityMark> AddAsync(IQualityMark qualityMark)
    {
        ArgumentNullException.ThrowIfNull(qualityMark, nameof(qualityMark));

        var entity = qualityMark.ToEntity();
        await context.QualityMarks.AddAsync(entity);
        await context.SaveChangesAsync();

        return entity;
    }

    public async Task<IQualityMark?> UpdateAsync(int id, IQualityMark qualityMark)
    {
        ArgumentNullException.ThrowIfNull(qualityMark, nameof(qualityMark));

        var existingQualityMark = await context.QualityMarks.FindAsync(id);
        if (existingQualityMark == null) return null;

        var updatedEntity = qualityMark.ToEntity();
        updatedEntity.QualityMarkId = id;

        context.Entry(existingQualityMark).CurrentValues.SetValues(updatedEntity);
        await context.SaveChangesAsync();

        return existingQualityMark;
    }

    public async Task<IQualityMark?> DeleteAsync(int id)
    {
        var qualityMark = await context.QualityMarks.FindAsync(id);
        if (qualityMark == null) return null;

        context.QualityMarks.Remove(qualityMark);
        await context.SaveChangesAsync();

        return qualityMark;
    }
}