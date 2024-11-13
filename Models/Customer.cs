namespace PublishingHouse.Infrastructure.Models
{
    public partial class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public DateTime AddressDate { get; set; }

        public string? Email { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = (List<Order>)[];
    }
}
