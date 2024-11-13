using PublishingHouse.Infrastructure.Models;

namespace PublishingHouse.Infrastructure.Contexts
{
    public partial class PublishingHouseDbContext : DbContext
    {
        public PublishingHouseDbContext()
        {
        }

        public PublishingHouseDbContext(DbContextOptions<PublishingHouseDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<Message> Messages { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Request> Requests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Book__3213E83F5B9B48CC");

                entity.ToTable("Book");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Author)
                    .HasMaxLength(255)
                    .HasColumnName("author");
                entity.Property(e => e.Isbn).HasColumnName("isbn");
                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
                entity.Property(e => e.Pages).HasColumnName("pages");
                entity.Property(e => e.PublicationYear).HasColumnName("publication_year");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Customer__3213E83F95E0D8C2");

                entity.ToTable("Customer");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.AddressDate)
                    .HasColumnType("datetime")
                    .HasColumnName("address_date");
                entity.Property(e => e.Email)
                    .HasMaxLength(60)
                    .HasColumnName("email");
                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Employee__3213E83F7B83D885");

                entity.ToTable("Employee");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email");
                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .HasColumnName("phone");
                entity.Property(e => e.Position)
                    .HasMaxLength(70)
                    .HasColumnName("position");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Message__3213E83F8009A182");

                entity.ToTable("Message");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .HasColumnName("description");
                entity.Property(e => e.Heading)
                    .HasMaxLength(255)
                    .HasColumnName("heading");
                entity.Property(e => e.IsRead).HasColumnName("is_read");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Order__3213E83F9ECF4D4B");

                entity.ToTable("Order");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.BookId).HasColumnName("book_id");
                entity.Property(e => e.CompletionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("completion_date");
                entity.Property(e => e.CustomerId).HasColumnName("customer_id");
                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .HasColumnName("description");
                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
                entity.Property(e => e.Number)
                    .HasMaxLength(50)
                    .HasColumnName("number");
                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("price");
                entity.Property(e => e.RegistrationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("registration_date");
                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasColumnName("status");

                entity.HasOne(d => d.Book).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order__book_id__5165187F");

                entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order__customer___534D60F1");

                entity.HasOne(d => d.Employee).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order__employee___52593CB8");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Request__3213E83F44475510");

                entity.ToTable("Request");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.IsConsidered).HasColumnName("is_considered");
                entity.Property(e => e.SelectedOrderId).HasColumnName("selected_order_id");
                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasColumnName("status");
                entity.Property(e => e.WantedOrderStatus)
                    .HasMaxLength(50)
                    .HasColumnName("wanted_order_status");

                entity.HasOne(d => d.SelectedOrder).WithMany(p => p.Requests)
                    .HasForeignKey(d => d.SelectedOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Request__selecte__5AEE82B9");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
