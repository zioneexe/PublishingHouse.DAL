using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PublishingHouse.DAL.Data;
using PublishingHouse.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublishingHouse.DAL.Data.Seed
{
    public static class DatabaseSeeder
    {
        public static async Task SeedDataAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();

            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var authContext = scope.ServiceProvider.GetRequiredService<AuthDbContext>();
            var publishingContext = scope.ServiceProvider.GetRequiredService<PublishingHouseDbContext>();

            await WaitForDatabaseReady(authContext);
            await WaitForDatabaseReady(publishingContext);

            await SeedRoles(authContext);
            await SeedUsersAndEmployees(userManager, publishingContext);
        }

        private static async Task WaitForDatabaseReady(DbContext context, int maxRetries = 10, int delayMs = 5000)
        {
            for (int retry = 0; retry < maxRetries; retry++)
            {
                try
                {
                    if (await context.Database.CanConnectAsync())
                    {
                        return; 
                    }
                }
                catch
                {
                }
                await Task.Delay(delayMs);
            }
            throw new Exception("Database is not ready after multiple retries.");
        }


        private static async Task SeedRoles(AuthDbContext context)
        {
            if (!context.Roles.Any())
            {
                context.Roles.AddRange(
                    new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Admin", NormalizedName = "ADMIN" },
                    new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Employee", NormalizedName = "EMPLOYEE" },
                    new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Customer", NormalizedName = "CUSTOMER" }
                );
                await context.SaveChangesAsync();
            }
        }

        private static async Task SeedUsersAndEmployees(UserManager<IdentityUser> userManager, PublishingHouseDbContext publishingContext)
        {
            var employeeSeeds = EmployeeSeedData.GetEmployeeSeeds();
            var userIdMappings = new Dictionary<string, string>();

            foreach (var seed in employeeSeeds)
            {
                var existingUser = await userManager.FindByNameAsync(seed.UserName ?? "");
                if (existingUser == null)
                {
                    var identityUser = new IdentityUser
                    {
                        UserName = seed.UserName,
                        Email = seed.Email,
                        NormalizedUserName = seed.UserName?.ToUpper(),
                        NormalizedEmail = seed.Email?.ToUpper(),
                        SecurityStamp = Guid.NewGuid().ToString()
                    };

                    var result = await userManager.CreateAsync(identityUser, seed.Password!);
                    if (!result.Succeeded)
                        throw new Exception($"Failed to create user {seed.UserName}: {string.Join(", ", result.Errors.Select(e => e.Description))}");

                    await userManager.AddToRoleAsync(identityUser, "Employee");

                    userIdMappings[seed.Email!] = identityUser.Id;
                }
                else
                {
                    userIdMappings[seed.Email!] = existingUser.Id;
                }
            }

            EmployeeSeedData.UpdateEmployeeSeedUserIds(userIdMappings);

            await using var transaction = await publishingContext.Database.BeginTransactionAsync();

            try
            {
                // Enable IDENTITY_INSERT
                await publishingContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [Employee] ON");

                foreach (var seed in employeeSeeds.Where(seed => !publishingContext.Employees.Any(e => e.EmployeeId == seed.EmployeeId)))
                {
                    publishingContext.Employees.Add(new Employee
                    {
                        EmployeeId = seed.EmployeeId,
                        UserId = seed.UserId,
                        Name = seed.Name,
                        PositionId = seed.PositionId,
                        ProductionId = seed.ProductionId,
                        CreateDateTime = DateTime.UtcNow,
                        UpdateDateTime = DateTime.UtcNow
                    });
                }

                await publishingContext.SaveChangesAsync();

                // Disable IDENTITY_INSERT
                await publishingContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT [Employee] OFF");

                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception("Error seeding employees with IDENTITY_INSERT", ex);
            }
        }
    }
}
