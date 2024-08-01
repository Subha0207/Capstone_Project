using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaApp.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: 1,
                column: "UploadDate",
                value: new DateTime(2024, 8, 1, 21, 20, 22, 81, DateTimeKind.Local).AddTicks(8733));

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: 2,
                column: "UploadDate",
                value: new DateTime(2024, 7, 19, 21, 20, 22, 81, DateTimeKind.Local).AddTicks(8733));

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: 3,
                column: "UploadDate",
                value: new DateTime(2024, 7, 15, 21, 20, 22, 81, DateTimeKind.Local).AddTicks(8733));

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: 4,
                column: "UploadDate",
                value: new DateTime(2024, 7, 10, 21, 20, 22, 81, DateTimeKind.Local).AddTicks(8733));

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: 5,
                column: "UploadDate",
                value: new DateTime(2024, 7, 15, 21, 20, 22, 81, DateTimeKind.Local).AddTicks(8733));

            migrationBuilder.UpdateData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: 2,
                columns: new[] { "Cost", "Name" },
                values: new object[] { 15m, 2 });

            migrationBuilder.UpdateData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: 3,
                columns: new[] { "Cost", "Name" },
                values: new object[] { 20m, 3 });

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "ToppingId", "Cost", "Name" },
                values: new object[] { 1, 29m, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: 1,
                column: "UploadDate",
                value: new DateTime(2024, 8, 1, 21, 1, 13, 116, DateTimeKind.Local).AddTicks(200));

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: 2,
                column: "UploadDate",
                value: new DateTime(2024, 7, 19, 21, 1, 13, 116, DateTimeKind.Local).AddTicks(200));

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: 3,
                column: "UploadDate",
                value: new DateTime(2024, 7, 15, 21, 1, 13, 116, DateTimeKind.Local).AddTicks(200));

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: 4,
                column: "UploadDate",
                value: new DateTime(2024, 7, 10, 21, 1, 13, 116, DateTimeKind.Local).AddTicks(200));

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: 5,
                column: "UploadDate",
                value: new DateTime(2024, 7, 15, 21, 1, 13, 116, DateTimeKind.Local).AddTicks(200));

            migrationBuilder.UpdateData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: 2,
                columns: new[] { "Cost", "Name" },
                values: new object[] { 29m, 1 });

            migrationBuilder.UpdateData(
                table: "Toppings",
                keyColumn: "ToppingId",
                keyValue: 3,
                columns: new[] { "Cost", "Name" },
                values: new object[] { 15m, 2 });

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "ToppingId", "Cost", "Name" },
                values: new object[] { 4, 20m, 3 });
        }
    }
}
