using PublishingHouse.Abstractions.Model;

namespace PublishingHouse.DAL.Entity;

public partial class PrintOrder : IPrintOrder
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

    public virtual ICollection<BatchPrint> BatchPrints { get; set; } = new List<BatchPrint>();

    public virtual Customer Customer { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<OrderBook> OrderBooks { get; set; } = new List<OrderBook>();

    public virtual OrderStatus OrderStatus { get; set; } = null!;
}
