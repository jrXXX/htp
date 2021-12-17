using Microsoft.EntityFrameworkCore.Migrations;

namespace Akros.Htp.Vendor.Backend.DataAccess.Migrations
{
    public partial class Database_v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeepLink",
                table: "Rooms");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeepLink",
                table: "Rooms",
                type: "text",
                nullable: true);
        }
    }
}
