using Microsoft.EntityFrameworkCore;
using PublishingHouse.Abstractions.Model;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.DAL.Mapper;

namespace PublishingHouse.DAL.Repository;

public class OrderBookRepository(PublishingHouseDbContext context) : IOrderBookRepository
{
    public async Task<List<IOrderBook>> GetAllAsync()
    {
        var orderBooks = await context.OrderBooks
            .Include(ob => ob.Order)
            .Include(ob => ob.Book)
            .ToListAsync();
        return orderBooks.Cast<IOrderBook>().ToList();
    }

    public async Task<IOrderBook?> GetByIdAsync(int id)
    {
        return await context.OrderBooks
            .Include(ob => ob.Order)
            .Include(ob => ob.Book)
            .FirstOrDefaultAsync(a => a.OrderBooksId == id);
    }

    public async Task<IOrderBook> AddAsync(IOrderBook orderBook)
    {
        ArgumentNullException.ThrowIfNull(orderBook, nameof(orderBook));

        var entity = orderBook.ToEntity();
        await context.OrderBooks.AddAsync(entity);
        await context.SaveChangesAsync();

        return entity;
    }

    public async Task<IOrderBook?> UpdateAsync(int id, IOrderBook orderBook)
    {
        ArgumentNullException.ThrowIfNull(orderBook, nameof(orderBook));

        var existingOrderBook = await context.OrderBooks.FindAsync(id);
        if (existingOrderBook == null) return null;

        var updatedEntity = orderBook.ToEntity();
        updatedEntity.OrderBooksId = id;

        context.Entry(existingOrderBook).CurrentValues.SetValues(updatedEntity);
        await context.SaveChangesAsync();

        return existingOrderBook;
    }

    public async Task<IOrderBook?> DeleteAsync(int id)
    {
        var orderBook = await context.OrderBooks.FindAsync(id);
        if (orderBook == null) return null;

        context.OrderBooks.Remove(orderBook);
        await context.SaveChangesAsync();

        return orderBook;
    }

    public Task<List<IOrderBook>> GetOrderBooksByOrderIdAsync(int orderId)
    {
        throw new NotImplementedException();
    }

    public Task<List<IOrderBook>> GetOrderBooksByBookIdAsync(int bookId)
    {
        throw new NotImplementedException();
    }
}