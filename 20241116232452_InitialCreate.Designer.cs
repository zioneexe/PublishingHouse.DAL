﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PublishingHouse.DAL;

#nullable disable

namespace PublishingHouse.DAL.Migrations
{
    [DbContext(typeof(PublishingHouseDbContext))]
    [Migration("20241116232452_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PublishingHouse.DAL.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("author_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorId"));

                    b.Property<DateTime?>("CreateDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("create_date_time")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime")
                        .HasColumnName("update_date_time");

                    b.HasKey("AuthorId")
                        .HasName("PK__Author__86516BCF012D9928");

                    b.ToTable("Author", (string)null);
                });

            modelBuilder.Entity("PublishingHouse.DAL.Models.BatchPrint", b =>
                {
                    b.Property<int>("BatchPrintId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("batch_print_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BatchPrintId"));

                    b.Property<int>("BookQuantity")
                        .HasColumnType("int")
                        .HasColumnName("book_quantity");

                    b.Property<DateTime?>("CreateDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("create_date_time")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("number");

                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("order_id");

                    b.Property<DateOnly?>("PrintDate")
                        .HasColumnType("date")
                        .HasColumnName("print_date");

                    b.Property<int>("QualityMarkId")
                        .HasColumnType("int")
                        .HasColumnName("quality_mark_id");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime")
                        .HasColumnName("update_date_time");

                    b.HasKey("BatchPrintId")
                        .HasName("PK__BatchPri__131B3A7EC54E4416");

                    b.HasIndex(new[] { "OrderId" }, "IX_BatchPrint_order_id");

                    b.HasIndex(new[] { "QualityMarkId" }, "IX_BatchPrint_quality_mark_id");

                    b.HasIndex(new[] { "Number" }, "UQ__BatchPri__FD291E41379E45D8")
                        .IsUnique();

                    b.ToTable("BatchPrint", (string)null);
                });

            modelBuilder.Entity("PublishingHouse.DAL.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("book_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<string>("Annotation")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("annotation");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int")
                        .HasColumnName("author_id");

                    b.Property<DateTime?>("CreateDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("create_date_time")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("GenreId")
                        .HasColumnType("int")
                        .HasColumnName("genre_id");

                    b.Property<string>("Isbn")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("isbn");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.Property<int?>("Pages")
                        .HasColumnType("int")
                        .HasColumnName("pages");

                    b.Property<int?>("PublicationYear")
                        .HasColumnType("int")
                        .HasColumnName("publication_year");

                    b.Property<string>("Size")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("size");

                    b.Property<int?>("Sku")
                        .HasColumnType("int")
                        .HasColumnName("sku");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime")
                        .HasColumnName("update_date_time");

                    b.Property<double?>("Weight")
                        .HasColumnType("float")
                        .HasColumnName("weight");

                    b.HasKey("BookId")
                        .HasName("PK__Book__490D1AE1FAB61FFC");

                    b.HasIndex(new[] { "AuthorId" }, "IX_Book_author_id");

                    b.HasIndex(new[] { "GenreId" }, "IX_Book_genre_id");

                    b.HasIndex(new[] { "Isbn" }, "UQ__Book__99F9D0A4F1E9F5EB")
                        .IsUnique()
                        .HasFilter("([isbn] IS NOT NULL)");

                    b.HasIndex(new[] { "Sku" }, "UQ__Book__DDDF4BE7DF804B82")
                        .IsUnique()
                        .HasFilter("([sku] IS NOT NULL)");

                    b.ToTable("Book", (string)null);
                });

            modelBuilder.Entity("PublishingHouse.DAL.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("city_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CityId"));

                    b.Property<DateTime?>("CreateDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("create_date_time")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.Property<int>("RegionId")
                        .HasColumnType("int")
                        .HasColumnName("region_id");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime")
                        .HasColumnName("update_date_time");

                    b.HasKey("CityId")
                        .HasName("PK__City__031491A89C885CD3");

                    b.HasIndex(new[] { "RegionId" }, "IX_City_region_id");

                    b.HasIndex(new[] { "Name" }, "UQ__City__72E12F1B3F8A30DF")
                        .IsUnique()
                        .HasFilter("([name] IS NOT NULL)");

                    b.ToTable("City", (string)null);
                });

            modelBuilder.Entity("PublishingHouse.DAL.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("customer_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<DateOnly?>("AddressDate")
                        .HasColumnType("date")
                        .HasColumnName("address_date");

                    b.Property<DateTime?>("CreateDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("create_date_time")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("CustomerTypeId")
                        .HasColumnType("int")
                        .HasColumnName("customer_type_id");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime")
                        .HasColumnName("update_date_time");

                    b.HasKey("CustomerId")
                        .HasName("PK__Customer__CD65CB85A5E50DCE");

                    b.HasIndex(new[] { "CustomerTypeId" }, "IX_Customer_customer_type_id");

                    b.HasIndex(new[] { "Email" }, "UQ__Customer__AB6E6164A1E2BC8B")
                        .IsUnique()
                        .HasFilter("([email] IS NOT NULL)");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("PublishingHouse.DAL.Models.CustomerType", b =>
                {
                    b.Property<int>("CustomerTypeId")
                        .HasColumnType("int")
                        .HasColumnName("customer_type_id");

                    b.Property<DateTime?>("CreateDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("create_date_time")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime")
                        .HasColumnName("update_date_time");

                    b.HasKey("CustomerTypeId")
                        .HasName("PK__Customer__3320C939B312FD9C");

                    b.HasIndex(new[] { "Name" }, "UQ__Customer__72E12F1B37997F41")
                        .IsUnique()
                        .HasFilter("([name] IS NOT NULL)");

                    b.ToTable("CustomerType", (string)null);
                });

            modelBuilder.Entity("PublishingHouse.DAL.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("employee_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<DateTime?>("CreateDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("create_date_time")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("email");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("full_name");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("phone_number");

                    b.Property<int>("PositionId")
                        .HasColumnType("int")
                        .HasColumnName("position_id");

                    b.Property<int>("ProductionId")
                        .HasColumnType("int")
                        .HasColumnName("production_id");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime")
                        .HasColumnName("update_date_time");

                    b.HasKey("EmployeeId")
                        .HasName("PK__Employee__C52E0BA865444AFD");

                    b.HasIndex(new[] { "PositionId" }, "IX_Employee_position_id");

                    b.HasIndex(new[] { "ProductionId" }, "IX_Employee_production_id");

                    b.HasIndex(new[] { "PhoneNumber" }, "UQ__Employee__A1936A6BBA3899EE")
                        .IsUnique()
                        .HasFilter("([phone_number] IS NOT NULL)");

                    b.HasIndex(new[] { "Email" }, "UQ__Employee__AB6E6164588F4D9A")
                        .IsUnique()
                        .HasFilter("([email] IS NOT NULL)");

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("PublishingHouse.DAL.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("genre_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreId"));

                    b.Property<DateTime?>("CreateDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("create_date_time")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime")
                        .HasColumnName("update_date_time");

                    b.HasKey("GenreId")
                        .HasName("PK__Genre__18428D42A6AD92BD");

                    b.HasIndex(new[] { "Name" }, "UQ__Genre__72E12F1B6E44BE51")
                        .IsUnique()
                        .HasFilter("([name] IS NOT NULL)");

                    b.ToTable("Genre", (string)null);
                });

            modelBuilder.Entity("PublishingHouse.DAL.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("order_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<DateOnly?>("CompletionDate")
                        .HasColumnType("date")
                        .HasColumnName("completion_date");

                    b.Property<string>("CoverTypeName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("cover_type_name");

                    b.Property<DateTime?>("CreateDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("create_date_time")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int")
                        .HasColumnName("customer_id");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int")
                        .HasColumnName("employee_id");

                    b.Property<string>("FasteningTypeName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("fastening_type_name");

                    b.Property<bool>("IsLaminated")
                        .HasColumnType("bit")
                        .HasColumnName("is_laminated");

                    b.Property<int>("Number")
                        .HasColumnType("int")
                        .HasColumnName("number");

                    b.Property<int>("OrderStatusId")
                        .HasColumnType("int")
                        .HasColumnName("order_status_id");

                    b.Property<string>("PaperTypeName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("paper_type_name");

                    b.Property<double>("Price")
                        .HasColumnType("float")
                        .HasColumnName("price");

                    b.Property<string>("PrintTypeName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("print_type_name");

                    b.Property<DateOnly?>("RegistrationDate")
                        .HasColumnType("date")
                        .HasColumnName("registration_date");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime")
                        .HasColumnName("update_date_time");

                    b.HasKey("OrderId")
                        .HasName("PK__Order__465962296D5A0762");

                    b.HasIndex(new[] { "CustomerId" }, "IX_Order_customer_id");

                    b.HasIndex(new[] { "EmployeeId" }, "IX_Order_employee_id");

                    b.HasIndex(new[] { "OrderStatusId" }, "IX_Order_order_status_id");

                    b.HasIndex(new[] { "Number" }, "UQ__Order__FD291E41598A55E5")
                        .IsUnique();

                    b.ToTable("Order", (string)null);
                });

            modelBuilder.Entity("PublishingHouse.DAL.Models.OrderBook", b =>
                {
                    b.Property<int>("OrderBooksId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("order_books_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderBooksId"));

                    b.Property<int>("BookId")
                        .HasColumnType("int")
                        .HasColumnName("book_id");

                    b.Property<int>("BookQuantity")
                        .HasColumnType("int")
                        .HasColumnName("book_quantity");

                    b.Property<DateTime?>("CreateDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("create_date_time")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("order_id");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime")
                        .HasColumnName("update_date_time");

                    b.HasKey("OrderBooksId")
                        .HasName("PK__OrderBoo__6F7F4BB7FF20B05F");

                    b.HasIndex(new[] { "BookId" }, "IX_OrderBooks_book_id");

                    b.HasIndex(new[] { "OrderId" }, "IX_OrderBooks_order_id");

                    b.ToTable("OrderBooks");
                });

            modelBuilder.Entity("PublishingHouse.DAL.Models.OrderStatus", b =>
                {
                    b.Property<int>("OrderStatusId")
                        .HasColumnType("int")
                        .HasColumnName("order_status_id");

                    b.Property<DateTime?>("CreateDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("create_date_time")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime")
                        .HasColumnName("update_date_time");

                    b.HasKey("OrderStatusId")
                        .HasName("PK__OrderSta__A499CF2300833604");

                    b.HasIndex(new[] { "Name" }, "UQ__OrderSta__72E12F1BE09B9235")
                        .IsUnique()
                        .HasFilter("([name] IS NOT NULL)");

                    b.ToTable("OrderStatus", (string)null);
                });

            modelBuilder.Entity("PublishingHouse.DAL.Models.Position", b =>
                {
                    b.Property<int>("PositionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("position_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PositionId"));

                    b.Property<DateTime?>("CreateDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("create_date_time")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime")
                        .HasColumnName("update_date_time");

                    b.HasKey("PositionId")
                        .HasName("PK__Position__99A0E7A4FF163008");

                    b.HasIndex(new[] { "Name" }, "UQ__Position__72E12F1B42C105FD")
                        .IsUnique()
                        .HasFilter("([name] IS NOT NULL)");

                    b.ToTable("Position", (string)null);
                });

            modelBuilder.Entity("PublishingHouse.DAL.Models.Production", b =>
                {
                    b.Property<int>("ProductionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("production_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductionId"));

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("address");

                    b.Property<int>("CityId")
                        .HasColumnType("int")
                        .HasColumnName("city_id");

                    b.Property<DateTime?>("CreateDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("create_date_time")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("ProductionTypeId")
                        .HasColumnType("int")
                        .HasColumnName("production_type_id");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime")
                        .HasColumnName("update_date_time");

                    b.HasKey("ProductionId")
                        .HasName("PK__Producti__60F4D65C9A130039");

                    b.HasIndex(new[] { "CityId" }, "IX_Production_city_id");

                    b.HasIndex(new[] { "ProductionTypeId" }, "IX_Production_production_type_id");

                    b.ToTable("Production", (string)null);
                });

            modelBuilder.Entity("PublishingHouse.DAL.Models.ProductionType", b =>
                {
                    b.Property<int>("ProductionTypeId")
                        .HasColumnType("int")
                        .HasColumnName("production_type_id");

                    b.Property<DateTime?>("CreateDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("create_date_time")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime")
                        .HasColumnName("update_date_time");

                    b.HasKey("ProductionTypeId")
                        .HasName("PK__Producti__27977FA8B59B031D");

                    b.HasIndex(new[] { "Name" }, "UQ__Producti__72E12F1B9BC0F829")
                        .IsUnique()
                        .HasFilter("([name] IS NOT NULL)");

                    b.ToTable("ProductionType", (string)null);
                });

            modelBuilder.Entity("PublishingHouse.DAL.Models.QualityMark", b =>
                {
                    b.Property<int>("QualityMarkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("quality_mark_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QualityMarkId"));

                    b.Property<DateTime?>("CreateDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("create_date_time")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime")
                        .HasColumnName("update_date_time");

                    b.HasKey("QualityMarkId")
                        .HasName("PK__QualityM__F1D96A9E97A782C1");

                    b.HasIndex(new[] { "Name" }, "UQ__QualityM__72E12F1BA44D2C05")
                        .IsUnique()
                        .HasFilter("([name] IS NOT NULL)");

                    b.ToTable("QualityMark", (string)null);
                });

            modelBuilder.Entity("PublishingHouse.DAL.Models.Region", b =>
                {
                    b.Property<int>("RegionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("region_id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RegionId"));

                    b.Property<DateTime?>("CreateDateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("create_date_time")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("name");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime")
                        .HasColumnName("update_date_time");

                    b.HasKey("RegionId")
                        .HasName("PK__Region__01146BAE59E3B543");

                    b.HasIndex(new[] { "Name" }, "UQ__Region__72E12F1BF8AED798")
                        .IsUnique()
                        .HasFilter("([name] IS NOT NULL)");

                    b.ToTable("Region", (string)null);
                });

            modelBuilder.Entity("PublishingHouse.DAL.Models.BatchPrint", b =>
                {
                    b.HasOne("PublishingHouse.DAL.Models.Order", "Order")
                        .WithMany("BatchPrints")
                        .HasForeignKey("OrderId")
                        .IsRequired()
                        .HasConstraintName("FK__BatchPrin__updat__14270015");

                    b.HasOne("PublishingHouse.DAL.Models.QualityMark", "QualityMark")
                        .WithMany("BatchPrints")
                        .HasForeignKey("QualityMarkId")
                        .IsRequired()
                        .HasConstraintName("FK__BatchPrin__quali__151B244E");

                    b.Navigation("Order");

                    b.Navigation("QualityMark");
                });

            modelBuilder.Entity("PublishingHouse.DAL.Models.Book", b =>
                {
                    b.HasOne("PublishingHouse.DAL.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .IsRequired()
                        .HasConstraintName("FK__Book__update_dat__6B24EA82");

                    b.HasOne("PublishingHouse.DAL.Models.Genre", "Genre")
                        .WithMany("Books")
                        .HasForeignKey("GenreId")
                        .IsRequired()
                        .HasConstraintName("FK__Book__genre_id__6C190EBB");

                    b.Navigation("Author");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("PublishingHouse.DAL.Models.City", b =>
                {
                    b.HasOne("PublishingHouse.DAL.Models.Region", "Region")
                        .WithMany("Cities")
                        .HasForeignKey("RegionId")
                        .IsRequired()
                        .HasConstraintName("FK__City__update_dat__571DF1D5");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("PublishingHouse.DAL.Models.Customer", b =>
                {
                    b.HasOne("PublishingHouse.DAL.Models.CustomerType", "CustomerType")
                        .WithMany("Customers")
                        .HasForeignKey("CustomerTypeId")
                        .IsRequired()
                        .HasConstraintName("FK__Customer__update__71D1E811");

                    b.Navigation("CustomerType");
                });

            modelBuilder.Entity("PublishingHouse.DAL.Models.Employee", b =>
                {
                    b.HasOne("PublishingHouse.DAL.Models.Position", "Position")
                        .WithMany("Employees")
                        .HasForeignKey("PositionId")
                        .IsRequired()
                        .HasConstraintName("FK__Employee__update__619B8048");

                    b.HasOne("PublishingHouse.DAL.Models.Production", "Production")
                        .WithMany("Employees")
                        .HasForeignKey("ProductionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Employee__produc__628FA481");

                    b.Navigation("Position");

                    b.Navigation("Production");
                });

            modelBuilder.Entity("PublishingHouse.DAL.Models.Order", b =>
                {
                    b.HasOne("PublishingHouse.DAL.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .IsRequired()
                        .HasConstraintName("FK__Order__customer___0C85DE4D");

                    b.HasOne("PublishingHouse.DAL.Models.Employee", "Employee")
                        .WithMany("Orders")
                        .HasForeignKey("EmployeeId")
                        .IsRequired()
                        .HasConstraintName("FK__Order__employee___0D7A0286");

                    b.HasOne("PublishingHouse.DAL.Models.OrderStatus", "OrderStatus")
                        .WithMany("Orders")
                        .HasForeignKey("OrderStatusId")
                        .IsRequired()
                        .HasConstraintName("FK__Order__order_sta__0B91BA14");

                    b.Navigation("Customer");

                    b.Navigation("Employee");

                    b.Navigation("OrderStatus");
                });

            modelBuilder.Entity("PublishingHouse.DAL.Models.OrderBook", b =>
                {
                    b.HasOne("PublishingHouse.DAL.Models.Book", "Book")
                        .WithMany("OrderBooks")
                        .HasForeignKey("BookId")
                        .IsRequired()
                        .HasConstraintName("FK__OrderBook__book___1AD3FDA4");

                    b.HasOne("PublishingHouse.DAL.Models.Order", "Order")
                        .WithMany("OrderBooks")
                        .HasForeignKey("OrderId")
                        .IsRequired()
                        .HasConstraintName("FK__OrderBook__updat__19DFD96B");

                    b.Navigation("Book");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("PublishingHouse.DAL.Models.Production", b =>
                {
                    b.HasOne("PublishingHouse.DAL.Models.City", "City")
                        .WithMany("Productions")
                        .HasForeignKey("CityId")
                        .IsRequired()
                        .HasConstraintName("FK__Productio__city___5BE2A6F2");

                    b.HasOne("PublishingHouse.DAL.Models.ProductionType", "ProductionType")
                        .WithMany("Productions")
                        .HasForeignKey("ProductionTypeId")
                        .IsRequired()
                        .HasConstraintName("FK__Productio__updat__5AEE82B9");

                    b.Navigation("City");

                    b.Navigation("ProductionType");
                });

            modelBuilder.Entity("PublishingHouse.DAL.Models.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("PublishingHouse.DAL.Models.Book", b =>
                {
                    b.Navigation("OrderBooks");
                });

            modelBuilder.Entity("PublishingHouse.DAL.Models.City", b =>
                {
                    b.Navigation("Productions");
                });

            modelBuilder.Entity("PublishingHouse.DAL.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("PublishingHouse.DAL.Models.CustomerType", b =>
                {
                    b.Navigation("Customers");
                });

            modelBuilder.Entity("PublishingHouse.DAL.Models.Employee", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("PublishingHouse.DAL.Models.Genre", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("PublishingHouse.DAL.Models.Order", b =>
                {
                    b.Navigation("BatchPrints");

                    b.Navigation("OrderBooks");
                });

            modelBuilder.Entity("PublishingHouse.DAL.Models.OrderStatus", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("PublishingHouse.DAL.Models.Position", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("PublishingHouse.DAL.Models.Production", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("PublishingHouse.DAL.Models.ProductionType", b =>
                {
                    b.Navigation("Productions");
                });

            modelBuilder.Entity("PublishingHouse.DAL.Models.QualityMark", b =>
                {
                    b.Navigation("BatchPrints");
                });

            modelBuilder.Entity("PublishingHouse.DAL.Models.Region", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}
