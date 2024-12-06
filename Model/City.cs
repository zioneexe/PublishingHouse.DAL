using PublishingHouse.Abstractions.Entity;

namespace PublishingHouse.DAL.Model
{
    public partial class City : ICity
    {
        public int CityId { get; set; }

        public int RegionId { get; set; }

        public string? Name { get; set; }

        public DateTime? CreateDateTime { get; set; }

        public DateTime? UpdateDateTime { get; set; }

        public virtual ICollection<Production> Productions { get; set; } = (List<Production>) [];

        public virtual Region Region { get; set; } = null!;

        ICollection<IProduction> ICity.Productions
        {
            get => Productions.Cast<IProduction>().ToList();
            set => Productions = value.Cast<Production>().ToList();
        }

        IRegion ICity.Region
        {
            get => Region;
            set => Region = (Region)value!;
        }
    }
}
