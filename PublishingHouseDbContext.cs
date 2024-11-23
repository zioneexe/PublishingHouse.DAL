using Microsoft.EntityFrameworkCore;
using PublishingHouse.DAL.Entity;

namespace PublishingHouse.DAL;

public partial class PublishingHouseDbContext : DbContext
{
    public PublishingHouseDbContext()
    {
    }

    public PublishingHouseDbContext(DbContextOptions<PublishingHouseDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<BatchPrint> BatchPrints { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerType> CustomerTypes { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<OrderBook> OrderBooks { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<PrintOrder> PrintOrders { get; set; }

    public virtual DbSet<Production> Productions { get; set; }

    public virtual DbSet<ProductionType> ProductionTypes { get; set; }

    public virtual DbSet<QualityMark> QualityMarks { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admin__43AA4141C7877CB0");

            entity.ToTable("Admin");

            entity.HasIndex(e => e.UserId, "UQ__Admin__B9BE370E40F23370").IsUnique();

            entity.Property(e => e.AdminId).HasColumnName("admin_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.Department)
                .HasMaxLength(255)
                .HasColumnName("department");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithOne(p => p.Admin)
                .HasForeignKey<Admin>(d => d.UserId)
                .HasConstraintName("FK__Admin__user_id__634EBE90");
        });

        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.AuthorId).HasName("PK__Author__86516BCFAB446216");

            entity.ToTable("Author");

            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");
        });

        modelBuilder.Entity<BatchPrint>(entity =>
        {
            entity.HasKey(e => e.BatchPrintId).HasName("PK__BatchPri__131B3A7E22864534");

            entity.ToTable("BatchPrint");

            entity.HasIndex(e => e.Number, "UQ__BatchPri__FD291E41B1E14406").IsUnique();

            entity.Property(e => e.BatchPrintId).HasColumnName("batch_print_id");
            entity.Property(e => e.BookQuantity).HasColumnName("book_quantity");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.Number)
                .HasMaxLength(255)
                .HasColumnName("number");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.PrintDate).HasColumnName("print_date");
            entity.Property(e => e.QualityMarkId).HasColumnName("quality_mark_id");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");

            entity.HasOne(d => d.Order).WithMany(p => p.BatchPrints)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BatchPrin__updat__01D345B0");

            entity.HasOne(d => d.QualityMark).WithMany(p => p.BatchPrints)
                .HasForeignKey(d => d.QualityMarkId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__BatchPrin__quali__02C769E9");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__Book__490D1AE11E94B7E0");

            entity.ToTable("Book");

            entity.HasIndex(e => e.Isbn, "UQ__Book__99F9D0A4745D556C").IsUnique();

            entity.HasIndex(e => e.Sku, "UQ__Book__DDDF4BE78D032874").IsUnique();

            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.Annotation)
                .HasMaxLength(500)
                .HasColumnName("annotation");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.GenreId).HasColumnName("genre_id");
            entity.Property(e => e.Isbn)
                .HasMaxLength(20)
                .HasColumnName("isbn");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Pages).HasColumnName("pages");
            entity.Property(e => e.PublicationYear).HasColumnName("publication_year");
            entity.Property(e => e.Size)
                .HasMaxLength(50)
                .HasColumnName("size");
            entity.Property(e => e.Sku).HasColumnName("sku");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");
            entity.Property(e => e.Weight).HasColumnName("weight");

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Book__update_dat__6BE40491");

            entity.HasOne(d => d.Genre).WithMany(p => p.Books)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Book__genre_id__6CD828CA");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PK__City__031491A848DF29EC");

            entity.ToTable("City");

            entity.HasIndex(e => e.Name, "UQ__City__72E12F1B0C612C9A").IsUnique();

            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.RegionId).HasColumnName("region_id");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");

            entity.HasOne(d => d.Region).WithMany(p => p.Cities)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__City__update_dat__531856C7");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__CD65CB850C221190");

            entity.ToTable("Customer");

            entity.HasIndex(e => e.Email, "UQ__Customer__AB6E6164FBEB906C").IsUnique();

            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.AddressDate).HasColumnName("address_date");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.CustomerTypeId).HasColumnName("customer_type_id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");

            entity.HasOne(d => d.CustomerType).WithMany(p => p.Customers)
                .HasForeignKey(d => d.CustomerTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Customer__update__72910220");
        });

        modelBuilder.Entity<CustomerType>(entity =>
        {
            entity.HasKey(e => e.CustomerTypeId).HasName("PK__Customer__3320C939AD7E17BD");

            entity.ToTable("CustomerType");

            entity.HasIndex(e => e.Name, "UQ__Customer__72E12F1B59917A9E").IsUnique();

            entity.Property(e => e.CustomerTypeId)
                .ValueGeneratedNever()
                .HasColumnName("customer_type_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__C52E0BA82065EEAB");

            entity.ToTable("Employee");

            entity.HasIndex(e => e.UserId, "UQ__Employee__B9BE370E4E2C7666").IsUnique();

            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.PositionId).HasColumnName("position_id");
            entity.Property(e => e.ProductionId).HasColumnName("production_id");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Position).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Employee__update__5CA1C101");

            entity.HasOne(d => d.Production).WithMany(p => p.Employees)
                .HasForeignKey(d => d.ProductionId)
                .HasConstraintName("FK__Employee__produc__5D95E53A");

            entity.HasOne(d => d.User).WithOne(p => p.Employee)
                .HasForeignKey<Employee>(d => d.UserId)
                .HasConstraintName("FK__Employee__user_i__5E8A0973");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.GenreId).HasName("PK__Genre__18428D42C6B052A9");

            entity.ToTable("Genre");

            entity.HasIndex(e => e.Name, "UQ__Genre__72E12F1B840B315C").IsUnique();

            entity.Property(e => e.GenreId).HasColumnName("genre_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");
        });

        modelBuilder.Entity<OrderBook>(entity =>
        {
            entity.HasKey(e => e.OrderBooksId).HasName("PK__OrderBoo__6F7F4BB716436A2F");

            entity.Property(e => e.OrderBooksId).HasColumnName("order_books_id");
            entity.Property(e => e.BookId).HasColumnName("book_id");
            entity.Property(e => e.BookQuantity).HasColumnName("book_quantity");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");

            entity.HasOne(d => d.Book).WithMany(p => p.OrderBooks)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderBook__book___0880433F");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderBooks)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderBook__updat__078C1F06");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.HasKey(e => e.OrderStatusId).HasName("PK__OrderSta__A499CF2325C121F2");

            entity.ToTable("OrderStatus");

            entity.HasIndex(e => e.Name, "UQ__OrderSta__72E12F1BA2D4DCAB").IsUnique();

            entity.Property(e => e.OrderStatusId)
                .ValueGeneratedNever()
                .HasColumnName("order_status_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.PositionId).HasName("PK__Position__99A0E7A421BDE14B");

            entity.ToTable("Position");

            entity.HasIndex(e => e.Name, "UQ__Position__72E12F1B62DE1B97").IsUnique();

            entity.Property(e => e.PositionId).HasColumnName("position_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");
        });

        modelBuilder.Entity<PrintOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__PrintOrd__46596229906EE16E");

            entity.ToTable("PrintOrder");

            entity.HasIndex(e => e.Number, "UQ__PrintOrd__FD291E41EC5F3387").IsUnique();

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.CompletionDate).HasColumnName("completion_date");
            entity.Property(e => e.CoverType)
                .HasMaxLength(100)
                .HasColumnName("cover_type");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.FasteningType)
                .HasMaxLength(100)
                .HasColumnName("fastening_type");
            entity.Property(e => e.IsLaminated).HasColumnName("is_laminated");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.OrderStatusId).HasColumnName("order_status_id");
            entity.Property(e => e.PaperType)
                .HasMaxLength(100)
                .HasColumnName("paper_type");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.PrintType)
                .HasMaxLength(100)
                .HasColumnName("print_type");
            entity.Property(e => e.RegistrationDate).HasColumnName("registration_date");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");

            entity.HasOne(d => d.Customer).WithMany(p => p.PrintOrders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PrintOrde__custo__7A3223E8");

            entity.HasOne(d => d.Employee).WithMany(p => p.PrintOrders)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PrintOrde__emplo__7B264821");

            entity.HasOne(d => d.OrderStatus).WithMany(p => p.PrintOrders)
                .HasForeignKey(d => d.OrderStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PrintOrde__updat__793DFFAF");
        });

        modelBuilder.Entity<Production>(entity =>
        {
            entity.HasKey(e => e.ProductionId).HasName("PK__Producti__60F4D65C9377E19B");

            entity.ToTable("Production");

            entity.Property(e => e.ProductionId).HasColumnName("production_id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.ProductionTypeId).HasColumnName("production_type_id");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");

            entity.HasOne(d => d.City).WithMany(p => p.Productions)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Productio__city___57DD0BE4");

            entity.HasOne(d => d.ProductionType).WithMany(p => p.Productions)
                .HasForeignKey(d => d.ProductionTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Productio__updat__56E8E7AB");
        });

        modelBuilder.Entity<ProductionType>(entity =>
        {
            entity.HasKey(e => e.ProductionTypeId).HasName("PK__Producti__27977FA8C05506DA");

            entity.ToTable("ProductionType");

            entity.HasIndex(e => e.Name, "UQ__Producti__72E12F1B949AE5C2").IsUnique();

            entity.Property(e => e.ProductionTypeId)
                .ValueGeneratedNever()
                .HasColumnName("production_type_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");
        });

        modelBuilder.Entity<QualityMark>(entity =>
        {
            entity.HasKey(e => e.QualityMarkId).HasName("PK__QualityM__F1D96A9EC050D447");

            entity.ToTable("QualityMark");

            entity.HasIndex(e => e.Name, "UQ__QualityM__72E12F1B83341E29").IsUnique();

            entity.Property(e => e.QualityMarkId).HasColumnName("quality_mark_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.RegionId).HasName("PK__Region__01146BAE16614F6D");

            entity.ToTable("Region");

            entity.HasIndex(e => e.Name, "UQ__Region__72E12F1BB9D45034").IsUnique();

            entity.Property(e => e.RegionId).HasColumnName("region_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__760965CC471A52B9");

            entity.ToTable("Role");

            entity.HasIndex(e => e.Name, "UQ__Role__72E12F1BA687F40B").IsUnique();

            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__B9BE370FF5F697EA");

            entity.ToTable("User");

            entity.HasIndex(e => e.PhoneNumber, "UQ__User__A1936A6B6A7DAA1B").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__User__AB6E61645418BFCE").IsUnique();

            entity.HasIndex(e => e.Username, "UQ__User__F3DBC5723FCF9A25").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.CreateDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("create_date_time");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .HasColumnName("full_name");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(500)
                .HasColumnName("password_hash");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(40)
                .HasColumnName("phone_number");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UpdateDateTime)
                .HasColumnType("datetime")
                .HasColumnName("update_date_time");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("username");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__User__update_dat__30C33EC3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
