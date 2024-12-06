using Microsoft.EntityFrameworkCore;
using PublishingHouse.Abstractions.Entity;
using PublishingHouse.Abstractions.Exception;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.DAL.Data;
using PublishingHouse.DAL.Model;

namespace PublishingHouse.DAL.Repository
{
    public class PrintOrderRepository(PublishingHouseDbContext context) : IPrintOrderRepository
    {
        public async Task AddAsync(IPrintOrder entity)
        {
            if (entity is PrintOrder printOrderEntity)
            {
                await context.PrintOrders.AddAsync(printOrderEntity);
            }
            else
            {
                throw new InvalidOperationException("The provided entity is not of type Order.");
            }
        }

        public async Task DeleteAsync(int id)
        {
            var printOrder = await context.PrintOrders
                                 .Include(po => po.BatchPrints) 
                                 .FirstOrDefaultAsync(po => po.OrderId == id)
                             ?? throw new RepositoryException($"Order with id {id} was not found.");

            if (printOrder.BatchPrints.Count != 0)
            {
                context.BatchPrints.RemoveRange(printOrder.BatchPrints);
            }

            context.PrintOrders.Remove(printOrder);
        }

        public async Task<IEnumerable<IPrintOrder>> GetAllAsync()
        {
            return await context.PrintOrders
                .Include(po => po.Customer)
                .Include(po => po.Employee)
                .Include(po => po.OrderStatus)
                .ToListAsync();
        }

        public async Task<IPrintOrder> GetByIdAsync(int id)
        {
            var printOrder = await context.PrintOrders
                .Include(po => po.Customer)
                .Include(po => po.Employee)
                .Include(po => po.OrderStatus)
                .FirstOrDefaultAsync(po => po.OrderId == id);

            return printOrder is null ? throw new RepositoryException($"Order with id {id} was not found.") : (IPrintOrder)printOrder;
        }

        public async Task UpdateAsync(int id, IPrintOrder entity)
        {
            var existingPrintOrder = await context.PrintOrders.FindAsync(id) ?? throw new RepositoryException($"Order with id {id} was not found.");
            if (entity is PrintOrder printOrderEntity)
            {
                existingPrintOrder.Number = entity.Number;
                existingPrintOrder.PrintType = entity.PrintType;
                existingPrintOrder.PaperType = entity.PaperType;
                existingPrintOrder.CoverType = entity.CoverType;
                existingPrintOrder.FasteningType = entity.FasteningType;
                existingPrintOrder.IsLaminated = entity.IsLaminated;
                existingPrintOrder.Price = entity.Price;
                existingPrintOrder.OrderStatusId = entity.OrderStatusId;
                existingPrintOrder.RegistrationDate = entity.RegistrationDate;
                existingPrintOrder.CompletionDate = entity.CompletionDate;
                existingPrintOrder.CustomerId = entity.CustomerId;
                existingPrintOrder.EmployeeId = entity.EmployeeId;
                existingPrintOrder.UpdateDateTime = entity.UpdateDateTime;
            }
            else
            {
                throw new InvalidOperationException("The provided entity is not of type Order.");
            }
        }

        public async Task<IEnumerable<IPrintOrder>> GetByCustomerIdAsync(int customerId)
        {
            return await context.PrintOrders
                .Where(po => po.CustomerId == customerId)
                .Include(po => po.Customer)
                .Include(po => po.Employee)
                .Include(po => po.OrderStatus)
                .ToListAsync();
        }

        public async Task<IEnumerable<IPrintOrder>> GetByEmployeeIdAsync(int employeeId)
        {
            return await context.PrintOrders
                .Where(po => po.EmployeeId == employeeId)
                .Include(po => po.Customer)
                .Include(po => po.Employee)
                .Include(po => po.OrderStatus)
                .ToListAsync();
        }

        public async Task<IEnumerable<IPrintOrder>> GetByOrderStatusIdAsync(int orderStatusId)
        {
            return await context.PrintOrders
                .Where(po => po.OrderStatusId == orderStatusId)
                .Include(po => po.Customer)
                .Include(po => po.Employee)
                .Include(po => po.OrderStatus)
                .ToListAsync();
        }

        public async Task UpdateOrderStatusAsync(int orderId, IOrderStatus orderStatus)
        {
            var order = await GetByIdAsync(orderId);
            if (order == null) throw new KeyNotFoundException($"Order with ID {orderId} not found.");

            order.OrderStatus = orderStatus;
        }

        public async Task<int> AddWithIdAsync(IPrintOrder entity)
        {
            if (entity is PrintOrder printOrderEntity)
            {
                await context.PrintOrders.AddAsync(printOrderEntity);
                await context.SaveChangesAsync();

                return printOrderEntity.OrderId;
            }
            else
            {
                throw new InvalidOperationException("The provided entity is not of type Order.");
            }
        }
    }
}
