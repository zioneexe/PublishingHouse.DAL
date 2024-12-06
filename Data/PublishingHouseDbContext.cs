using Microsoft.EntityFrameworkCore;
using PublishingHouse.Abstractions.Entity;
using PublishingHouse.DAL.Model;
using PublishingHouse.DAL.Data.Seed;

namespace PublishingHouse.DAL.Data
{
    public partial class PublishingHouseDbContext(DbContextOptions<PublishingHouseDbContext> options) : DbContext(options)
    {
        public virtual required DbSet<BatchPrint> BatchPrints { get; set; }

        public virtual required DbSet<Book> Books { get; set; }

        public virtual required DbSet<City> Cities { get; set; }

        public virtual required DbSet<Customer> Customers { get; set; }

        public virtual required DbSet<CustomerType> CustomerTypes { get; set; }

        public virtual required DbSet<Employee> Employees { get; set; }

        public virtual required DbSet<OrderBook> OrderBooks { get; set; }

        public virtual required DbSet<OrderStatus> OrderStatuses { get; set; }

        public virtual required DbSet<Position> Positions { get; set; }

        public virtual required DbSet<PrintOrder> PrintOrders { get; set; }

        public virtual required DbSet<Production> Productions { get; set; }

        public virtual required DbSet<ProductionType> ProductionTypes { get; set; }

        public virtual required DbSet<QualityMark> QualityMarks { get; set; }

        public virtual required DbSet<Region> Regions { get; set; }

        public virtual required DbSet<OrderRequest> OrderRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderRequest>(entity =>
            {
                entity.ToTable("OrderRequest");

                entity.Property(e => e.OrderRequestId).HasColumnName("order_request_id");
                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.BookName)
                    .HasMaxLength(255)
                    .HasColumnName("book_name");

                entity.Property(e => e.AuthorName)
                    .HasMaxLength(255)
                    .HasColumnName("author_name");

                entity.Property(e => e.Genre)
                    .HasMaxLength(100)
                    .HasColumnName("genre");

                entity.Property(e => e.PublicationYear).HasColumnName("publication_year");
                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.PrintType)
                    .HasMaxLength(50)
                    .HasColumnName("print_type");
                entity.Property(e => e.PaperType)
                    .HasMaxLength(50)
                    .HasColumnName("paper_type");
                entity.Property(e => e.CoverType)
                    .HasMaxLength(50)
                    .HasColumnName("cover_type");
                entity.Property(e => e.FasteningType)
                    .HasMaxLength(50)
                    .HasColumnName("fastening_type");

                entity.Property(e => e.IsLaminated).HasColumnName("is_laminated");

                entity.Property(e => e.CoverImagePath)
                    .HasMaxLength(512)
                    .HasColumnName("cover_image_path");

                entity.Property(e => e.CompletionDate).HasColumnName("completion_date");
            
                entity.Property(e => e.CreateDateTime)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("create_date_time");
                entity.Property(e => e.UpdateDateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("update_date_time");

                entity.HasOne(d => d.Customer).WithMany(p => p.OrderRequests)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
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
                entity.Property(e => e.CreateDateTime)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime")
                    .HasColumnName("create_date_time");
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
                entity.Property(e => e.Genre)
                    .HasMaxLength(50)
                    .HasColumnName("genre");
                entity.Property(e => e.Author)
                    .HasMaxLength(100)
                    .HasColumnName("author");
                entity.Property(e => e.CoverImagePath)
                    .HasMaxLength(512)
                    .HasColumnName("cover_image_path");
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

            modelBuilder.Entity<City>().HasData(
                new City
                {
                    CityId = 1,
                    Name = "Springfield",
                    RegionId = 1,
                    CreateDateTime = DateTime.UtcNow,
                    UpdateDateTime = null
                },
                new City
                {
                    CityId = 2,
                    Name = "Shelbyville",
                    RegionId = 1,
                    CreateDateTime = DateTime.UtcNow,
                    UpdateDateTime = null
                },
                new City
                {
                    CityId = 3,
                    Name = "Ogdenville",
                    RegionId = 2,
                    CreateDateTime = DateTime.UtcNow,
                    UpdateDateTime = null
                }
            );

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
                entity.Property(e => e.UserId)
                    .HasMaxLength(450)
                    .HasColumnName("user_id");

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

            modelBuilder.Entity<CustomerType>().HasData(
                new CustomerType
                {
                    CustomerTypeId = 1,
                    Name = "Individual",
                    CreateDateTime = DateTime.UtcNow
                },
                new CustomerType
                {
                    CustomerTypeId = 2,
                    Name = "Corporate",
                    CreateDateTime = DateTime.UtcNow
                }
            );

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
                entity.Property(e => e.UserId)
                    .HasMaxLength(450)
                    .HasColumnName("user_id");
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.HasOne(d => d.Position).WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employee__update__5CA1C101");

                entity.HasOne(d => d.Production).WithMany(p => p.Employees)
                    .HasForeignKey(d => d.ProductionId)
                    .HasConstraintName("FK__Employee__produc__5D95E53A");
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

                entity.HasOne(d => d.Book).WithMany()
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderBook__book___0880433F");

                entity.HasOne(d => d.Order).WithMany()
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

            modelBuilder.Entity<OrderStatus>().HasData(
                new OrderStatus
                {
                    OrderStatusId = 1,
                    Name = "Pending",
                    CreateDateTime = DateTime.UtcNow,
                    UpdateDateTime = null
                },
                new OrderStatus
                {
                    OrderStatusId = 2,
                    Name = "Completed",
                    CreateDateTime = DateTime.UtcNow,
                    UpdateDateTime = null
                },
                new OrderStatus
                {
                    OrderStatusId = 3,
                    Name = "Cancelled",
                    CreateDateTime = DateTime.UtcNow,
                    UpdateDateTime = null
                },
                new OrderStatus
                {
                    OrderStatusId = 4,
                    Name = "In Progress",
                    CreateDateTime = DateTime.UtcNow,
                    UpdateDateTime = null
                },
                new OrderStatus
                {
                    OrderStatusId = 5,
                    Name = "On Hold",
                    CreateDateTime = DateTime.UtcNow,
                    UpdateDateTime = null
                }
            );

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

            modelBuilder.Entity<Position>().HasData(
                new Position
                {
                    PositionId = 1,
                    Name = "Manager",
                    CreateDateTime = DateTime.UtcNow,
                    UpdateDateTime = null
                },
                new Position
                {
                    PositionId = 2,
                    Name = "Designer",
                    CreateDateTime = DateTime.UtcNow,
                    UpdateDateTime = null
                },
                new Position
                {
                    PositionId = 3,
                    Name = "Editor",
                    CreateDateTime = DateTime.UtcNow,
                    UpdateDateTime = null
                },
                new Position
                {
                    PositionId = 4,
                    Name = "Printer",
                    CreateDateTime = DateTime.UtcNow,
                    UpdateDateTime = null
                },
                new Position
                {
                    PositionId = 5,
                    Name = "Binder",
                    CreateDateTime = DateTime.UtcNow,
                    UpdateDateTime = null
                }
            );

            modelBuilder.Entity<PrintOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId).HasName("PK__PrintOrd__46596229906EE16E");

