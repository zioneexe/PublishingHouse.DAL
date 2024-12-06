using System.ComponentModel.DataAnnotations;
using PublishingHouse.Abstractions.Entity;

namespace PublishingHouse.DAL.Model
{
    public partial class Customer : ICustomer
    {
        public int CustomerId { get; set; }

        public int CustomerTypeId { get; set; }

        public string Name { get; set; } = null!;

        public DateOnly? AddressDate { get; set; }

        public string? Email { get; set; }

        public string? UserId { get; set; }

        public DateTime? CreateDateTime { get; set; }

        public DateTime? UpdateDateTime { get; set; }

        public virtual CustomerType CustomerType { get; set; } = null!;

        public virtual ICollection<PrintOrder> PrintOrders { get; set; } = (List<PrintOrder>) [];

        public virtual ICollection<OrderRequest> OrderRequests { get; set; } = (List<OrderRequest>)[];

        ICustomerType ICustomer.CustomerType
        {
            get => CustomerType;
            set => CustomerType = (CustomerType)value!;
        }

        ICollection<IPrintOrder> ICustomer.PrintOrders
        {
            get => PrintOrders.Cast<IPrintOrder>().ToList();
            set => PrintOrders = value.Cast<PrintOrder>().ToList();
        }

        ICollection<IOrderRequest> ICustomer.OrderRequests
        {
            get => OrderRequests.Cast<IOrderRequest>().ToList();
            set => OrderRequests = value.Cast<OrderRequest>().ToList();
        }
    }
}
