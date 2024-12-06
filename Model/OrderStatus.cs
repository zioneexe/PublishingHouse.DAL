using PublishingHouse.Abstractions.Entity;

namespace PublishingHouse.DAL.Model
{
    public partial class OrderStatus : IOrderStatus
    {
        public int OrderStatusId { get; set; }

        public string? Name { get; set; }

        public DateTime? CreateDateTime { get; set; }

        public DateTime? UpdateDateTime { get; set; }

        public virtual ICollection<PrintOrder> PrintOrders { get; set; } = new List<PrintOrder>();

        ICollection<IPrintOrder> IOrderStatus.PrintOrders
        {
            get => PrintOrders.Cast<IPrintOrder>().ToList();
            set => PrintOrders = value.Cast<PrintOrder>().ToList();
        }
    }
}
