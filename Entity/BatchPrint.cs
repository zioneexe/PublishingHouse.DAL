using PublishingHouse.Abstractions.Model;

namespace PublishingHouse.DAL.Entity;

public partial class BatchPrint : IBatchPrint
{
    public int BatchPrintId { get; set; }

    public string Number { get; set; } = null!;

    public int BookQuantity { get; set; }

    public int OrderId { get; set; }

    public DateOnly? PrintDate { get; set; }

    public int QualityMarkId { get; set; }

    public DateTime? CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public virtual PrintOrder Order { get; set; } = null!;

    public virtual QualityMark QualityMark { get; set; } = null!;
}
