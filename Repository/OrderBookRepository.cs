using Microsoft.EntityFrameworkCore;
using PublishingHouse.Abstractions.Entity;
using PublishingHouse.Abstractions.Exception;
using PublishingHouse.Abstractions.Repository;
using PublishingHouse.DAL.Data;
using PublishingHouse.DAL.Model;

namespace PublishingHouse.DAL.Repository
{
    public class OrderBookRepository(PublishingHouseDbContext context) : IOrderBookRepository
    {
        public async Task AddAsync(IOrderBook entity)
        {
            if (entity is OrderBook orderBookEntity)
            {
                await context.OrderBooks.AddAsync(orderBookEntity);
            }
            else
            {
                throw new InvalidOperationException("The provided entity is not of type OrderBook.");
            }
        }

        public async Task DeleteAsync(int id)
        {
            var orderBook = await context.OrderBooks.FindAsync(id);
            if (orderBook is null)
            {
                throw new RepositoryException($"OrderBook with id {id} was not found.");
            }

            context.OrderBooks.Remove(orderBook);
        }

        public async Task DeleteByOrderIdAsync(int orderId)
        {
            var orderBooks = context.OrderBooks.Where(ob => ob.OrderId == orderId).ToList();

            if (orderBooks.Count == 0)
            {
                return;
            }

            context.OrderBooks.RemoveRange(orderBooks);

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<IOrderBook>> GetByOrderIdAsync(int orderId)
        {
            return await context.OrderBooks
                .Where(ob => ob.OrderId == orderId)
                .Include(ob => ob.Order)
                .Include(ob => ob.Book)
                .ToListAsync();
        }

        public async Task<IEnumerable<IOrderBook>> GetAllAsync()
        {
            return await context.OrderBooks
                .Include(ob => ob.Order)
                .Include(ob => ob.Book)
                .ToListAsync();
        }

        public async Task<IOrderBook> GetByIdAsync(int id)
        {
            var orderBook = await context.OrderBooks
                .Include(ob => ob.Order)
                .Include(ob => ob.Book)
                .FirstOrDefaultAsync(ob => ob.OrderBooksId == id);

            if (orderBook is null)
            {
                throw new RepositoryException($"OrderBook with id {id} was not found.");
            }

            return orderBook;
        }

        public async Task UpdateAsync(int id, IOrderBook entity)
        {
            var existingOrderBook = await context.OrderBooks.FindAsync(id);
            if (existingOrderBook is null)
            {
                throw new RepositoryException($"OrderBook with id {id} was not found.");
            }

            if (entity is OrderBook orderBookEntity)
            {
                existingOrderBook.OrderId = orderBookEntity.OrderId;
                existingOrderBook.BookId = orderBookEntity.BookId;
                existingOrderBook.BookQuantity = orderBookEntity.BookQuantity;
                existingOrderBook.UpdateDateTime = orderBookEntity.UpdateDateTime;
            }
            else
            {
                throw new InvalidOperationException("The provided entity is not of type OrderBook.");
            }
        }

        public async Task<IEnumerable<IOrderBook>> GetOrderBooksByOrderIdAsync(int orderId)
        {
            return await context.OrderBooks
                .Where(ob => ob.OrderId == orderId)
                .Include(ob => ob.Order)
                .Include(ob => ob.Book)
                .ToListAsync();
        }
    }
}
