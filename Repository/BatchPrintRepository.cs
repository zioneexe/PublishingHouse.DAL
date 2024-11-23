using Microsoft.EntityFrameworkCore;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.DAL.Mapper;

namespace PublishingHouse.DAL.Repository;

public class BatchPrintRepository(PublishingHouseDbContext context) : IBatchPrintRepository
{
    public async Task<List<IBatchPrint>> GetAllAsync()
    {
        var batchPrints = await context.BatchPrints
            .Include(bp => bp.Order)
            .Include(bp => bp.QualityMark)
            .ToListAsync();

        return batchPrints.Cast<IBatchPrint>().ToList();
    }

    public async Task<IBatchPrint?> GetByIdAsync(int id)
    {
        return await context.BatchPrints
            .Include(bp => bp.Order)
            .Include(bp => bp.QualityMark)
            .FirstOrDefaultAsync(a => a.BatchPrintId == id);
    }

    public async Task<IBatchPrint> AddAsync(IBatchPrint batchPrint)
    {
        ArgumentNullException.ThrowIfNull(batchPrint, nameof(batchPrint));

        var entity = batchPrint.ToEntity();
        await context.BatchPrints.AddAsync(entity);
        await context.SaveChangesAsync();

        return entity;
    }

    public async Task<IBatchPrint?> UpdateAsync(int id, IBatchPrint batchPrint)
    {
        ArgumentNullException.ThrowIfNull(batchPrint, nameof(batchPrint));

        var existingBatchPrint = await context.BatchPrints.FindAsync(id);
        if (existingBatchPrint == null) return null;

        var updatedEntity = batchPrint.ToEntity();
        updatedEntity.BatchPrintId = id;

        context.Entry(existingBatchPrint).CurrentValues.SetValues(updatedEntity);
        await context.SaveChangesAsync();

        return existingBatchPrint;
    }

    public async Task<IBatchPrint?> DeleteAsync(int id)
    {
        var batchPrint = await context.BatchPrints.FindAsync(id);
        if (batchPrint == null) return null;

        context.BatchPrints.Remove(batchPrint);
        await context.SaveChangesAsync();

        return batchPrint;
    }

    public Task<List<IBatchPrint>> GetByPrintOrderIdAsync(int printOrderId)
    {
        throw new NotImplementedException();
    }

    public Task<List<IBatchPrint>> GetByQualityMarkIdAsync(int qualityMarkId)
    {
        throw new NotImplementedException();
    }
}