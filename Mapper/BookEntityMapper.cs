using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;

namespace PublishingHouse.DAL.Mapper;

public static class BookEntityMapper
{
    public static Book ToEntity(this IBook model)
    {
        return new Book
        {
            BookId = model.BookId,
            Name = model.Name,
            AuthorId = model.AuthorId,
            GenreId = model.GenreId,
            Sku = model.Sku,
            Isbn = model.Isbn,
            Pages = model.Pages,
            PublicationYear = model.PublicationYear,
            Size = model.Size,
            Weight = model.Weight,
            Annotation = model.Annotation
        };
    }
}