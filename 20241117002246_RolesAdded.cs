using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublishingHouse.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RolesAdded : Migration
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
                    table.PrimaryKey("PK__Author__86516BCFAB446216", x => x.author_id);
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
                    table.PrimaryKey("PK__Genre__18428D42C6B052A9", x => x.genre_id);
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
                name: "Role",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Role__760965CC471A52B9", x => x.role_id);
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
                    table.PrimaryKey("PK__Customer__CD65CB850C221190", x => x.customer_id);
                    table.ForeignKey(
                        name: "FK__Customer__update__72910220",
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
                    table.PrimaryKey("PK__Book__490D1AE11E94B7E0", x => x.book_id);
                    table.ForeignKey(
                        name: "FK__Book__genre_id__6CD828CA",
                        column: x => x.genre_id,
                        principalTable: "Genre",
                        principalColumn: "genre_id");
                    table.ForeignKey(
                        name: "FK__Book__update_dat__6BE40491",
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
                    table.PrimaryKey("PK__City__031491A848DF29EC", x => x.city_id);
                    table.ForeignKey(
                        name: "FK__City__update_dat__531856C7",
                        column: x => x.region_id,
                        principalTable: "Region",
                        principalColumn: "region_id");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_id = table.Column<int>(type: "int", nullable: false),
                    username = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    password_hash = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    full_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__User__B9BE370FF5F697EA", x => x.user_id);
                    table.ForeignKey(
                        name: "FK__User__update_dat__30C33EC3",
                        column: x => x.role_id,
                        principalTable: "Role",
                        principalColumn: "role_id");
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
                name: "Admin",
                columns: table => new
                {
                    admin_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    department = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Admin__43AA4141C7877CB0", x => x.admin_id);
                    table.ForeignKey(
                        name: "FK__Admin__user_id__634EBE90",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    employee_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    position_id = table.Column<int>(type: "int", nullable: false),
                    production_id = table.Column<int>(type: "int", nullable: false),
                    create_date_time = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    update_date_time = table.Column<DateTime>(type: "datetime", nullable: true)
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
                    table.ForeignKey(
                        name: "FK__Employee__user_i__5E8A0973",
                        column: x => x.user_id,
                        principalTable: "User",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrintOrder",
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
                        principalTable: "PrintOrder",
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
                        principalTable: "PrintOrder",
                        principalColumn: "order_id");
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Admin__B9BE370E40F23370",
                table: "Admin",
                column: "user_id",
                unique: true);

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
                name: "IX_Book_author_id",
                table: "Book",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "IX_Book_genre_id",
                table: "Book",
                column: "genre_id");

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Genre__72E12F1B840B315C",
                table: "Genre",
                column: "name",
                unique: true,
                filter: "[name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderBooks_book_id",
                table: "OrderBooks",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderBooks_order_id",
                table: "OrderBooks",
                column: "order_id");

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
                name: "IX_PrintOrder_customer_id",
                table: "PrintOrder",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_PrintOrder_employee_id",
                table: "PrintOrder",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_PrintOrder_order_status_id",
                table: "PrintOrder",
                column: "order_status_id");

            migrationBuilder.CreateIndex(
                name: "UQ__PrintOrd__FD291E41EC5F3387",
                table: "PrintOrder",
                column: "number",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "UQ__Role__72E12F1BA687F40B",
                table: "Role",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_role_id",
                table: "User",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "UQ__User__A1936A6B6A7DAA1B",
                table: "User",
                column: "phone_number",
                unique: true,
                filter: "[phone_number] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__User__AB6E61645418BFCE",
                table: "User",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__User__F3DBC5723FCF9A25",
                table: "User",
                column: "username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "BatchPrint");

            migrationBuilder.DropTable(
                name: "OrderBooks");

            migrationBuilder.DropTable(
                name: "QualityMark");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "PrintOrder");

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
                name: "User");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "ProductionType");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Region");
        }
    }
}
