using Microsoft.EntityFrameworkCore.Migrations;

namespace Akros.Htp.Vendor.Backend.DataAccess.Migrations
{
    public partial class Database_v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Currency",
                table: "Bookings",
                type: "integer",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.RenameColumn(
                name: "Start",
                table: "Entity",
                newName: "Stars");
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Bookings",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Bookings");
            migrationBuilder.RenameColumn(
                name: "Stars",
                table: "Entity",
                newName: "Start");
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Bookings");
        }
    }
}
