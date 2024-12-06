using PublishingHouse.Abstractions.Entity;

namespace PublishingHouse.DAL.Model
{
    public partial class OrderBook : IOrderBook
    {
        public int OrderBooksId { get; set; }

        public int OrderId { get; set; }

        public int BookId { get; set; }

        public int BookQuantity { get; set; }

        public DateTime? CreateDateTime { get; set; }

        public DateTime? UpdateDateTime { get; set; }

        public virtual Book Book { get; set; } = null!;

        public virtual PrintOrder Order { get; set; } = null!;

        IBook IOrderBook.Book
        {
            get => Book;
            set => Book = (Book)value;
        }

        IPrintOrder IOrderBook.Order
        {
            get => Order;
            set => Order = (PrintOrder)value;
        }
    }
}
