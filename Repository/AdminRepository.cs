using Microsoft.EntityFrameworkCore;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.DAL.Mapper;

namespace PublishingHouse.DAL.Repository;

public class AdminRepository(PublishingHouseDbContext context) : IAdminRepository
{

    public async Task<List<IAdmin>> GetAllAsync()
    {
        var admins = await context.Admins.Include(a => a.User).ToListAsync();
        
        return admins.Cast<IAdmin>().ToList();
    }

    public async Task<IAdmin?> GetByIdAsync(int id)
    {
        return await context.Admins.Include(a => a.User)
            .FirstOrDefaultAsync(a => a.AdminId == id);
    }

    public async Task<IAdmin> AddAsync(IAdmin admin)
    {
        ArgumentNullException.ThrowIfNull(admin, nameof(admin));

        var entity = admin.ToEntity();
        await context.Admins.AddAsync(entity);
        await context.SaveChangesAsync();

        return entity;
    }

    public async Task<IAdmin?> UpdateAsync(int id, IAdmin admin)
    {
        ArgumentNullException.ThrowIfNull(admin, nameof(admin));

        var existingAdmin = await context.Admins.FindAsync(id);
        if (existingAdmin == null) return null;

        var updatedEntity = admin.ToEntity();
        updatedEntity.AdminId = id;

        context.Entry(existingAdmin).CurrentValues.SetValues(updatedEntity);
        await context.SaveChangesAsync();

        return existingAdmin;
    }

    public async Task<IAdmin?> DeleteAsync(int id)
    {
        var admin = await context.Admins.FindAsync(id);
        if (admin == null) return null;

        context.Admins.Remove(admin);
        await context.SaveChangesAsync();

        return admin;
    }
}