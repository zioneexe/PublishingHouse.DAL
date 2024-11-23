using PublishingHouse.Abstractions.Model;

namespace PublishingHouse.DAL.Entity;

public partial class City : ICity
{
    public int CityId { get; set; }

    public int RegionId { get; set; }

    public string? Name { get; set; }

    public DateTime? CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public virtual ICollection<Production> Productions { get; set; } = (List<Production>) [];

    public virtual Region Region { get; set; } = null!;
}
