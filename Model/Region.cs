﻿using PublishingHouse.Abstractions.Entity;

namespace PublishingHouse.DAL.Model
{
    public partial class Region : IRegion
    {
        public int RegionId { get; set; }

        public string? Name { get; set; }

        public DateTime? CreateDateTime { get; set; }

        public DateTime? UpdateDateTime { get; set; }

        public virtual ICollection<City> Cities { get; set; } = new List<City>();
    }
}
