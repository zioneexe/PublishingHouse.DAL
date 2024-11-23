using Microsoft.EntityFrameworkCore;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.DAL.Mapper;

namespace PublishingHouse.DAL.Repository;

public class BookRepository(PublishingHouseDbContext context) : IBookRepository
{
    public async Task<List<IBook>> GetAllAsync()
    {
        var books = await context.Books
            .Include(b => b.Author)
            .Include(b => b.Genre)
            .ToListAsync();

        return books.Cast<IBook>().ToList();
    }

    public async Task<IBook?> GetByIdAsync(int id)
    {
        return await context.Books
            .Include(b => b.Author)
            .Include(b => b.Genre)
            .FirstOrDefaultAsync(a => a.BookId == id);
    }

    public async Task<IBook> AddAsync(IBook book)
    {
        ArgumentNullException.ThrowIfNull(book, nameof(book));

        var entity = book.ToEntity();
        await context.Books.AddAsync(entity);
        await context.SaveChangesAsync();

        return entity;
    }

    public async Task<IBook?> UpdateAsync(int id, IBook book)
    {
        ArgumentNullException.ThrowIfNull(book, nameof(book));

        var existingBook = await context.Books.FindAsync(id);
        if (existingBook == null) return null;

        var updatedEntity = book.ToEntity();
        updatedEntity.BookId = id;

        context.Entry(existingBook).CurrentValues.SetValues(updatedEntity);
        await context.SaveChangesAsync();

        return existingBook;
    }

    public async Task<IBook?> DeleteAsync(int id)
    {
        var book = await context.Books.FindAsync(id);
        if (book == null) return null;

        context.Books.Remove(book);
        await context.SaveChangesAsync();

        return book;
    }

    public Task<List<IBook>> GetByGenreIdAsync(int genreId)
    {
        throw new NotImplementedException();
    }

    public Task<List<IBook>> GetByAuthorIdAsync(int authorId)
    {
        throw new NotImplementedException();
    }
}