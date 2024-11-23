using Microsoft.EntityFrameworkCore;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.DAL.Mapper;

namespace PublishingHouse.DAL.Repository;

public class UserRepository(PublishingHouseDbContext context) : IUserRepository
{
    public async Task<List<IUser>> GetAllAsync()
    {
        var users = await context.Users.Include(a => a.Role).ToListAsync();

        return users.Cast<IUser>().ToList();
    }

    public async Task<IUser?> GetByIdAsync(int id)
    {
        return await context.Users.Include(a => a.Role)
            .FirstOrDefaultAsync(a => a.UserId == id);
    }

    public async Task<IUser> AddAsync(IUser user)
    {
        ArgumentNullException.ThrowIfNull(user, nameof(user));

        var entity = user.ToEntity();
        await context.Users.AddAsync(entity);
        await context.SaveChangesAsync();

        return entity;
    }

    public async Task<IUser?> UpdateAsync(int id, IUser user)
    {
        ArgumentNullException.ThrowIfNull(user, nameof(user));

        var existingUser = await context.Users.FindAsync(id);
        if (existingUser == null) return null;

        var updatedEntity = user.ToEntity();
        updatedEntity.UserId = id;

        context.Entry(existingUser).CurrentValues.SetValues(updatedEntity);
        await context.SaveChangesAsync();

        return existingUser;
    }

    public async Task<IUser?> DeleteAsync(int id)
    {
        var user = await context.Users.FindAsync(id);
        if (user == null) return null;

        context.Users.Remove(user);
        await context.SaveChangesAsync();

        return user;
    }

    public Task<IUser?> GetByUsernameAsync(string username)
    {
        throw new NotImplementedException();
    }
}