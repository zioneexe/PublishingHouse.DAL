namespace PublishingHouse.Infrastructure.Models
{
    public partial class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Position { get; set; } = null!;

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = (List<Order>)[];
    }
}
