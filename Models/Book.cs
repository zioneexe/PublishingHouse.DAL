namespace PublishingHouse.Infrastructure.Models
{
    public partial class Book
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Author { get; set; }

        public long Isbn { get; set; }

        public int PublicationYear { get; set; }

        public int Pages { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = (List<Order>)[];
    }
}
