using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vending.Api.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    IsManager = table.Column<bool>(type: "boolean", nullable: false),
                    IsEngineer = table.Column<bool>(type: "boolean", nullable: false),
                    IsOperator = table.Column<bool>(type: "boolean", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: false),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.CheckConstraint("checkUserFio", "\"FullName\" != 'test'");
                });

            migrationBuilder.CreateTable(
                name: "VendingMachines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SerialNumber = table.Column<string>(type: "text", nullable: false),
                    InventoryNumber = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    Model = table.Column<string>(type: "text", nullable: false),
                    ModelType = table.Column<string>(type: "text", nullable: false),
                    TotalIncome = table.Column<decimal>(type: "numeric", nullable: false),
                    Company = table.Column<string>(type: "text", nullable: false),
                    ManufacterDate = table.Column<DateOnly>(type: "date", nullable: false),
                    InstallDate = table.Column<DateOnly>(type: "date", nullable: false),
                    LastMaintainceDate = table.Column<DateOnly>(type: "date", nullable: false),
                    MaintainceMonthInterval = table.Column<int>(type: "integer", nullable: false),
                    ResourceHours = table.Column<int>(type: "integer", nullable: false),
                    NextMainainceDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ServiceTime = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    InventoryDate = table.Column<DateOnly>(type: "date", nullable: false),
                    MaintainerId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendingMachines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VendingMachines_Users_MaintainerId",
                        column: x => x.MaintainerId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    VendingMachineId = table.Column<Guid>(type: "uuid", nullable: false),
                    MaintenanceDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Problems = table.Column<string>(type: "text", nullable: false),
                    MaintainerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceRecords_Users_MaintainerId",
                        column: x => x.MaintainerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaintenanceRecords_VendingMachines_VendingMachineId",
                        column: x => x.VendingMachineId,
                        principalTable: "VendingMachines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    MinStock = table.Column<int>(type: "integer", nullable: false),
                    VendingMachineId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    QuantityAvailable = table.Column<int>(type: "integer", nullable: false),
                    SalesTrend = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_VendingMachines_VendingMachineId",
                        column: x => x.VendingMachineId,
                        principalTable: "VendingMachines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    VendingMachineId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    SaleAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    SaleDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PaymentMethodSale = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_VendingMachines_VendingMachineId",
                        column: x => x.VendingMachineId,
                        principalTable: "VendingMachines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRecords_MaintainerId",
                table: "MaintenanceRecords",
                column: "MaintainerId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRecords_VendingMachineId",
                table: "MaintenanceRecords",
                column: "VendingMachineId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_VendingMachineId",
                table: "Products",
                column: "VendingMachineId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ProductId",
                table: "Sales",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_VendingMachineId",
                table: "Sales",
                column: "VendingMachineId");

            migrationBuilder.CreateIndex(
                name: "IX_VendingMachines_InventoryNumber",
                table: "VendingMachines",
                column: "InventoryNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VendingMachines_MaintainerId",
                table: "VendingMachines",
                column: "MaintainerId");

            migrationBuilder.CreateIndex(
                name: "IX_VendingMachines_SerialNumber",
                table: "VendingMachines",
                column: "SerialNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaintenanceRecords");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "VendingMachines");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
