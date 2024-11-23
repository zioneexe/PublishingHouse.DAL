using PublishingHouse.Abstractions.Model;

namespace PublishingHouse.DAL.Entity;

public partial class Production : IProduction
{
    public int ProductionId { get; set; }

    public int ProductionTypeId { get; set; }

    public int CityId { get; set; }

    public string? Address { get; set; }

    public DateTime? CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public virtual City City { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ProductionType ProductionType { get; set; } = null!;
}
