using PublishingHouse.Abstractions.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PublishingHouse.DAL.Migrations;

namespace PublishingHouse.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IAdminRepository Admins { get; }
        IAuthorRepository Authors { get; }
        IBatchPrintRepository BatchPrints { get; }
        IBookRepository Books { get; }
        ICityRepository Cities { get; }
        ICustomerRepository Customers { get; }
        ICustomerTypeRepository CustomerTypes { get; }
        IEmployeeRepository Employees { get; }
        IGenreRepository Genres { get; }
        IOrderBookRepository OrderBooks { get; }
        IOrderStatusRepository OrderStatuses { get; }  
        IPositionRepository Positions { get; }
        IPrintOrderRepository PrintOrders { get; }
        IProductionRepository Productions { get; }
        IProductionTypeRepository ProductionTypes { get; }
        IQualityMarkRepository QualityMarks {get;}
        IRegionRepository Regions { get; }
        IRoleRepository Roles { get; }
        IUserRepository Users { get; }
        Task CompleteAsync();
    }
}
