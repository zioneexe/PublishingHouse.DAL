using PublishingHouse.Abstractions.Model;

namespace PublishingHouse.DAL.Entity;

public partial class Customer : ICustomer
{
    public int CustomerId { get; set; }

    public int CustomerTypeId { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly? AddressDate { get; set; }

    public string? Email { get; set; }

    public DateTime? CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public virtual CustomerType CustomerType { get; set; } = null!;

    public virtual ICollection<PrintOrder> PrintOrders { get; set; } = new List<PrintOrder>();
}
