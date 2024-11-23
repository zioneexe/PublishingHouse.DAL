using Microsoft.EntityFrameworkCore;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.DAL.Mapper;

namespace PublishingHouse.DAL.Repository;

public class PrintOrderRepository(PublishingHouseDbContext context) : IPrintOrderRepository
{
    public async Task<List<IPrintOrder>> GetAllAsync()
    {
        var printOrders = await context.PrintOrders
            .Include(po => po.Customer)
            .Include(po => po.Employee)
            .Include(po => po.OrderStatus)
            .ToListAsync();

        return printOrders.Cast<IPrintOrder>().ToList();
    }

    public async Task<IPrintOrder?> GetByIdAsync(int id)
    {
        return await context.PrintOrders
            .Include(po => po.Customer)
            .Include(po => po.Employee)
            .Include(po => po.OrderStatus)
            .FirstOrDefaultAsync(po => po.OrderId == id);
    }

    public async Task<IPrintOrder> AddAsync(IPrintOrder printOrder)
    {
        ArgumentNullException.ThrowIfNull(printOrder, nameof(printOrder));

        var entity = printOrder.ToEntity();
        await context.PrintOrders.AddAsync(entity);
        await context.SaveChangesAsync();

        return entity;
    }

    public async Task<IPrintOrder?> UpdateAsync(int id, IPrintOrder printOrder)
    {
        ArgumentNullException.ThrowIfNull(printOrder, nameof(printOrder));

        var existingPrintOrder = await context.PrintOrders.FindAsync(id);
        if (existingPrintOrder == null) return null;

        var updatedEntity = printOrder.ToEntity();
        updatedEntity.OrderId = id;

        context.Entry(existingPrintOrder).CurrentValues.SetValues(updatedEntity);
        await context.SaveChangesAsync();

        return existingPrintOrder;
    }

    public async Task<IPrintOrder?> DeleteAsync(int id)
    {
        var printOrder = await context.PrintOrders.FindAsync(id);
        if (printOrder == null) return null;

        context.PrintOrders.Remove(printOrder);
        await context.SaveChangesAsync();

        return printOrder;
    }

    public Task<List<IPrintOrder>> GetByCustomerIdAsync(int customerId)
    {
        throw new NotImplementedException();
    }

    public Task<List<IPrintOrder>> GetByEmployeeIdAsync(int employeeId)
    {
        throw new NotImplementedException();
    }

    public Task<List<IPrintOrder>> GetByOrderStatusIdAsync(int orderStatusId)
    {
        throw new NotImplementedException();
    }
}