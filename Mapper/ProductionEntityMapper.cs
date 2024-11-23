using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;

namespace PublishingHouse.DAL.Mapper;

public static class ProductionEntityMapper
{
    public static Production ToEntity(this IProduction model)
    {
        return new Production
        {
            ProductionId = model.ProductionId,
            ProductionTypeId = model.ProductionTypeId,
            CityId = model.CityId,
            Address = model.Address,
        };
    }
}