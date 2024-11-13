namespace PublishingHouse.Infrastructure.Models
{
    public partial class Request
    {
        public int Id { get; set; }

        public int SelectedOrderId { get; set; }

        public string WantedOrderStatus { get; set; } = null!;

        public string Status { get; set; } = null!;

        public bool IsConsidered { get; set; }

        public virtual Order SelectedOrder { get; set; } = null!;
    }
}
