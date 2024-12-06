using PublishingHouse.Abstractions.Entity;

namespace PublishingHouse.DAL.Model
{
    public partial class ProductionType : IProductionType
    {
        public int ProductionTypeId { get; set; }

        public string? Name { get; set; }

        public DateTime? CreateDateTime { get; set; }

        public DateTime? UpdateDateTime { get; set; }

        public virtual ICollection<Production> Productions { get; set; } = new List<Production>();
    }
}
