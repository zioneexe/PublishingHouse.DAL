using System.ComponentModel.DataAnnotations;
using PublishingHouse.Abstractions.Entity;

namespace PublishingHouse.DAL.Model
{
    public partial class Book : IBook
    {
        public int BookId { get; set; }

        public string Name { get; set; } = null!;

        public int? Sku { get; set; }

        public string? Isbn { get; set; }

        public int? Pages { get; set; }

        public int? PublicationYear { get; set; }

        public string? Author { get; set; }

        public string? Genre { get; set; }

        public string? CoverImagePath { get; set; }

        public string? Size { get; set; }

        public double? Weight { get; set; }

        public string? Annotation { get; set; }

        public DateTime? CreateDateTime { get; set; }

        public DateTime? UpdateDateTime { get; set; }
    }
}
