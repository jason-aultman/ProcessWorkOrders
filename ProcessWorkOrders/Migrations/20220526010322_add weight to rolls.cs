using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcessWorkOrders.Migrations
{
    public partial class addweighttorolls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "Rolls",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Rolls");
        }
    }
}
