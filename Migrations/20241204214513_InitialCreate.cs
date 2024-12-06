using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PublishingHouse.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    book_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    sku = table.Column<int>(type: "int", nullable: true),
                    isbn = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    pages = table.Column<int>(type: "int", nullable: true),
                    publication_year = table.Column<int>(type: "int", nullable: true),
                    author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    genre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    cover_image_path = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    size = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    weight = table.Column<double>(type: "float", nullable: true),
                    annotation = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Book__490D1AE11E94B7E0", x => x.book_id);
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
                    table.PrimaryKey("PK__Customer__3320C939AD7E17BD", x => x.customer_type_id);
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
                    table.PrimaryKey("PK__OrderSta__A499CF2325C121F2", x => x.order_status_id);
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
                    table.PrimaryKey("PK__Position__99A0E7A421BDE14B", x => x.position_id);
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
                    table.PrimaryKey("PK__Producti__27977FA8C05506DA", x => x.production_type_id);
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
                    table.PrimaryKey("PK__QualityM__F1D96A9EC050D447", x => x.quality_mark_id);
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
                    table.PrimaryKey("PK__Region__01146BAE16614F6D", x => x.region_id);
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
                    user_id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__CD65CB850C221190", x => x.customer_id);
                    table.ForeignKey(
                        name: "FK__Customer__update__72910220",
                        column: x => x.customer_type_id,
                        principalTable: "CustomerType",
                        principalColumn: "customer_type_id");
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
                    table.PrimaryKey("PK__City__031491A848DF29EC", x => x.city_id);
                    table.ForeignKey(
                        name: "FK__City__update_dat__531856C7",
                        column: x => x.region_id,
                        principalTable: "Region",
                        principalColumn: "region_id");
                });

            migrationBuilder.CreateTable(
                name: "OrderRequest",
                columns: table => new
                {
                    order_request_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    book_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    author_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    genre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    publication_year = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    print_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    paper_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    cover_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    fastening_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    is_laminated = table.Column<bool>(type: "bit", nullable: true),
                    cover_image_path = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    completion_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderRequest", x => x.order_request_id);
                    table.ForeignKey(
                        name: "FK_OrderRequest_Customer_customer_id",
                        column: x => x.customer_id,
                        principalTable: "Customer",
                        principalColumn: "customer_id");
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
                    table.PrimaryKey("PK__Producti__60F4D65C9377E19B", x => x.production_id);
                    table.ForeignKey(
                        name: "FK__Productio__city___57DD0BE4",
                        column: x => x.city_id,
                        principalTable: "City",
                        principalColumn: "city_id");
                    table.ForeignKey(
                        name: "FK__Productio__updat__56E8E7AB",
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
                    position_id = table.Column<int>(type: "int", nullable: false),
                    production_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true),
                    user_id = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__C52E0BA82065EEAB", x => x.employee_id);
                    table.ForeignKey(
                        name: "FK__Employee__produc__5D95E53A",
                        column: x => x.production_id,
                        principalTable: "Production",
                        principalColumn: "production_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Employee__update__5CA1C101",
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
                    print_type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    paper_type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    cover_type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    fastening_type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    is_laminated = table.Column<bool>(type: "bit", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    order_status_id = table.Column<int>(type: "int", nullable: false),
                    registration_date = table.Column<DateOnly>(type: "date", nullable: true),
                    completion_date = table.Column<DateOnly>(type: "date", nullable: true),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    employee_id = table.Column<int>(type: "int", nullable: false),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PrintOrd__46596229906EE16E", x => x.order_id);
                    table.ForeignKey(
                        name: "FK__PrintOrde__custo__7A3223E8",
                        column: x => x.customer_id,
                        principalTable: "Customer",
                        principalColumn: "customer_id");
                    table.ForeignKey(
                        name: "FK__PrintOrde__emplo__7B264821",
                        column: x => x.employee_id,
                        principalTable: "Employee",
                        principalColumn: "employee_id");
                    table.ForeignKey(
                        name: "FK__PrintOrde__updat__793DFFAF",
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
                    table.PrimaryKey("PK__BatchPri__131B3A7E22864534", x => x.batch_print_id);
                    table.ForeignKey(
                        name: "FK__BatchPrin__quali__02C769E9",
                        column: x => x.quality_mark_id,
                        principalTable: "QualityMark",
                        principalColumn: "quality_mark_id");
                    table.ForeignKey(
                        name: "FK__BatchPrin__updat__01D345B0",
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
                    table.PrimaryKey("PK__OrderBoo__6F7F4BB716436A2F", x => x.order_books_id);
                    table.ForeignKey(
                        name: "FK__OrderBook__book___0880433F",
                        column: x => x.book_id,
                        principalTable: "Book",
                        principalColumn: "book_id");
                    table.ForeignKey(
                        name: "FK__OrderBook__updat__078C1F06",
                        column: x => x.order_id,
                        principalTable: "Order",
                        principalColumn: "order_id");
                });

            migrationBuilder.InsertData(
                table: "CustomerType",
                columns: new[] { "customer_type_id", "create_date_time", "name", "update_date_time" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 4, 21, 45, 12, 656, DateTimeKind.Utc).AddTicks(285), "Individual", null },
                    { 2, new DateTime(2024, 12, 4, 21, 45, 12, 656, DateTimeKind.Utc).AddTicks(495), "Corporate", null }
                });

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new[] { "order_status_id", "create_date_time", "name", "update_date_time" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 4, 21, 45, 12, 661, DateTimeKind.Utc).AddTicks(3750), "Pending", null },
                    { 2, new DateTime(2024, 12, 4, 21, 45, 12, 661, DateTimeKind.Utc).AddTicks(4138), "Completed", null },
                    { 3, new DateTime(2024, 12, 4, 21, 45, 12, 661, DateTimeKind.Utc).AddTicks(4139), "Cancelled", null },
                    { 4, new DateTime(2024, 12, 4, 21, 45, 12, 661, DateTimeKind.Utc).AddTicks(4140), "In Progress", null },
                    { 5, new DateTime(2024, 12, 4, 21, 45, 12, 661, DateTimeKind.Utc).AddTicks(4142), "On Hold", null }
                });

            migrationBuilder.InsertData(
                table: "Position",
                columns: new[] { "position_id", "create_date_time", "name", "update_date_time" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 4, 21, 45, 12, 662, DateTimeKind.Utc).AddTicks(4434), "Manager", null },
                    { 2, new DateTime(2024, 12, 4, 21, 45, 12, 662, DateTimeKind.Utc).AddTicks(4954), "Designer", null },
                    { 3, new DateTime(2024, 12, 4, 21, 45, 12, 662, DateTimeKind.Utc).AddTicks(4956), "Editor", null },
                    { 4, new DateTime(2024, 12, 4, 21, 45, 12, 662, DateTimeKind.Utc).AddTicks(4957), "Printer", null },
                    { 5, new DateTime(2024, 12, 4, 21, 45, 12, 662, DateTimeKind.Utc).AddTicks(4958), "Binder", null }
                });

            migrationBuilder.InsertData(
                table: "ProductionType",
                columns: new[] { "production_type_id", "create_date_time", "name", "update_date_time" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 4, 21, 45, 12, 669, DateTimeKind.Utc).AddTicks(5436), "Printing", null },
                    { 2, new DateTime(2024, 12, 4, 21, 45, 12, 669, DateTimeKind.Utc).AddTicks(5891), "Binding", null }
                });

            migrationBuilder.InsertData(
                table: "QualityMark",
                columns: new[] { "quality_mark_id", "create_date_time", "name", "update_date_time" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 4, 21, 45, 12, 670, DateTimeKind.Utc).AddTicks(7000), "Excellent", null },
                    { 2, new DateTime(2024, 12, 4, 21, 45, 12, 670, DateTimeKind.Utc).AddTicks(7377), "High", null },
                    { 3, new DateTime(2024, 12, 4, 21, 45, 12, 670, DateTimeKind.Utc).AddTicks(7378), "Moderate", null },
                    { 4, new DateTime(2024, 12, 4, 21, 45, 12, 670, DateTimeKind.Utc).AddTicks(7380), "Defective", null }
                });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "region_id", "create_date_time", "name", "update_date_time" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 4, 21, 45, 12, 672, DateTimeKind.Utc).AddTicks(1251), "North Region", null },
                    { 2, new DateTime(2024, 12, 4, 21, 45, 12, 672, DateTimeKind.Utc).AddTicks(1650), "South Region", null }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "city_id", "create_date_time", "name", "region_id", "update_date_time" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 4, 21, 45, 12, 652, DateTimeKind.Utc).AddTicks(8233), "Springfield", 1, null },
                    { 2, new DateTime(2024, 12, 4, 21, 45, 12, 652, DateTimeKind.Utc).AddTicks(8943), "Shelbyville", 1, null },
                    { 3, new DateTime(2024, 12, 4, 21, 45, 12, 652, DateTimeKind.Utc).AddTicks(8944), "Ogdenville", 2, null }
                });

            migrationBuilder.InsertData(
                table: "Production",
                columns: new[] { "production_id", "address", "city_id", "create_date_time", "production_type_id", "update_date_time" },
                values: new object[,]
                {
                    { 1, "123 Main St", 1, new DateTime(2024, 12, 4, 21, 45, 12, 668, DateTimeKind.Utc).AddTicks(2851), 1, null },
                    { 2, "456 Elm St", 2, new DateTime(2024, 12, 4, 21, 45, 12, 668, DateTimeKind.Utc).AddTicks(3238), 1, null },
                    { 3, "789 Oak St", 1, new DateTime(2024, 12, 4, 21, 45, 12, 668, DateTimeKind.Utc).AddTicks(3240), 2, null },
                    { 4, "101 Pine St", 3, new DateTime(2024, 12, 4, 21, 45, 12, 668, DateTimeKind.Utc).AddTicks(3241), 2, null },
                    { 5, "202 Maple St", 3, new DateTime(2024, 12, 4, 21, 45, 12, 668, DateTimeKind.Utc).AddTicks(3242), 1, null }
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
                name: "UQ__BatchPri__FD291E41B1E14406",
                table: "BatchPrint",
                column: "number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Book__99F9D0A4745D556C",
                table: "Book",
                column: "isbn",
                unique: true,
                filter: "[isbn] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__Book__DDDF4BE78D032874",
                table: "Book",
                column: "sku",
                unique: true,
                filter: "[sku] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_City_region_id",
                table: "City",
                column: "region_id");

            migrationBuilder.CreateIndex(
                name: "UQ__City__72E12F1B0C612C9A",
                table: "City",
                column: "name",
                unique: true,
                filter: "[name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_customer_type_id",
                table: "Customer",
                column: "customer_type_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Customer__AB6E6164FBEB906C",
                table: "Customer",
                column: "email",
                unique: true,
                filter: "[email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__Customer__72E12F1B59917A9E",
                table: "CustomerType",
                column: "name",
                unique: true,
                filter: "[name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_position_id",
                table: "Employee",
                column: "position_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_production_id",
                table: "Employee",
                column: "production_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Employee__B9BE370E4E2C7666",
                table: "Employee",
                column: "user_id",
                unique: true,
                filter: "[user_id] IS NOT NULL");

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
                name: "UQ__PrintOrd__FD291E41EC5F3387",
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
                name: "IX_OrderRequest_customer_id",
                table: "OrderRequest",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "UQ__OrderSta__72E12F1BA2D4DCAB",
                table: "OrderStatus",
                column: "name",
                unique: true,
                filter: "[name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__Position__72E12F1B62DE1B97",
                table: "Position",
                column: "name",
                unique: true,
                filter: "[name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Production_city_id",
                table: "Production",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_Production_production_type_id",
                table: "Production",
                column: "production_type_id");

            migrationBuilder.CreateIndex(
                name: "UQ__Producti__72E12F1B949AE5C2",
                table: "ProductionType",
                column: "name",
                unique: true,
                filter: "[name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__QualityM__72E12F1B83341E29",
                table: "QualityMark",
                column: "name",
                unique: true,
                filter: "[name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__Region__72E12F1BB9D45034",
                table: "Region",
                column: "name",
                unique: true,
                filter: "[name] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BatchPrint");

            migrationBuilder.DropTable(
                name: "OrderBooks");

            migrationBuilder.DropTable(
                name: "OrderRequest");

            migrationBuilder.DropTable(
                name: "QualityMark");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Order");

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
