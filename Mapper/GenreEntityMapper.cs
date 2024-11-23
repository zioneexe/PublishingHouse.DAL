using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;

namespace PublishingHouse.DAL.Mapper;

public static class GenreEntityMapper
{
    public static Genre ToEntity(this IGenre model)
    {
        return new Genre
        {
            GenreId = model.GenreId,
            Name = model.Name,
        };
    }
}