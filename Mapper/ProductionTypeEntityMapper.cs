using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;

namespace PublishingHouse.DAL.Mapper;

public static class ProductionTypeEntityMapper
{
    public static ProductionType ToEntity(this IProductionType model)
    {
        return new ProductionType
        {
            ProductionTypeId = model.ProductionTypeId,
            Name = model.Name,
        };
    }
}