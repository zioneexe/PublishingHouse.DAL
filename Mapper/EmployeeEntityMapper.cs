using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;

namespace PublishingHouse.DAL.Mapper;

public static class EmployeeEntityMapper
{
    public static Employee ToEntity(this IEmployee model)
    {
        return new Employee
        {
            EmployeeId = model.EmployeeId,
            UserId = model.UserId,
            PositionId = model.PositionId,
            ProductionId = model.ProductionId,
        };
    }
}