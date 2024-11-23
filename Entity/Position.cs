using PublishingHouse.Abstractions.Model;

namespace PublishingHouse.DAL.Entity;

public partial class Position : IPosition
{
    public int PositionId { get; set; }

    public string? Name { get; set; }

    public DateTime? CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
