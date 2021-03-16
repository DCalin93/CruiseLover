using Microsoft.EntityFrameworkCore.Migrations;

namespace CruiseLover.DB.Migrations
{
    public partial class AddedDestinationEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DestinationId",
                table: "CruiseDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Destinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinations", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CruiseDetails_DestinationId",
                table: "CruiseDetails",
                column: "DestinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_CruiseDetails_Destinations_DestinationId",
                table: "CruiseDetails",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CruiseDetails_Destinations_DestinationId",
                table: "CruiseDetails");

            migrationBuilder.DropTable(
                name: "Destinations");

            migrationBuilder.DropIndex(
                name: "IX_CruiseDetails_DestinationId",
                table: "CruiseDetails");

            migrationBuilder.DropColumn(
                name: "DestinationId",
                table: "CruiseDetails");
        }
    }
}
