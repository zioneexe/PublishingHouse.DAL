using Microsoft.EntityFrameworkCore;
using PublishingHouse.Abstractions.Entity;
using PublishingHouse.Abstractions.Exception;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.DAL.Data;
using PublishingHouse.DAL.Model;

namespace PublishingHouse.DAL.Repository
{
    public class BookRepository(PublishingHouseDbContext context) : IBookRepository
    {
        public async Task AddAsync(IBook entity)
        {
            if (entity is Book bookEntity)
            {
                await context.Books.AddAsync(bookEntity);
            }
            else
            {
                throw new InvalidOperationException("The provided entity is not of type Book.");
            }
        }

        public async Task DeleteAsync(int id)
        {
            var book = await context.Books.FindAsync(id);
            if (book is not null)
                context.Books.Remove(book);
            else
                throw new RepositoryException($"Book with id {id} was not found.");
        }

        public async Task<int> AddWithIdAsync(IBook entity)
        {
            if (entity is Book bookEntity)
            {
                await context.Books.AddAsync(bookEntity);
                await context.SaveChangesAsync();

                return bookEntity.BookId;
            }
            else
            {
                throw new InvalidOperationException("The provided entity is not of type Book.");
            }
        }

        public async Task<IEnumerable<IBook>> GetAllAsync()
        {
            return await context.Books
                .ToListAsync();
        }

        public async Task<IBook> GetByIdAsync(int id)
        {
            var book = await context.Books
                .FirstOrDefaultAsync(b => b.BookId == id);

            return book ?? throw new RepositoryException($"Book with id {id} was not found.");
        }

        public async Task UpdateAsync(int id, IBook entity)
        {
            var existingBook = await context.Books.FindAsync(id);
            if (existingBook is not null)
            {
                if (entity is Book bookEntity)
                {
                    existingBook.Name = bookEntity.Name;
                    existingBook.Sku = bookEntity.Sku;
                    existingBook.Isbn = bookEntity.Isbn;
                    existingBook.Pages = bookEntity.Pages;
                    existingBook.PublicationYear = bookEntity.PublicationYear;
                    existingBook.Author = bookEntity.Author;
                    existingBook.Genre = bookEntity.Genre;
                    existingBook.Size = bookEntity.Size;
                    existingBook.Weight = bookEntity.Weight;
                    existingBook.Annotation = bookEntity.Annotation;
                    existingBook.CoverImagePath = bookEntity.CoverImagePath;
                    existingBook.UpdateDateTime = bookEntity.UpdateDateTime;
                }
                else
                {
                    throw new InvalidOperationException("The provided entity is not of type Book.");
                }
            }
            else
            {
                throw new RepositoryException($"Book with id {id} was not found.");
            }
        }
    }
}
