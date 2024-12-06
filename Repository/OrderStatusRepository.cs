using Microsoft.EntityFrameworkCore;
using PublishingHouse.Abstractions.Entity;
using PublishingHouse.Abstractions.Exception;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.DAL.Data;
using PublishingHouse.DAL.Model;

namespace PublishingHouse.DAL.Repository
{
    public class OrderStatusRepository(PublishingHouseDbContext context) : IOrderStatusRepository
    {
        public async Task AddAsync(IOrderStatus entity)
        {
            if (entity is OrderStatus orderStatusEntity)
            {
                await context.OrderStatuses.AddAsync(orderStatusEntity);
            }
            else
            {
                throw new InvalidOperationException("The provided entity is not of type OrderStatus.");
            }
        }

        public async Task DeleteAsync(int id)
        {
            var orderStatus = await context.OrderStatuses.FindAsync(id);
            if (orderStatus is null)
            {
                throw new RepositoryException($"OrderStatus with id {id} was not found.");
            }

            context.OrderStatuses.Remove(orderStatus);
        }

        public async Task<IEnumerable<IOrderStatus>> GetAllAsync()
        {
            return await context.OrderStatuses.ToListAsync();
        }

        public async Task<IOrderStatus> GetByIdAsync(int id)
        {
            var orderStatus = await context.OrderStatuses.FindAsync(id);
            if (orderStatus is null)
            {
                throw new RepositoryException($"OrderStatus with id {id} was not found.");
            }

            return orderStatus;
        }

        public async Task UpdateAsync(int id, IOrderStatus entity)
        {
            var existingOrderStatus = await context.OrderStatuses.FindAsync(id);
            if (existingOrderStatus is null)
            {
                throw new RepositoryException($"OrderStatus with id {id} was not found.");
            }

            if (entity is OrderStatus orderStatusEntity)
            {
                existingOrderStatus.Name = orderStatusEntity.Name;
                existingOrderStatus.UpdateDateTime = orderStatusEntity.UpdateDateTime;
            }
            else
            {
                throw new InvalidOperationException("The provided entity is not of type OrderStatus.");
            }
        }

        public async Task<IOrderStatus?> GetByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Order status name cannot be null or empty.", nameof(name));

            return await context.OrderStatuses
                .FirstOrDefaultAsync(os => EF.Functions.Like(os.Name!, name));
        }

    }
}
