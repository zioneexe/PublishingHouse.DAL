using PublishingHouse.Abstractions.Model;

namespace PublishingHouse.DAL.Entity;

public partial class Role : IRole
{
    public int RoleId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = (List<User>)[];
}
