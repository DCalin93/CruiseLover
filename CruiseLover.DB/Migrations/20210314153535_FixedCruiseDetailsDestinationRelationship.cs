using Microsoft.EntityFrameworkCore.Migrations;

namespace CruiseLover.DB.Migrations
{
    public partial class FixedCruiseDetailsDestinationRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CruiseDetails_Destinations_DestinationId",
                table: "CruiseDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Destinations",
                table: "Destinations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Destinations",
                table: "Destinations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CruiseDetails_Destinations_DestinationId",
                table: "CruiseDetails",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CruiseDetails_Destinations_DestinationId",
                table: "CruiseDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Destinations",
                table: "Destinations");


            migrationBuilder.AddPrimaryKey(
                name: "PK_Destination",
                table: "Destinations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CruiseDetails_Destinations_DestinationId",
                table: "CruiseDetails",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
