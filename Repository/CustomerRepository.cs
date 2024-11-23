using Microsoft.EntityFrameworkCore;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.DAL.Mapper;

namespace PublishingHouse.DAL.Repository;

public class CustomerRepository(PublishingHouseDbContext context) : ICustomerRepository
{
    public async Task<List<ICustomer>> GetAllAsync()
    {
        var admins = await context.Customers.Include(c => c.CustomerType).ToListAsync();

        return admins.Cast<ICustomer>().ToList();
    }

    public async Task<ICustomer?> GetByIdAsync(int id)
    {
        return await context.Customers.Include(c => c.CustomerType)
            .FirstOrDefaultAsync(a => a.CustomerId == id);
    }

    public async Task<ICustomer> AddAsync(ICustomer customer)
    {
        ArgumentNullException.ThrowIfNull(customer, nameof(customer));

        var entity = customer.ToEntity();
        await context.Customers.AddAsync(entity);
        await context.SaveChangesAsync();

        return entity;
    }

    public async Task<ICustomer?> UpdateAsync(int id, ICustomer customer)
    {
        ArgumentNullException.ThrowIfNull(customer, nameof(customer));

        var existingCustomer = await context.Customers.FindAsync(id);
        if (existingCustomer == null) return null;

        var updatedEntity = customer.ToEntity();
        updatedEntity.CustomerId = id;

        context.Entry(existingCustomer).CurrentValues.SetValues(updatedEntity);
        await context.SaveChangesAsync();

        return existingCustomer;
    }

    public async Task<ICustomer?> DeleteAsync(int id)
    {
        var customer = await context.Customers.FindAsync(id);
        if (customer == null) return null;

        context.Customers.Remove(customer);
        await context.SaveChangesAsync();

        return customer;
    }

    public Task<List<ICustomer>> GetByCustomerTypeIdAsync(int customerTypeId)
    {
        throw new NotImplementedException();
    }
}