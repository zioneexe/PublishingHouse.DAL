namespace PublishingHouse.Infrastructure.Models
{
    public partial class Order
    {
        public int Id { get; set; }

        public string Number { get; set; } = null!;

        public string? Description { get; set; }

        public string Status { get; set; } = null!;

        public decimal Price { get; set; }

        public int BookId { get; set; }

        public int EmployeeId { get; set; }

        public int CustomerId { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime? CompletionDate { get; set; }

        public virtual Book Book { get; set; } = null!;

        public virtual Customer Customer { get; set; } = null!;

        public virtual Employee Employee { get; set; } = null!;

        public virtual ICollection<Request> Requests { get; set; } = (List<Request>)[];
    }
}
