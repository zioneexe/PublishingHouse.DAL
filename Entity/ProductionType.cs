using PublishingHouse.Abstractions.Model;

namespace PublishingHouse.DAL.Entity;

public partial class ProductionType : IProductionType
{
    public int ProductionTypeId { get; set; }

    public string? Name { get; set; }

    public DateTime? CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public virtual ICollection<Production> Productions { get; set; } = new List<Production>();
}
