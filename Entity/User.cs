using PublishingHouse.Abstractions.Model;

namespace PublishingHouse.DAL.Entity;

public partial class User : IUser
{
    public int UserId { get; set; }

    public int RoleId { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public DateTime? CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public virtual Admin? Admin { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Role Role { get; set; } = null!;
}
