using PublishingHouse.Abstractions.Entity;

namespace PublishingHouse.DAL.Model
{
    public partial class QualityMark : IQualityMark
    {
        public int QualityMarkId { get; set; }

        public string? Name { get; set; }

        public DateTime? CreateDateTime { get; set; }

        public DateTime? UpdateDateTime { get; set; }

        public virtual ICollection<BatchPrint> BatchPrints { get; set; } = new List<BatchPrint>();
    }
}
