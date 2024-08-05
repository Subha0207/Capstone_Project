using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaApp.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Crusts_CrustId",
                table: "CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Sizes_SizeId",
                table: "CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Toppings_ToppingId",
                table: "CartItem");

            migrationBuilder.AlterColumn<int>(
                name: "ToppingId",
                table: "CartItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SizeId",
                table: "CartItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "PizzaTotalPrice",
                table: "CartItem",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "CrustId",
                table: "CartItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: 1,
                column: "UploadDate",
                value: new DateTime(2024, 8, 3, 17, 8, 46, 330, DateTimeKind.Local).AddTicks(4499));

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: 2,
                column: "UploadDate",
                value: new DateTime(2024, 7, 21, 17, 8, 46, 330, DateTimeKind.Local).AddTicks(4499));

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: 3,
                column: "UploadDate",
                value: new DateTime(2024, 7, 17, 17, 8, 46, 330, DateTimeKind.Local).AddTicks(4499));

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: 4,
                column: "UploadDate",
                value: new DateTime(2024, 7, 12, 17, 8, 46, 330, DateTimeKind.Local).AddTicks(4499));

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: 5,
                column: "UploadDate",
                value: new DateTime(2024, 7, 17, 17, 8, 46, 330, DateTimeKind.Local).AddTicks(4499));

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Crusts_CrustId",
                table: "CartItem",
                column: "CrustId",
                principalTable: "Crusts",
                principalColumn: "CrustId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Sizes_SizeId",
                table: "CartItem",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Toppings_ToppingId",
                table: "CartItem",
                column: "ToppingId",
                principalTable: "Toppings",
                principalColumn: "ToppingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Crusts_CrustId",
                table: "CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Sizes_SizeId",
                table: "CartItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Toppings_ToppingId",
                table: "CartItem");

            migrationBuilder.AlterColumn<int>(
                name: "ToppingId",
                table: "CartItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SizeId",
                table: "CartItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PizzaTotalPrice",
                table: "CartItem",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CrustId",
                table: "CartItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: 1,
                column: "UploadDate",
                value: new DateTime(2024, 8, 3, 13, 54, 56, 778, DateTimeKind.Local).AddTicks(5535));

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: 2,
                column: "UploadDate",
                value: new DateTime(2024, 7, 21, 13, 54, 56, 778, DateTimeKind.Local).AddTicks(5535));

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: 3,
                column: "UploadDate",
                value: new DateTime(2024, 7, 17, 13, 54, 56, 778, DateTimeKind.Local).AddTicks(5535));

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: 4,
                column: "UploadDate",
                value: new DateTime(2024, 7, 12, 13, 54, 56, 778, DateTimeKind.Local).AddTicks(5535));

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "PizzaId",
                keyValue: 5,
                column: "UploadDate",
                value: new DateTime(2024, 7, 17, 13, 54, 56, 778, DateTimeKind.Local).AddTicks(5535));

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Crusts_CrustId",
                table: "CartItem",
                column: "CrustId",
                principalTable: "Crusts",
                principalColumn: "CrustId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Sizes_SizeId",
                table: "CartItem",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "SizeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Toppings_ToppingId",
                table: "CartItem",
                column: "ToppingId",
                principalTable: "Toppings",
                principalColumn: "ToppingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
