using PublishingHouse.Abstractions.Model;

namespace PublishingHouse.DAL.Entity;

public partial class Genre : IGenre
{
    public int GenreId { get; set; }

    public string? Name { get; set; }

    public DateTime? CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
