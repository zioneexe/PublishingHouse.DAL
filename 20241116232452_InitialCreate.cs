using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublishingHouse.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    author_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Author__86516BCF012D9928", x => x.author_id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerType",
                columns: table => new
                {
                    customer_type_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__3320C939B312FD9C", x => x.customer_type_id);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    genre_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Genre__18428D42A6AD92BD", x => x.genre_id);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                columns: table => new
                {
                    order_status_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrderSta__A499CF2300833604", x => x.order_status_id);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    position_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Position__99A0E7A4FF163008", x => x.position_id);
                });

            migrationBuilder.CreateTable(
                name: "ProductionType",
                columns: table => new
                {
                    production_type_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Producti__27977FA8B59B031D", x => x.production_type_id);
                });

            migrationBuilder.CreateTable(
                name: "QualityMark",
                columns: table => new
                {
                    quality_mark_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__QualityM__F1D96A9E97A782C1", x => x.quality_mark_id);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    region_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Region__01146BAE59E3B543", x => x.region_id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    customer_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_type_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    address_date = table.Column<DateOnly>(type: "date", nullable: true),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__CD65CB85A5E50DCE", x => x.customer_id);
                    table.ForeignKey(
                        name: "FK__Customer__update__71D1E811",
                        column: x => x.customer_type_id,
                        principalTable: "CustomerType",
                        principalColumn: "customer_type_id");
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    book_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    author_id = table.Column<int>(type: "int", nullable: false),
                    genre_id = table.Column<int>(type: "int", nullable: false),
                    sku = table.Column<int>(type: "int", nullable: true),
                    isbn = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    pages = table.Column<int>(type: "int", nullable: true),
                    publication_year = table.Column<int>(type: "int", nullable: true),
                    size = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    weight = table.Column<double>(type: "float", nullable: true),
                    annotation = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Book__490D1AE1FAB61FFC", x => x.book_id);
                    table.ForeignKey(
                        name: "FK__Book__genre_id__6C190EBB",
                        column: x => x.genre_id,
                        principalTable: "Genre",
                        principalColumn: "genre_id");
                    table.ForeignKey(
                        name: "FK__Book__update_dat__6B24EA82",
                        column: x => x.author_id,
                        principalTable: "Author",
                        principalColumn: "author_id");
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    city_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    region_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__City__031491A89C885CD3", x => x.city_id);
                    table.ForeignKey(
                        name: "FK__City__update_dat__571DF1D5",
                        column: x => x.region_id,
                        principalTable: "Region",
                        principalColumn: "region_id");
                });

            migrationBuilder.CreateTable(
                name: "Production",
                columns: table => new
                {
                    production_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    production_type_id = table.Column<int>(type: "int", nullable: false),
                    city_id = table.Column<int>(type: "int", nullable: false),
                    address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Producti__60F4D65C9A130039", x => x.production_id);
                    table.ForeignKey(
                        name: "FK__Productio__city___5BE2A6F2",
                        column: x => x.city_id,
                        principalTable: "City",
                        principalColumn: "city_id");
                    table.ForeignKey(
                        name: "FK__Productio__updat__5AEE82B9",
                        column: x => x.production_type_id,
                        principalTable: "ProductionType",
                        principalColumn: "production_type_id");
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    employee_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    full_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    position_id = table.Column<int>(type: "int", nullable: false),
                    production_id = table.Column<int>(type: "int", nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__C52E0BA865444AFD", x => x.employee_id);
                    table.ForeignKey(
                        name: "FK__Employee__produc__628FA481",
                        column: x => x.production_id,
                        principalTable: "Production",
                        principalColumn: "production_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Employee__update__619B8048",
                        column: x => x.position_id,
                        principalTable: "Position",
                        principalColumn: "position_id");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    number = table.Column<int>(type: "int", nullable: false),
                    is_laminated = table.Column<bool>(type: "bit", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    order_status_id = table.Column<int>(type: "int", nullable: false),
                    registration_date = table.Column<DateOnly>(type: "date", nullable: true),
                    completion_date = table.Column<DateOnly>(type: "date", nullable: true),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    employee_id = table.Column<int>(type: "int", nullable: false),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    print_type_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    paper_type_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    cover_type_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    fastening_type_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Order__465962296D5A0762", x => x.order_id);
                    table.ForeignKey(
                        name: "FK__Order__customer___0C85DE4D",
                        column: x => x.customer_id,
                        principalTable: "Customer",
                        principalColumn: "customer_id");
                    table.ForeignKey(
                        name: "FK__Order__employee___0D7A0286",
                        column: x => x.employee_id,
                        principalTable: "Employee",
                        principalColumn: "employee_id");
                    table.ForeignKey(
                        name: "FK__Order__order_sta__0B91BA14",
                        column: x => x.order_status_id,
                        principalTable: "OrderStatus",
                        principalColumn: "order_status_id");
                });

            migrationBuilder.CreateTable(
                name: "BatchPrint",
                columns: table => new
                {
                    batch_print_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    number = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    book_quantity = table.Column<int>(type: "int", nullable: false),
                    order_id = table.Column<int>(type: "int", nullable: false),
                    print_date = table.Column<DateOnly>(type: "date", nullable: true),
                    quality_mark_id = table.Column<int>(type: "int", nullable: false),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BatchPri__131B3A7EC54E4416", x => x.batch_print_id);
                    table.ForeignKey(
                        name: "FK__BatchPrin__quali__151B244E",
                        column: x => x.quality_mark_id,
                        principalTable: "QualityMark",
                        principalColumn: "quality_mark_id");
                    table.ForeignKey(
                        name: "FK__BatchPrin__updat__14270015",
                        column: x => x.order_id,
                        principalTable: "Order",
                        principalColumn: "order_id");
                });

            migrationBuilder.CreateTable(
                name: "OrderBooks",
                columns: table => new
                {
                    order_books_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<int>(type: "int", nullable: false),
                    book_id = table.Column<int>(type: "int", nullable: false),
                    book_quantity = table.Column<int>(type: "int", nullable: false),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrderBoo__6F7F4BB7FF20B05F", x => x.order_books_id);
                    table.ForeignKey(
                        name: "FK__OrderBook__book___1AD3FDA4",
                        column: x => x.book_id,
                        principalTable: "Book",
                        principalColumn: "book_id");
                    table.ForeignKey(
                        name: "FK__OrderBook__updat__19DFD96B",
                        column: x => x.order_id,
                        principalTable: "Order",
                        principalColumn: "order_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BatchPrint_order_id",
                table: "BatchPrint",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_BatchPrint_quality_mark_id",
                table: "BatchPrint",
                column: "quality_mark_id");

            migrationBuilder.CreateIndex(
                name: "UQ__BatchPri__FD291E41379E45D8",
                table: "BatchPrint",
                column: "number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Book_author_id",
                table: "Book",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_Book_genre_id",
                table: "Book",
                column: "genre_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Book__99F9D0A4F1E9F5EB",
                table: "Book",
                column: "isbn",
                unique: true,
                filter: "([isbn] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "UQ__Book__DDDF4BE7DF804B82",
                table: "Book",
                column: "sku",
                unique: true,
                filter: "([sku] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_City_region_id",
                table: "City",
                column: "region_id");

            migrationBuilder.CreateIndex(
                name: "UQ__City__72E12F1B3F8A30DF",
                table: "City",
                column: "name",
                unique: true,
                filter: "([name] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_customer_type_id",
                table: "Customer",
                column: "customer_type_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Customer__AB6E6164A1E2BC8B",
                table: "Customer",
                column: "email",
                unique: true,
                filter: "([email] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "UQ__Customer__72E12F1B37997F41",
                table: "CustomerType",
                column: "name",
                unique: true,
                filter: "([name] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_position_id",
                table: "Employee",
                column: "position_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_production_id",
                table: "Employee",
                column: "production_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Employee__A1936A6BBA3899EE",
                table: "Employee",
                column: "phone_number",
                unique: true,
                filter: "([phone_number] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "UQ__Employee__AB6E6164588F4D9A",
                table: "Employee",
                column: "email",
                unique: true,
                filter: "([email] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "UQ__Genre__72E12F1B6E44BE51",
                table: "Genre",
                column: "name",
                unique: true,
                filter: "([name] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_Order_customer_id",
                table: "Order",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_employee_id",
                table: "Order",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_order_status_id",
                table: "Order",
                column: "order_status_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Order__FD291E41598A55E5",
                table: "Order",
                column: "number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderBooks_book_id",
                table: "OrderBooks",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderBooks_order_id",
                table: "OrderBooks",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "UQ__OrderSta__72E12F1BE09B9235",
                table: "OrderStatus",
                column: "name",
                unique: true,
                filter: "([name] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "UQ__Position__72E12F1B42C105FD",
                table: "Position",
                column: "name",
                unique: true,
                filter: "([name] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_Production_city_id",
                table: "Production",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_Production_production_type_id",
                table: "Production",
                column: "production_type_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Producti__72E12F1B9BC0F829",
                table: "ProductionType",
                column: "name",
                unique: true,
                filter: "([name] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "UQ__QualityM__72E12F1BA44D2C05",
                table: "QualityMark",
                column: "name",
                unique: true,
                filter: "([name] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "UQ__Region__72E12F1BF8AED798",
                table: "Region",
                column: "name",
                unique: true,
                filter: "([name] IS NOT NULL)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BatchPrint");

            migrationBuilder.DropTable(
                name: "OrderBooks");

            migrationBuilder.DropTable(
                name: "QualityMark");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "OrderStatus");

            migrationBuilder.DropTable(
                name: "CustomerType");

            migrationBuilder.DropTable(
                name: "Production");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "ProductionType");

            migrationBuilder.DropTable(
                name: "Region");
        }
    }
}
