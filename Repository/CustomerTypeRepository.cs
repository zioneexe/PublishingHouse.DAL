using Microsoft.EntityFrameworkCore;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.DAL.Mapper;

namespace PublishingHouse.DAL.Repository;

public class CustomerTypeRepository(PublishingHouseDbContext context) : ICustomerTypeRepository
{
    public async Task<List<ICustomerType>> GetAllAsync()
    {
        var customerTypes = await context.CustomerTypes.ToListAsync();

        return customerTypes.Cast<ICustomerType>().ToList();
    }

    public async Task<ICustomerType?> GetByIdAsync(int id)
    {
        return await context.CustomerTypes
            .FirstOrDefaultAsync(a => a.CustomerTypeId == id);
    }

    public async Task<ICustomerType> AddAsync(ICustomerType customerType)
    {
        ArgumentNullException.ThrowIfNull(customerType, nameof(customerType));

        var entity = customerType.ToEntity();
        await context.CustomerTypes.AddAsync(entity);
        await context.SaveChangesAsync();

        return entity;
    }

    public async Task<ICustomerType?> UpdateAsync(int id, ICustomerType customerType)
    {
        ArgumentNullException.ThrowIfNull(customerType, nameof(customerType));

        var existingCustomerType = await context.CustomerTypes.FindAsync(id);
        if (existingCustomerType == null) return null;

        var updatedEntity = customerType.ToEntity();
        updatedEntity.CustomerTypeId = id;

        context.Entry(existingCustomerType).CurrentValues.SetValues(updatedEntity);
        await context.SaveChangesAsync();

        return existingCustomerType;
    }

    public async Task<ICustomerType?> DeleteAsync(int id)
    {
        var customerType = await context.CustomerTypes.FindAsync(id);
        if (customerType == null) return null;

        context.CustomerTypes.Remove(customerType);
        await context.SaveChangesAsync();

        return customerType;
    }
}