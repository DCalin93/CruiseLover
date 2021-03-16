using Microsoft.EntityFrameworkCore.Migrations;

namespace CruiseLover.DB.Migrations
{
    public partial class ChangedDiscoutToDouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountPercent",
                table: "CruiseDetails");

            migrationBuilder.AddColumn<double>(
                name: "Discount",
                table: "CruiseDetails",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "CruiseDetails");

            migrationBuilder.AddColumn<int>(
                name: "DiscountPercent",
                table: "CruiseDetails",
                type: "int",
                nullable: true);
        }
    }
}
