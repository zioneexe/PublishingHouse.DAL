using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;

namespace PublishingHouse.DAL.Mapper;

public static class CityEntityMapper
{
    public static City ToEntity(this ICity model)
    {
        return new City
        {
            CityId = model.CityId,
            RegionId  = model.RegionId,
            Name = model.Name
        };
    }
}