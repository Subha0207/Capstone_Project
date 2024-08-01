using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaApp.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beverages",
                columns: table => new
                {
                    BeverageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Volume = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsBestSeller = table.Column<bool>(type: "bit", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beverages", x => x.BeverageId);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsCheckedOut = table.Column<bool>(type: "bit", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                });

            migrationBuilder.CreateTable(
                name: "Crusts",
                columns: table => new
                {
                    CrustId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false),
                    CrustMultiplier = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crusts", x => x.CrustId);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Method = table.Column<int>(type: "int", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    PizzaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsVeg = table.Column<bool>(type: "bit", nullable: false),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsBestSeller = table.Column<bool>(type: "bit", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.PizzaId);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    SizeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false),
                    SizeMultiplier = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.SizeId);
                });

            migrationBuilder.CreateTable(
                name: "Toppings",
                columns: table => new
                {
                    ToppingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toppings", x => x.ToppingId);
                });

            migrationBuilder.CreateTable(
                name: "UserDTO",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDTO", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    CartItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PizzaId = table.Column<int>(type: "int", nullable: true),
                    CrustId = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false),
                    ToppingId = table.Column<int>(type: "int", nullable: false),
                    PizzaDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PizzaFinalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PizzaCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BeverageId = table.Column<int>(type: "int", nullable: true),
                    PizzaTotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PizzaQuantity = table.Column<int>(type: "int", nullable: true),
                    BeverageQuantity = table.Column<int>(type: "int", nullable: true),
                    BeverageCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BeverageDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BeverageFinalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BeverageTotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CartId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.CartItemId);
                    table.ForeignKey(
                        name: "FK_CartItem_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItem_Crusts_CrustId",
                        column: x => x.CrustId,
                        principalTable: "Crusts",
                        principalColumn: "CrustId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItem_Pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "PizzaId");
                    table.ForeignKey(
                        name: "FK_CartItem_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "SizeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItem_Toppings_ToppingId",
                        column: x => x.ToppingId,
                        principalTable: "Toppings",
                        principalColumn: "ToppingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentId1 = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Payments_PaymentId1",
                        column: x => x.PaymentId1,
                        principalTable: "Payments",
                        principalColumn: "PaymentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_UserDTO_UserId",
                        column: x => x.UserId,
                        principalTable: "UserDTO",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Beverages",
                columns: new[] { "BeverageId", "Cost", "Description", "Image", "IsAvailable", "IsBestSeller", "Name", "UploadDate", "Volume" },
                values: new object[,]
                {
                    { 1, 30m, "A classic soft drink.", "https://images.unsplash.com/photo-1554866585-cd94860890b7?q=80&w=1965&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", false, true, "Coca Cola", new DateTime(2024, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "200ml" },
                    { 2, 19m, "Popular cola drink.", "https://images.unsplash.com/photo-1553456558-aff63285bdd1?q=80&w=1887&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", false, false, "Pepsi", new DateTime(2024, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "100ml" },
                    { 3, 29m, "Refreshing lemon-lime soda.", "https://images.unsplash.com/photo-1690988109041-458628590a9e?q=80&w=1776&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", false, false, "Sprite", new DateTime(2024, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "200ml" },
                    { 4, 39m, "Fruity orange soda.", "https://media.istockphoto.com/id/509533066/photo/fanta-orange-can.jpg?s=612x612&w=0&k=20&c=sbii6ppPvyuny-v0mx9xizy0QppblYH3sEvPLBr31tA=", false, true, "Fanta", new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "500ml" },
                    { 5, 69m, "Citrus-flavored soda.", "https://images.unsplash.com/photo-1632134547266-ab2cb69602a1?q=80&w=1932&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", false, false, "Mountain Dew", new DateTime(2024, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "1000ml" }
                });

            migrationBuilder.InsertData(
                table: "Crusts",
                columns: new[] { "CrustId", "Cost", "CrustMultiplier", "Name" },
                values: new object[,]
                {
                    { 1, 1m, 1m, 0 },
                    { 2, 1m, 1.2m, 1 },
                    { 3, 1m, 1.4m, 2 }
                });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "PizzaId", "Cost", "Description", "Image", "IsAvailable", "IsBestSeller", "IsVeg", "Name", "UploadDate" },
                values: new object[,]
                {
                    { 1, 199m, "Classic Margherita pizza with fresh mozzarella and basil.", "https://images.unsplash.com/photo-1544982503-9f984c14501a?q=80&w=1887&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", true, true, true, "Margherita", new DateTime(2024, 8, 1, 21, 1, 13, 116, DateTimeKind.Local).AddTicks(200) },
                    { 2, 209m, "Pepperoni pizza with a crispy crust and rich tomato sauce.", "https://plus.unsplash.com/premium_photo-1661762555601-47d088a26b50?q=80&w=1792&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", true, true, false, "Pepperoni", new DateTime(2024, 7, 19, 21, 1, 13, 116, DateTimeKind.Local).AddTicks(200) },
                    { 3, 149m, "Loaded with fresh vegetables and a savory sauce.", "https://images.unsplash.com/photo-1593560708920-61dd98c46a4e?q=80&w=1935&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", true, false, true, "Vegetarian Supreme", new DateTime(2024, 7, 15, 21, 1, 13, 116, DateTimeKind.Local).AddTicks(200) },
                    { 4, 299m, "Grilled chicken with BBQ sauce and red onions.", "https://images.unsplash.com/photo-1534308983496-4fabb1a015ee?q=80&w=1776&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", true, false, false, "BBQ Chicken", new DateTime(2024, 7, 10, 21, 1, 13, 116, DateTimeKind.Local).AddTicks(200) },
                    { 5, 279m, "Sweet pineapple and ham with a cheesy base.", "https://media.istockphoto.com/id/1442417585/photo/person-getting-a-piece-of-cheesy-pepperoni-pizza.jpg?s=1024x1024&w=is&k=20&c=faq73viCFGvfpKxcBuHcOI8kyT99B-p-jScipke-VuQ=", true, false, false, "Hawaiian", new DateTime(2024, 7, 15, 21, 1, 13, 116, DateTimeKind.Local).AddTicks(200) }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "SizeId", "Cost", "Name", "SizeMultiplier" },
                values: new object[,]
                {
                    { 1, 1m, 0, 1m },
                    { 2, 1m, 1, 1.2m },
                    { 3, 1m, 2, 1.4m }
                });

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "ToppingId", "Cost", "Name" },
                values: new object[,]
                {
                    { 2, 29m, 1 },
                    { 3, 15m, 2 },
                    { 4, 20m, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_CartId",
                table: "CartItem",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_CrustId",
                table: "CartItem",
                column: "CrustId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_PizzaId",
                table: "CartItem",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_SizeId",
                table: "CartItem",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ToppingId",
                table: "CartItem",
                column: "ToppingId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CartId",
                table: "Orders",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentId1",
                table: "Orders",
                column: "PaymentId1");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beverages");

            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Crusts");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Toppings");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "UserDTO");
        }
    }
}
