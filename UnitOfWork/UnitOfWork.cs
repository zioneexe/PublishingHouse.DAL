﻿using Microsoft.EntityFrameworkCore;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.DAL.Repository;

namespace PublishingHouse.DAL.UnitOfWork
{
    public class UnitOfWork(PublishingHouseDbContext context): IUnitOfWork, IDisposable
    {
        public IAdminRepository Admins { get; } = new AdminRepository(context);
        public IAuthorRepository Authors { get; } = new AuthorRepository(context);
        public IBatchPrintRepository BatchPrints { get; } = new BatchPrintRepository(context);
        public IBookRepository Books { get; } = new BookRepository(context);
        public ICityRepository Cities { get; } = new CityRepository(context);
        public ICustomerRepository Customers { get; } = new CustomerRepository(context);
        public ICustomerTypeRepository CustomerTypes { get; } = new CustomerTypeRepository(context);
        public IEmployeeRepository Employees { get; } = new EmployeeRepository(context);
        public IGenreRepository Genres { get; } = new GenreRepository(context);
        public IOrderBookRepository OrderBooks { get; } = new OrderBookRepository(context);
        public IOrderStatusRepository OrderStatuses { get; } = new OrderStatusRepository(context);
        public IPositionRepository Positions { get; } = new PositionRepository(context);
        public IPrintOrderRepository PrintOrders { get; } = new PrintOrderRepository(context);
        public IProductionRepository Productions { get; } = new ProductionRepository(context);
        public IProductionTypeRepository ProductionTypes { get; } = new ProductionTypeRepository(context);
        public IQualityMarkRepository QualityMarks { get; } = new QualityMarkRepository(context);
        public IRegionRepository Regions { get; } = new RegionRepository(context);
        public IRoleRepository Roles { get; } = new RoleRepository(context);
        public IUserRepository Users { get; } = new UserRepository(context);

        public async Task CompleteAsync()
        {
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new Exception($"Error while saving changes: {e.InnerException?.Message}");
            }
        }

        void IDisposable.Dispose() => context.Dispose();
    }
}