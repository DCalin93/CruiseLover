using Microsoft.EntityFrameworkCore.Migrations;

namespace CruiseLover.DB.Migrations
{
    public partial class AddedShipEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "CruiseDetails");

            migrationBuilder.AddColumn<int>(
                name: "ShipId",
                table: "CruiseDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Ships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ships", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CruiseDetails_ShipId",
                table: "CruiseDetails",
                column: "ShipId");

            migrationBuilder.AddForeignKey(
                name: "FK_CruiseDetails_Ships_ShipId",
                table: "CruiseDetails",
                column: "ShipId",
                principalTable: "Ships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CruiseDetails_Ships_ShipId",
                table: "CruiseDetails");

            migrationBuilder.DropTable(
                name: "Ships");

            migrationBuilder.DropIndex(
                name: "IX_CruiseDetails_ShipId",
                table: "CruiseDetails");

            migrationBuilder.DropColumn(
                name: "ShipId",
                table: "CruiseDetails");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "CruiseDetails",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
