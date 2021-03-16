using Microsoft.EntityFrameworkCore.Migrations;

namespace CruiseLover.DB.Migrations
{
    public partial class CreatedCruiseDetailShipRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CruiseDetails_Ships_ShipId",
                table: "CruiseDetails");

            migrationBuilder.DropIndex(
                name: "IX_CruiseDetails_ShipId",
                table: "CruiseDetails");

            migrationBuilder.AlterColumn<int>(
                name: "ShipId",
                table: "CruiseDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CruiseDetails_Ships_ShipId",
                table: "CruiseDetails");

            migrationBuilder.DropIndex(
                name: "IX_CruiseDetails_ShipId",
                table: "CruiseDetails");

            migrationBuilder.AlterColumn<int>(
                name: "ShipId",
                table: "CruiseDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
    }
}
