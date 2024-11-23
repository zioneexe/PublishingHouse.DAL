using Microsoft.EntityFrameworkCore;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.DAL.Mapper;

namespace PublishingHouse.DAL.Repository;

public class GenreRepository(PublishingHouseDbContext context) : IGenreRepository
{
    public async Task<List<IGenre>> GetAllAsync()
    {
        var genres = await context.Genres.ToListAsync();

        return genres.Cast<IGenre>().ToList();
    }

    public async Task<IGenre?> GetByIdAsync(int id)
    {
        return await context.Genres
            .FirstOrDefaultAsync(a => a.GenreId == id);
    }

    public async Task<IGenre> AddAsync(IGenre genre)
    {
        ArgumentNullException.ThrowIfNull(genre, nameof(genre));

        var entity = genre.ToEntity();
        await context.Genres.AddAsync(entity);
        await context.SaveChangesAsync();

        return entity;
    }

    public async Task<IGenre?> UpdateAsync(int id, IGenre genre)
    {
        ArgumentNullException.ThrowIfNull(genre, nameof(genre));

        var existingGenre = await context.Genres.FindAsync(id);
        if (existingGenre == null) return null;

        var updatedEntity = genre.ToEntity();
        updatedEntity.GenreId = id;

        context.Entry(existingGenre).CurrentValues.SetValues(updatedEntity);
        await context.SaveChangesAsync();

        return existingGenre;
    }

    public async Task<IGenre?> DeleteAsync(int id)
    {
        var genre = await context.Genres.FindAsync(id);
        if (genre == null) return null;

        context.Genres.Remove(genre);
        await context.SaveChangesAsync();

        return genre;
    }
}