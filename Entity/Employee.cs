using PublishingHouse.Abstractions.Model;

namespace PublishingHouse.DAL.Entity;

public partial class Employee : IEmployee
{
    public int EmployeeId { get; set; }

    public int UserId { get; set; }

    public int PositionId { get; set; }

    public int ProductionId { get; set; }

    public DateTime? CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public virtual Position Position { get; set; } = null!;

    public virtual ICollection<PrintOrder> PrintOrders { get; set; } = new List<PrintOrder>();

    public virtual Production Production { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
