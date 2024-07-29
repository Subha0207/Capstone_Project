using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaApp.Migrations
{
    public partial class imagepizza : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: 1,
                column: "UploadDate",
                value: new DateTime(2024, 7, 28, 21, 21, 31, 294, DateTimeKind.Local).AddTicks(5286));

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: 2,
                column: "UploadDate",
                value: new DateTime(2024, 7, 15, 21, 21, 31, 294, DateTimeKind.Local).AddTicks(5286));

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: 3,
                column: "UploadDate",
                value: new DateTime(2024, 7, 11, 21, 21, 31, 294, DateTimeKind.Local).AddTicks(5286));

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: 4,
                columns: new[] { "Image", "UploadDate" },
                values: new object[] { "https://images.unsplash.com/photo-1534308983496-4fabb1a015ee?q=80&w=1776&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", new DateTime(2024, 7, 6, 21, 21, 31, 294, DateTimeKind.Local).AddTicks(5286) });

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: 5,
                columns: new[] { "Image", "UploadDate" },
                values: new object[] { "https://media.istockphoto.com/id/1442417585/photo/person-getting-a-piece-of-cheesy-pepperoni-pizza.jpg?s=1024x1024&w=is&k=20&c=faq73viCFGvfpKxcBuHcOI8kyT99B-p-jScipke-VuQ=", new DateTime(2024, 7, 11, 21, 21, 31, 294, DateTimeKind.Local).AddTicks(5286) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: 1,
                column: "UploadDate",
                value: new DateTime(2024, 7, 28, 20, 44, 12, 933, DateTimeKind.Local).AddTicks(6695));

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: 2,
                column: "UploadDate",
                value: new DateTime(2024, 7, 15, 20, 44, 12, 933, DateTimeKind.Local).AddTicks(6695));

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: 3,
                column: "UploadDate",
                value: new DateTime(2024, 7, 11, 20, 44, 12, 933, DateTimeKind.Local).AddTicks(6695));

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: 4,
                columns: new[] { "Image", "UploadDate" },
                values: new object[] { "https://www.vecteezy.com/png/44771686-a-tasty-pepperoni-pizza", new DateTime(2024, 7, 6, 20, 44, 12, 933, DateTimeKind.Local).AddTicks(6695) });

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: 5,
                columns: new[] { "Image", "UploadDate" },
                values: new object[] { "https://www.vecteezy.com/png/24589246-top-view-pizza-with-ai-generated", new DateTime(2024, 7, 11, 20, 44, 12, 933, DateTimeKind.Local).AddTicks(6695) });
        }
    }
}
