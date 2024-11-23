using Microsoft.EntityFrameworkCore;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.DAL.Mapper;

namespace PublishingHouse.DAL.Repository;

public class AuthorRepository(PublishingHouseDbContext context) : IAuthorRepository
{
    public async Task<List<IAuthor>> GetAllAsync()
    {
        var authors = await context.Authors.ToListAsync();

        return authors.Cast<IAuthor>().ToList();
    }

    public async Task<IAuthor?> GetByIdAsync(int id)
    {
        return await context.Authors
            .FirstOrDefaultAsync(a => a.AuthorId == id);
    }

    public async Task<IAuthor> AddAsync(IAuthor author)
    {
        ArgumentNullException.ThrowIfNull(author, nameof(author));

        var entity = author.ToEntity();
        await context.Authors.AddAsync(entity);
        await context.SaveChangesAsync();

        return entity;
    }

    public async Task<IAuthor?> UpdateAsync(int id, IAuthor author)
    {
        ArgumentNullException.ThrowIfNull(author, nameof(author));

        var existingAuthor = await context.Authors.FindAsync(id);
        if (existingAuthor == null) return null;

        var updatedEntity = author.ToEntity();
        updatedEntity.AuthorId = id;

        context.Entry(existingAuthor).CurrentValues.SetValues(updatedEntity);
        await context.SaveChangesAsync();

        return existingAuthor;
    }

    public async Task<IAuthor?> DeleteAsync(int id)
    {
        var author = await context.Authors.FindAsync(id);
        if (author == null) return null;

        context.Authors.Remove(author);
        await context.SaveChangesAsync();

        return author;
    }

    public Task<IAuthor?> GetAuthorWithBooksAsync(int id)
    {
        throw new NotImplementedException();
    }
}