using PublishingHouse.Abstractions.Model;

namespace PublishingHouse.DAL.Entity;

public partial class CustomerType : ICustomerType
{
    public int CustomerTypeId { get; set; }

    public string? Name { get; set; }

    public DateTime? CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
