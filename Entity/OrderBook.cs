using PublishingHouse.Abstractions.Model;

namespace PublishingHouse.DAL.Entity;

public partial class OrderBook : IOrderBook
{
    public int OrderBooksId { get; set; }

    public int OrderId { get; set; }

    public int BookId { get; set; }

    public int BookQuantity { get; set; }

    public DateTime? CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual PrintOrder Order { get; set; } = null!;
}
