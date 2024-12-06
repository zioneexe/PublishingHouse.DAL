using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PublishingHouse.DAL.Data.Seed;

namespace PublishingHouse.DAL.Data
{
    public class AuthDbContext(DbContextOptions<AuthDbContext> options) : IdentityDbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Creating roles:
            var adminRoleId = Guid.NewGuid().ToString();
            const string adminRoleName = "Admin";

            var employeeRoleId = Guid.NewGuid().ToString();
            const string employeeRoleName = "Employee";

            var customerRoleId = Guid.NewGuid().ToString();
            const string customerRoleName = "Customer";

            var roles = new List<IdentityRole>
            {
                new ()
                {
                    Id = adminRoleId,
                    Name = adminRoleName,
                    NormalizedName = adminRoleName.ToUpper(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                },
                new ()
                {
                    Id = employeeRoleId,
                    Name = employeeRoleName,
                    NormalizedName = employeeRoleName.ToUpper(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                },
                new ()
                {
                    Id = customerRoleId,
                    Name = customerRoleName,
                    NormalizedName = customerRoleName.ToUpper(),
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);

            // Admin:
            var adminUserId = Guid.NewGuid().ToString();
            const string adminUserName = "tartar";
            const string adminEmail = "tartar@gmail.com";
            const string adminPassword = "TartarSauce";

            var admin = new IdentityUser
            {
                Id = adminUserId,
                UserName = adminUserName,
                Email = adminEmail,
                NormalizedUserName = adminUserName.ToUpper(),
                NormalizedEmail = adminEmail.ToUpper(),
            };

            admin.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(admin, adminPassword);
            builder.Entity<IdentityUser>().HasData(admin);

            var adminRole = new IdentityUserRole<string>
            {
                UserId = adminUserId,
                RoleId = adminRoleId,
            };

            builder.Entity<IdentityUserRole<string>>().HasData(adminRole);
        }
    }
}
