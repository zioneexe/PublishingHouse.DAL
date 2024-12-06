using PublishingHouse.Abstractions.Repository;

namespace PublishingHouse.DAL.Data
{
    public interface IUnitOfWork
    {
        IBatchPrintRepository BatchPrints { get; }
        IBookRepository Books { get; }
        ICityRepository Cities { get; }
        ICustomerRepository Customers { get; }
        ICustomerTypeRepository CustomerTypes { get; }
        IEmployeeRepository Employees { get; }
        IOrderBookRepository OrderBooks { get; }
        IOrderStatusRepository OrderStatuses { get; }  
        IPositionRepository Positions { get; }
        IPrintOrderRepository PrintOrders { get; }
        IProductionRepository Productions { get; }
        IProductionTypeRepository ProductionTypes { get; }
        IQualityMarkRepository QualityMarks {get;}
        IRegionRepository Regions { get; }
        IOrderRequestRepository OrderRequests { get; }

        Task CompleteAsync();
    }
}
