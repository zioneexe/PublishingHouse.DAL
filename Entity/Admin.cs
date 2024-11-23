using PublishingHouse.Abstractions.Model;

namespace PublishingHouse.DAL.Entity;

public partial class Admin : IAdmin
{
    public int AdminId { get; set; }

    public int UserId { get; set; }

    public string? Department { get; set; }

    public DateTime? CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }
    
    public virtual User User { get; set; } = null!;
}