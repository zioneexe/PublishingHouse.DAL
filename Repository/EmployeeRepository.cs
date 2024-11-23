using Microsoft.EntityFrameworkCore;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.DAL.Mapper;

namespace PublishingHouse.DAL.Repository;

public class EmployeeRepository(PublishingHouseDbContext context) : IEmployeeRepository
{
    public async Task<List<IEmployee>> GetAllAsync()
    {
        var employees = await context.Employees
            .Include(e => e.Production)
            .Include(e => e.Position)
            .ToListAsync();

        return employees.Cast<IEmployee>().ToList();
    }

    public async Task<IEmployee?> GetByIdAsync(int id)
    {
        return await context.Employees
            .Include(e => e.Production)
            .Include(e => e.Position)
            .FirstOrDefaultAsync(a => a.EmployeeId == id);
    }

    public async Task<IEmployee> AddAsync(IEmployee employee)
    {
        ArgumentNullException.ThrowIfNull(employee, nameof(employee));

        var entity = employee.ToEntity();
        await context.Employees.AddAsync(entity);
        await context.SaveChangesAsync();

        return entity;
    }

    public async Task<IEmployee?> UpdateAsync(int id, IEmployee employee)
    {
        ArgumentNullException.ThrowIfNull(employee, nameof(employee));

        var existingEmployee = await context.Employees.FindAsync(id);
        if (existingEmployee == null) return null;

        var updatedEntity = employee.ToEntity();
        updatedEntity.EmployeeId = id;

        context.Entry(existingEmployee).CurrentValues.SetValues(updatedEntity);
        await context.SaveChangesAsync();

        return existingEmployee;
    }

    public async Task<IEmployee?> DeleteAsync(int id)
    {
        var employee = await context.Employees.FindAsync(id);
        if (employee == null) return null;

        context.Employees.Remove(employee);
        await context.SaveChangesAsync();

        return employee;
    }

    public Task<List<IEmployee>> GetByPositionIdAsync(int positionId)
    {
        throw new NotImplementedException();
    }

    public Task<List<IEmployee>> GetByProductionIdAsync(int productionId)
    {
        throw new NotImplementedException();
    }
}