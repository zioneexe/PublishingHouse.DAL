using Microsoft.EntityFrameworkCore;
using PublishingHouse.Abstractions.Entity;
using PublishingHouse.Abstractions.Exception;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.DAL.Data;
using PublishingHouse.DAL.Model;
using System.Linq.Expressions;

namespace PublishingHouse.DAL.Repository
{
    public class CustomerRepository(PublishingHouseDbContext context) : ICustomerRepository
    {
        public async Task AddAsync(ICustomer entity)
        {
            if (entity is Customer customerEntity)
            {
                await context.Customers.AddAsync(customerEntity);
            }
            else
            {
                throw new InvalidOperationException("The provided entity is not of type Customer.");
            }
        }

        public async Task DeleteAsync(int id)
        {
            var customer = await context.Customers.FindAsync(id);
            if (customer is not null)
                context.Customers.Remove(customer);
            else
                throw new RepositoryException($"Customer with id {id} was not found.");
        }

        public async Task<IEnumerable<ICustomer>> GetAllAsync()
        {
            return await context.Customers.Include(c => c.CustomerType).ToListAsync();
        }

        public async Task<ICustomer> GetByIdAsync(int id)
        {
            var customer = await context.Customers.Include(c => c.CustomerType)
                .FirstOrDefaultAsync(c => c.CustomerId == id);
            if (customer is null)
            {
                throw new RepositoryException($"Customer with id {id} was not found.");
            }

            return customer;
        }

        public async Task UpdateAsync(int id, ICustomer entity)
        {
            var existingCustomer = await context.Customers.FindAsync(id);
            if (existingCustomer is null)
            {
                throw new RepositoryException($"Customer with id {id} was not found.");
            }

            if (entity is Customer customerEntity)
            {
                existingCustomer.CustomerTypeId = customerEntity.CustomerTypeId;
                existingCustomer.Name = customerEntity.Name;
                existingCustomer.AddressDate = customerEntity.AddressDate;
                existingCustomer.UserId = customerEntity.UserId;
                existingCustomer.Email = customerEntity.Email;
                existingCustomer.UpdateDateTime = customerEntity.UpdateDateTime;
            }
            else
            {
                throw new InvalidOperationException("The provided entity is not of type Customer.");
            }
        }

        public async Task<IEnumerable<ICustomer>> GetByCustomerTypeIdAsync(int customerTypeId)
        {
            return await context.Customers
                .Where(c => c.CustomerTypeId == customerTypeId)
                .Include(c => c.CustomerType)
                .ToListAsync();
        }

        public async Task<int> GetIdByUserIdAsync(string userId)
        {
            var customer = await context.Customers.FirstOrDefaultAsync(x => x.UserId == userId);

            if (customer is null)
            {
                throw new RepositoryException($"Customer with userId {userId} was not found");
            }

            return customer.CustomerId;
        }
    }
}
