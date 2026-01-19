using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vending.Api.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTypeDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SerialNumber",
                table: "VendingMachines",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "ManufactureDate",
                table: "VendingMachines",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "InventoryNumber",
                table: "VendingMachines",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VendingMachines_InventoryNumber",
                table: "VendingMachines",
                column: "InventoryNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VendingMachines_SerialNumber",
                table: "VendingMachines",
                column: "SerialNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VendingMachines_InventoryNumber",
                table: "VendingMachines");

            migrationBuilder.DropIndex(
                name: "IX_VendingMachines_SerialNumber",
                table: "VendingMachines");

            migrationBuilder.AlterColumn<string>(
                name: "SerialNumber",
                table: "VendingMachines",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ManufactureDate",
                table: "VendingMachines",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "InventoryNumber",
                table: "VendingMachines",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
