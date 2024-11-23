using Microsoft.EntityFrameworkCore;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.DAL.Mapper;

namespace PublishingHouse.DAL.Repository;

public class OrderStatusRepository(PublishingHouseDbContext context) : IOrderStatusRepository
{
    public async Task<List<IOrderStatus>> GetAllAsync()
    {
        var orderStatuses = await context.OrderStatuses.ToListAsync();

        return orderStatuses.Cast<IOrderStatus>().ToList();
    }

    public async Task<IOrderStatus?> GetByIdAsync(int id)
    {
        return await context.OrderStatuses
            .FirstOrDefaultAsync(a => a.OrderStatusId == id);
    }

    public async Task<IOrderStatus> AddAsync(IOrderStatus orderStatus)
    {
        ArgumentNullException.ThrowIfNull(orderStatus, nameof(orderStatus));

        var entity = orderStatus.ToEntity();
        await context.OrderStatuses.AddAsync(entity);
        await context.SaveChangesAsync();

        return entity;
    }

    public async Task<IOrderStatus?> UpdateAsync(int id, IOrderStatus orderStatus)
    {
        ArgumentNullException.ThrowIfNull(orderStatus, nameof(orderStatus));

        var existingOrderStatus = await context.OrderStatuses.FindAsync(id);
        if (existingOrderStatus == null) return null;

        var updatedEntity = orderStatus.ToEntity();
        updatedEntity.OrderStatusId = id;

        context.Entry(existingOrderStatus).CurrentValues.SetValues(updatedEntity);
        await context.SaveChangesAsync();

        return existingOrderStatus;
    }

    public async Task<IOrderStatus?> DeleteAsync(int id)
    {
        var orderStatus = await context.OrderStatuses.FindAsync(id);
        if (orderStatus == null) return null;

        context.OrderStatuses.Remove(orderStatus);
        await context.SaveChangesAsync();

        return orderStatus;
    }

    public Task<IOrderStatus?> GetByNameAsync(string name)
    {
        throw new NotImplementedException();
    }
}