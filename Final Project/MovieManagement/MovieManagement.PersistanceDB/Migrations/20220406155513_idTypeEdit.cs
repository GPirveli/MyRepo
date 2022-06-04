using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieManagement.PersistanceDB.Migrations
{
    public partial class idTypeEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookedTickets_AspNetUsers_AccountId1",
                table: "BookedTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_SoldTickets_AspNetUsers_AccountId1",
                table: "SoldTickets");

            migrationBuilder.DropIndex(
                name: "IX_SoldTickets_AccountId1",
                table: "SoldTickets");

            migrationBuilder.DropIndex(
                name: "IX_BookedTickets_AccountId1",
                table: "BookedTickets");

            migrationBuilder.DropColumn(
                name: "AccountId1",
                table: "SoldTickets");

            migrationBuilder.DropColumn(
                name: "AccountId1",
                table: "BookedTickets");

            migrationBuilder.AlterColumn<string>(
                name: "AccountId",
                table: "SoldTickets",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "AccountId",
                table: "BookedTickets",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_SoldTickets_AccountId",
                table: "SoldTickets",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_BookedTickets_AccountId",
                table: "BookedTickets",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookedTickets_AspNetUsers_AccountId",
                table: "BookedTickets",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SoldTickets_AspNetUsers_AccountId",
                table: "SoldTickets",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookedTickets_AspNetUsers_AccountId",
                table: "BookedTickets");

            migrationBuilder.DropForeignKey(
                name: "FK_SoldTickets_AspNetUsers_AccountId",
                table: "SoldTickets");

            migrationBuilder.DropIndex(
                name: "IX_SoldTickets_AccountId",
                table: "SoldTickets");

            migrationBuilder.DropIndex(
                name: "IX_BookedTickets_AccountId",
                table: "BookedTickets");

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "SoldTickets",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "AccountId1",
                table: "SoldTickets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "BookedTickets",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "AccountId1",
                table: "BookedTickets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SoldTickets_AccountId1",
                table: "SoldTickets",
                column: "AccountId1");

            migrationBuilder.CreateIndex(
                name: "IX_BookedTickets_AccountId1",
                table: "BookedTickets",
                column: "AccountId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BookedTickets_AspNetUsers_AccountId1",
                table: "BookedTickets",
                column: "AccountId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SoldTickets_AspNetUsers_AccountId1",
                table: "SoldTickets",
                column: "AccountId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
