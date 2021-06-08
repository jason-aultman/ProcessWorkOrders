using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcessWorkOrders.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zip = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrders",
                columns: table => new
                {
                    WorkOrderNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryItemNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    ExtrusionInstruction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrintingInstruction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrintingUri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VentingUri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LabelingInstruction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkCenter = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesOrderNumber = table.Column<int>(type: "int", nullable: false),
                    DateNeeded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RunSpeed = table.Column<double>(type: "float", nullable: false),
                    Construction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsFda = table.Column<bool>(type: "bit", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrders", x => x.WorkOrderNumber);
                    table.ForeignKey(
                        name: "FK_WorkOrders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<double>(type: "float", nullable: true),
                    Length = table.Column<double>(type: "float", nullable: true),
                    QuantityPer = table.Column<int>(type: "int", nullable: true),
                    Gauge = table.Column<double>(type: "float", nullable: true),
                    Operator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkOrderWorkOrderNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rolls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rolls_WorkOrders_WorkOrderWorkOrderNumber",
                        column: x => x.WorkOrderWorkOrderNumber,
                        principalTable: "WorkOrders",
                        principalColumn: "WorkOrderNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rolls_WorkOrderWorkOrderNumber",
                table: "Rolls",
                column: "WorkOrderWorkOrderNumber");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_CustomerId",
                table: "WorkOrders",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rolls");

            migrationBuilder.DropTable(
                name: "WorkOrders");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
