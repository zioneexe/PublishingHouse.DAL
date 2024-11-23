using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;

namespace PublishingHouse.DAL.Mapper;

public static class CustomerEntityMapper
{
    public static Customer ToEntity(this ICustomer model)
    {
        return new Customer
        {
            CustomerId = model.CustomerId,
            CustomerTypeId = model.CustomerTypeId,
            Name = model.Name,
            AddressDate= model.AddressDate,
            Email = model.Email,
        };
    }
}