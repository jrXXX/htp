using Microsoft.EntityFrameworkCore.Migrations;

namespace Akros.Htp.Vendor.Backend.DataAccess.Migrations
{
    public partial class Database_v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Rooms_RoomEntityId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_RoomEntityId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "RoomEntityId",
                table: "Bookings");

            migrationBuilder.UpdateData(
                table: "Entity",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Country", "Stars" },
                values: new object[] { "Germany", 1 });

            migrationBuilder.UpdateData(
                table: "Entity",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Country", "Stars" },
                values: new object[] { "Switzerland", 3 });

            migrationBuilder.UpdateData(
                table: "Entity",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Country", "Stars" },
                values: new object[] { "Switzerland", 5 });

            migrationBuilder.InsertData(
                table: "Entity",
                columns: new[] { "Id", "City", "Country", "Homepage", "HouseNumber", "Name", "Price", "Stars", "Street", "ZipCode" },
                values: new object[] { 4L, "Bern", "Switzerland", null, null, ".Net Hotel Bern", 0, 3, null, "8401" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "AlternativeText", "Height", "HotelId", "Image", "ImageUrl", "ThumbImage", "ThumbImageUrl", "Title", "Width" },
                values: new object[,]
                {
                    { 4L, "Bild 1", 200, 4L, (byte)0, "https://htp-vendor-hotel1-ui.azurewebsites.net/static/media/room-11.1605f19e.jpeg", (byte)0, "https://htp-vendor-hotel1-ui.azurewebsites.net/static/media/room-11.1605f19e.jpeg", "Bild 1", 200 },
                    { 5L, "Bild 2", 200, 4L, (byte)0, "https://htp-vendor-hotel1-ui.azurewebsites.net/static/media/room-6.3697aea3.jpeg", (byte)0, "https://htp-vendor-hotel1-ui.azurewebsites.net/static/media/room-6.3697aea3.jpeg", "Bild 2", 200 },
                    { 6L, "Bild 3", 200, 4L, (byte)0, "http://htp-vendor-hotel1-ui.azurewebsites.net/static/media/room-2.48c60181.jpeg", (byte)0, "http://htp-vendor-hotel1-ui.azurewebsites.net/static/media/room-2.48c60181.jpeg", "Bild 3", 200 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Currency", "Floor", "HotelId", "Name", "Price", "Type" },
                values: new object[,]
                {
                    { 101L, 0, 4, 4L, "Aareblick", 500, 8 },
                    { 102L, 0, 2, 4L, "Stadtblick", 300, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 101L);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 102L);

            migrationBuilder.DeleteData(
                table: "Entity",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.AddColumn<long>(
                name: "RoomEntityId",
                table: "Bookings",
                type: "bigint",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Entity",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Country", "Stars" },
                values: new object[] { "Deutschland", 0 });

            migrationBuilder.UpdateData(
                table: "Entity",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Country", "Stars" },
                values: new object[] { "Schweiz", 0 });

            migrationBuilder.UpdateData(
                table: "Entity",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Country", "Stars" },
                values: new object[] { "Schweiz", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomEntityId",
                table: "Bookings",
                column: "RoomEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Rooms_RoomEntityId",
                table: "Bookings",
                column: "RoomEntityId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
