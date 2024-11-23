using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;

namespace PublishingHouse.DAL.Mapper;

public static class AuthorEntityMapper
{
    public static Author ToEntity(this IAuthor model)
    {
        return new Author
        {
            AuthorId = model.AuthorId,
            Name = model.Name,
        };
    }
}