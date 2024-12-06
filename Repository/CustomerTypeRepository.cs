using Microsoft.EntityFrameworkCore;
using PublishingHouse.Abstractions.Entity;
using PublishingHouse.Abstractions.Exception;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.DAL.Data;
using PublishingHouse.DAL.Model;

namespace PublishingHouse.DAL.Repository
{
    public class CustomerTypeRepository(PublishingHouseDbContext context) : ICustomerTypeRepository
    {
        public async Task AddAsync(ICustomerType entity)
        {
            if (entity is CustomerType customerTypeEntity)
            {
                await context.CustomerTypes.AddAsync(customerTypeEntity);
            }
            else
            {
                throw new InvalidOperationException("The provided entity is not of type CustomerType.");
            }
        }

        public async Task DeleteAsync(int id)
        {
            var customerType = await context.CustomerTypes.FindAsync(id);
            if (customerType is null)
            {
                throw new RepositoryException($"CustomerType with id {id} was not found.");
            }

            context.CustomerTypes.Remove(customerType);
        }

        public async Task<IEnumerable<ICustomerType>> GetAllAsync()
        {
            return await context.CustomerTypes.ToListAsync();
        }

        public async Task<ICustomerType> GetByIdAsync(int id)
        {
            var customerType = await context.CustomerTypes.FindAsync(id);
            if (customerType is null)
            {
                throw new RepositoryException($"CustomerType with id {id} was not found.");
            }

            return customerType;
        }

        public async Task UpdateAsync(int id, ICustomerType entity)
        {
            var existingCustomerType = await context.CustomerTypes.FindAsync(id);
            if (existingCustomerType is null)
            {
                throw new RepositoryException($"CustomerType with id {id} was not found.");
            }

            if (entity is CustomerType customerTypeEntity)
            {
                existingCustomerType.Name = customerTypeEntity.Name;
                existingCustomerType.UpdateDateTime = customerTypeEntity.UpdateDateTime;
            }
            else
            {
                throw new InvalidOperationException("The provided entity is not of type CustomerType.");
            }
        }
    }
}
