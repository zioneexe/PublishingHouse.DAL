using Microsoft.EntityFrameworkCore;
using PublishingHouse.Abstractions.Entity;
using PublishingHouse.Abstractions.Exception;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.DAL.Data;
using PublishingHouse.DAL.Model;
using System.Linq.Expressions;

namespace PublishingHouse.DAL.Repository
{
    public class EmployeeRepository(PublishingHouseDbContext context) : IEmployeeRepository
    {
        public async Task AddAsync(IEmployee entity)
        {
            if (entity is Employee employeeEntity)
            {
                await context.Employees.AddAsync(employeeEntity);
            }
            else
            {
                throw new InvalidOperationException("The provided entity is not of type Employee.");
            }
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await context.Employees.FindAsync(id);
            if (employee is null)
            {
                throw new RepositoryException($"Employee with id {id} was not found.");
            }

            context.Employees.Remove(employee);
        }

        public async Task<IEnumerable<IEmployee>> GetAllAsync()
        {
            return await context.Employees
                .Include(e => e.Production)
                .Include(e => e.Position)
                .ToListAsync();
        }

        public async Task<IEmployee> GetByIdAsync(int id)
        {
            var employee = await context.Employees
                .Include(e => e.Production)
                .Include(e => e.Position)
                .FirstOrDefaultAsync(e => e.EmployeeId == id);

            if (employee is null)
            {
                throw new RepositoryException($"Employee with id {id} was not found.");
            }

            return employee;
        }

        public async Task UpdateAsync(int id, IEmployee entity)
        {
            var existingEmployee = await context.Employees.FindAsync(id);
            if (existingEmployee is null)
            {
                throw new RepositoryException($"Employee with id {id} was not found.");
            }

            if (entity is Employee employeeEntity)
            {
                existingEmployee.UserId = employeeEntity.UserId;
                existingEmployee.PositionId = employeeEntity.PositionId;
                existingEmployee.ProductionId = employeeEntity.ProductionId;
                existingEmployee.Name = employeeEntity.Name;
                existingEmployee.UpdateDateTime = employeeEntity.UpdateDateTime;
            }
            else
            {
                throw new InvalidOperationException("The provided entity is not of type Employee.");
            }
        }

        public async Task<IEnumerable<IEmployee>> GetByPositionIdAsync(int positionId)
        {
            return await context.Employees
                .Where(e => e.PositionId == positionId)
                .Include(e => e.Production)
                .Include(e => e.Position)
                .ToListAsync();
        }

        public async Task<IEnumerable<IEmployee>> GetByProductionIdAsync(int productionId)
        {
            return await context.Employees
                .Where(e => e.ProductionId == productionId)
                .Include(e => e.Production)
                .Include(e => e.Position)
                .ToListAsync();
        }

        public async Task<int> GetIdByUserIdAsync(string userId)
        {
            var employee = await context.Employees.FirstOrDefaultAsync(x => x.UserId == userId);

            if (employee is null)
            {
                throw new RepositoryException($"Employee with userId {userId} was not found");
            }

            return employee.EmployeeId;
        }
    }
}
