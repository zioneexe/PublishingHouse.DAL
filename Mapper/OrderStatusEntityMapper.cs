using PublishingHouse.Abstractions.Model;
using PublishingHouse.DAL.Entity;

namespace PublishingHouse.DAL.Mapper;

public static class OrderStatusEntityMapper
{
    public static OrderStatus ToEntity(this IOrderStatus model)
    {
        return new OrderStatus
        {
            OrderStatusId = model.OrderStatusId,
            Name = model.Name,
        };
    }
}