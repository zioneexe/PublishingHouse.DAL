using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.DAL.Mapper;

namespace PublishingHouse.DAL.Repository
{
    public class RoleRepository(PublishingHouseDbContext context) : IRoleRepository
    {
        public async Task<List<IRole>> GetAllAsync()
        {
            var roles = await context.Roles.ToListAsync();

            return roles.Cast<IRole>().ToList();
        }

        public async Task<IRole?> GetByIdAsync(int id)
        {
            return await context.Roles
                .FirstOrDefaultAsync(a => a.RoleId == id);
        }

        public async Task<IRole> AddAsync(IRole role)
        {
            ArgumentNullException.ThrowIfNull(role, nameof(role));

            var entity = role.ToEntity();
            await context.Roles.AddAsync(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<IRole?> UpdateAsync(int id, IRole role)
        {
            ArgumentNullException.ThrowIfNull(role, nameof(role));

            var existingRole = await context.Roles.FindAsync(id);
            if (existingRole == null) return null;

            var updatedEntity = role.ToEntity();
            updatedEntity.RoleId = id;

            context.Entry(existingRole).CurrentValues.SetValues(updatedEntity);
            await context.SaveChangesAsync();

            return existingRole;
        }

        public async Task<IRole?> DeleteAsync(int id)
        {
            var role = await context.Roles.FindAsync(id);
            if (role == null) return null;

            context.Roles.Remove(role);
            await context.SaveChangesAsync();

            return role;
        }
    }
}
