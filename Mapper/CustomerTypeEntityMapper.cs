using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;

namespace PublishingHouse.DAL.Mapper;

public static class CustomerTypeEntityMapper
{
    public static CustomerType ToEntity(this ICustomerType model)
    {
        return new CustomerType
        {
            CustomerTypeId = model.CustomerTypeId,
            Name = model.Name,
        };
    }
}