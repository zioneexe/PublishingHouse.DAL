using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;

namespace PublishingHouse.DAL.Mapper;

public static class PositionEntityMapper
{
    public static Position ToEntity(this IPosition model)
    {
        return new Position
        {
            PositionId = model.PositionId,
            Name = model.Name,
        };
    }
}