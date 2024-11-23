﻿using PublishingHouse.Abstractions.Model;

namespace PublishingHouse.DAL.Entity;

public partial class Book : IBook
{
    public int BookId { get; set; }

    public string Name { get; set; } = null!;

    public int AuthorId { get; set; }

    public int GenreId { get; set; }

    public int? Sku { get; set; }

    public string? Isbn { get; set; }

    public int? Pages { get; set; }

    public int? PublicationYear { get; set; }

    public string? Size { get; set; }

    public double? Weight { get; set; }

    public string? Annotation { get; set; }

    public DateTime? CreateDateTime { get; set; }

    public DateTime? UpdateDateTime { get; set; }

    public virtual Author Author { get; set; } = null!;

    public virtual Genre Genre { get; set; } = null!;

    public virtual ICollection<OrderBook> OrderBooks { get; set; } = (List<OrderBook>)[];
}