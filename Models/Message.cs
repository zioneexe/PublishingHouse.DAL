namespace PublishingHouse.Infrastructure.Models
{
    public partial class Message
    {
        public int Id { get; set; }

        public string? Heading { get; set; }

        public string? Description { get; set; }

        public bool IsRead { get; set; }
    }
}
