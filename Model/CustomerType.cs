using PublishingHouse.Abstractions.Entity;

namespace PublishingHouse.DAL.Model
{
    public partial class CustomerType : ICustomerType
    {
        public int CustomerTypeId { get; set; }

        public string? Name { get; set; }

        public DateTime? CreateDateTime { get; set; }

        public DateTime? UpdateDateTime { get; set; }

        public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

        ICollection<ICustomer> ICustomerType.Customers
        {
            get => Customers.Cast<ICustomer>().ToList();
            set => Customers = value.Cast<Customer>().ToList();
        }
    }
}
