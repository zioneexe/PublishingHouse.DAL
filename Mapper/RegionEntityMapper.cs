using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;

namespace PublishingHouse.DAL.Mapper;

public static class RegionEntityMapper
{
    public static Region ToEntity(this IRegion model)
    {
        return new Region
        {
            RegionId = model.RegionId,
            Name = model.Name,
        };
    }
}