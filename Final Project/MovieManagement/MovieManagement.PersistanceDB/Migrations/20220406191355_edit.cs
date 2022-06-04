using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieManagement.PersistanceDB.Migrations
{
    public partial class edit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "SoldTickets");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "BookedTickets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "SoldTickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "BookedTickets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
