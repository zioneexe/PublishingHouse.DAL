using Microsoft.EntityFrameworkCore;
using PublishingHouse.Abstractions.Entity;
using PublishingHouse.Abstractions.Exception;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.DAL.Data;
using PublishingHouse.DAL.Model;

namespace PublishingHouse.DAL.Repository
{
    public class BatchPrintRepository(PublishingHouseDbContext context) : IBatchPrintRepository
    {
        public async Task AddAsync(IBatchPrint entity)
        {
            if (entity is BatchPrint batchPrintEntity)
            {
                await context.BatchPrints.AddAsync(batchPrintEntity);
            }
            else
            {
                throw new InvalidOperationException("The provided entity is not of type BatchPrint.");
            }
        }

        public async Task DeleteAsync(int id)
        {
            var batchPrint = await context.BatchPrints.FindAsync(id);
            if (batchPrint is null)
            {
                throw new RepositoryException($"BatchPrint with id {id} was not found.");
            }

            context.BatchPrints.Remove(batchPrint);
        }

        public async Task<IEnumerable<IBatchPrint>> GetAllAsync()
        {
            return await context.BatchPrints
                .Include(bp => bp.Order)
                .Include(bp => bp.QualityMark)
                .ToListAsync();
        }

        public async Task<IBatchPrint> GetByIdAsync(int id)
        {
            var batchPrint = await context.BatchPrints
                .Include(bp => bp.Order)
                .Include(bp => bp.QualityMark)
                .FirstOrDefaultAsync(bp => bp.BatchPrintId == id);

            if (batchPrint is null)
            {
                throw new RepositoryException($"BatchPrint with id {id} was not found.");
            }

            return batchPrint;
        }

        public async Task UpdateAsync(int id, IBatchPrint entity)
        {
            var existingBatchPrint = await context.BatchPrints.FindAsync(id);
            if (existingBatchPrint is null)
            {
                throw new RepositoryException($"BatchPrint with id {id} was not found.");
            }

            if (entity is BatchPrint batchPrintEntity)
            {
                existingBatchPrint.Number = batchPrintEntity.Number;
                existingBatchPrint.BookQuantity = batchPrintEntity.BookQuantity;
                existingBatchPrint.OrderId = batchPrintEntity.OrderId;
                existingBatchPrint.PrintDate = batchPrintEntity.PrintDate;
                existingBatchPrint.QualityMarkId = batchPrintEntity.QualityMarkId;
                existingBatchPrint.UpdateDateTime = batchPrintEntity.UpdateDateTime;
            }
            else
            {
                throw new InvalidOperationException("The provided entity is not of type BatchPrint.");
            }
        }

        public async Task<IEnumerable<IBatchPrint>> GetByPrintOrderIdAsync(int printOrderId)
        {
            return await context.BatchPrints
                .Where(bp => bp.OrderId == printOrderId)
                .Include(bp => bp.Order)
                .Include(bp => bp.QualityMark)
                .ToListAsync();
        }

        public async Task<IEnumerable<IBatchPrint>> GetByQualityMarkIdAsync(int qualityMarkId)
        {
            return await context.BatchPrints
                .Where(bp => bp.QualityMarkId == qualityMarkId)
                .Include(bp => bp.Order)
                .Include(bp => bp.QualityMark)
                .ToListAsync();
        }
    }
}
