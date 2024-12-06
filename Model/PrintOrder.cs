using PublishingHouse.Abstractions.Entity;

namespace PublishingHouse.DAL.Model
{
    public class PrintOrder : IPrintOrder
    {
        public int OrderId { get; set; }

        public int Number { get; set; }

        public string PrintType { get; set; } = null!;

        public string PaperType { get; set; } = null!;

        public string CoverType { get; set; } = null!;

        public string FasteningType { get; set; } = null!;

        public bool IsLaminated { get; set; }

        public double Price { get; set; }

        public int OrderStatusId { get; set; }

        public DateOnly? RegistrationDate { get; set; }

        public DateOnly? CompletionDate { get; set; }

        public int CustomerId { get; set; }

        public int EmployeeId { get; set; }

        public DateTime? CreateDateTime { get; set; }

        public DateTime? UpdateDateTime { get; set; }

        public virtual ICollection<BatchPrint> BatchPrints { get; set; } = (List<BatchPrint>) [];

        public virtual Customer Customer { get; set; } = null!;

        public virtual Employee Employee { get; set; } = null!;

        public virtual OrderStatus OrderStatus { get; set; } = null!;

        ICollection<IBatchPrint> IPrintOrder.BatchPrints
        {
            get => BatchPrints.Cast<IBatchPrint>().ToList();
            set => BatchPrints = value.Cast<BatchPrint>().ToList();
        }

        ICustomer IPrintOrder.Customer
        {
            get => Customer;
            set => Customer = (Customer)value;
        }

        IEmployee IPrintOrder.Employee
        {
            get => Employee;
            set => Employee = (Employee)value;
        }
        IOrderStatus IPrintOrder.OrderStatus
        {
            get => OrderStatus;
            set => OrderStatus = (OrderStatus)value;
        }
    }
}