                entity.ToTable("Order");

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

            modelBuilder.Entity<Production>().HasData(
                new Production
                {
                    ProductionId = 1,
                    ProductionTypeId = 1,
                    CityId = 1,
                    Address = "123 Main St",
                    CreateDateTime = DateTime.UtcNow,
                    UpdateDateTime = null
                },
                new Production
                {
                    ProductionId = 2,
                    ProductionTypeId = 1,
                    CityId = 2,
                    Address = "456 Elm St",
                    CreateDateTime = DateTime.UtcNow,
                    UpdateDateTime = null
                },
                new Production
                {
                    ProductionId = 3,
                    ProductionTypeId = 2,
                    CityId = 1,
                    Address = "789 Oak St",
                    CreateDateTime = DateTime.UtcNow,
                    UpdateDateTime = null
                },
                new Production
                {
                    ProductionId = 4,
                    ProductionTypeId = 2,
                    CityId = 3,
                    Address = "101 Pine St",
                    CreateDateTime = DateTime.UtcNow,
                    UpdateDateTime = null
                },
                new Production
                {
                    ProductionId = 5,
                    ProductionTypeId = 1,
                    CityId = 3,
                    Address = "202 Maple St",
                    CreateDateTime = DateTime.UtcNow,
                    UpdateDateTime = null
                }
            );

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

            modelBuilder.Entity<ProductionType>().HasData(
                new ProductionType
                {
                    ProductionTypeId = 1,
                    Name = "Printing",
                    CreateDateTime = DateTime.UtcNow,
                    UpdateDateTime = null
                },
                new ProductionType
                {
                    ProductionTypeId = 2,
                    Name = "Binding",
                    CreateDateTime = DateTime.UtcNow,
                    UpdateDateTime = null
                }
            );

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

            modelBuilder.Entity<QualityMark>().HasData(
                new QualityMark
                {
                    QualityMarkId = 1,
                    Name = "Excellent",
                    CreateDateTime = DateTime.UtcNow,
                    UpdateDateTime = null
                },
                new QualityMark
                {
                    QualityMarkId = 2,
                    Name = "High",
                    CreateDateTime = DateTime.UtcNow,
                    UpdateDateTime = null
                },
                new QualityMark
                {
                    QualityMarkId = 3,
                    Name = "Moderate",
                    CreateDateTime = DateTime.UtcNow,
                    UpdateDateTime = null
                },
                new QualityMark
                {
                    QualityMarkId = 4,
                    Name = "Defective",
                    CreateDateTime = DateTime.UtcNow,
                    UpdateDateTime = null
                }
            );

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

            modelBuilder.Entity<Region>().HasData(
                new Region
                {
                    RegionId = 1,
                    Name = "North Region",
                    CreateDateTime = DateTime.UtcNow,
                    UpdateDateTime = null
                },
                new Region
                {
                    RegionId = 2,
                    Name = "South Region",
                    CreateDateTime = DateTime.UtcNow,
                    UpdateDateTime = null
                }
            );

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
