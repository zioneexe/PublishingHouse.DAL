using PublishingHouse.Abstractions.Model;

namespace PublishingHouse.DAL.Entity;

public partial class OrderStatus : IOrderStatus
{
    public int OrderStatusId { get; set; }

    public string? Name { get; set; }

    public DateTime? CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public virtual ICollection<PrintOrder> PrintOrders { get; set; } = new List<PrintOrder>();
}
