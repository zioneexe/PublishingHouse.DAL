using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;

namespace PublishingHouse.DAL.Mapper;

public static class OrderBookEntityMapper
{
    public static OrderBook ToEntity(this IOrderBook model)
    {
        return new OrderBook
        {
            OrderBooksId = model.OrderBooksId,
            OrderId = model.OrderId,
            BookId = model.BookId,
            BookQuantity = model.BookQuantity,
        };
    }
}