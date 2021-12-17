using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Akros.Htp.Vendor.Backend.DataAccess.Migrations
{
    public partial class Database_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "HotelId",
                table: "Rooms",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Entity",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BookedFrom = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    BookedTo = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    RoomId = table.Column<long>(type: "bigint", nullable: false),
                    RoomEntityId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Rooms_RoomEntityId",
                        column: x => x.RoomEntityId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Entity",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "City", "Country", "ZipCode" },
                values: new object[] { "Hamburg", "Deutschland", "20251" });

            migrationBuilder.UpdateData(
                table: "Entity",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "City", "Country", "ZipCode" },
                values: new object[] { "Sursee", "Schweiz", "6210" });

            migrationBuilder.UpdateData(
                table: "Entity",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "City", "Country", "ZipCode" },
                values: new object[] { "Sursee", "Schweiz", "6210" });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 1L, 1552 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 2L, 818 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 3L, 83 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 3L, 1789 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 1L, 1054 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 2L, 320 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 3L, 2026 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 1L, 1291 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 2L, 557 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 3L, 2262 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 1L, 1528 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 2L, 793 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 13L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 2L, 2499 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 14L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 3L, 1764 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 15L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 1L, 1030 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 16L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 2L, 295 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 17L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 3L, 2001 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 18L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 1L, 1266 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 19L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 2L, 532 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 20L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 3L, 2237 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 21L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 3L, 1503 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 22L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 1L, 769 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 23L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 2L, 2474 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 24L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 3L, 1740 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 25L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 1L, 1005 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 26L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 2L, 271 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 27L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 3L, 1976 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 28L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 1L, 1242 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 29L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 1L, 507 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 30L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 2L, 2213 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 31L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 3L, 1478 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 32L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 1L, 744 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 33L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 2L, 2449 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 34L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 3L, 1715 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 35L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 1L, 980 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 36L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 2L, 246 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 37L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 3L, 1951 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 38L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 3L, 1217 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 39L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 1L, 483 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 40L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 2L, 2188 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 41L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 3L, 1454 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 42L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 1L, 719 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 43L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 2L, 2425 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 44L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 3L, 1690 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 45L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 1L, 956 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 46L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 1L, 221 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 47L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 2L, 1927 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 48L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 3L, 1192 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 49L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 1L, 458 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 50L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 2L, 2163 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 51L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 3L, 1429 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 52L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 1L, 694 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 53L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 2L, 2400 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 54L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 2L, 1665 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 55L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 3L, 931 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 56L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 1L, 197 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 57L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 2L, 1902 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 58L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 3L, 1168 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 59L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 1L, 433 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 60L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 2L, 2139 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 61L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 3L, 1404 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 62L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 1L, 670 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 63L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 1L, 2375 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 64L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 2L, 1641 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 65L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 3L, 906 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 66L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 1L, 172 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 67L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 2L, 1877 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 68L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 3L, 1143 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 69L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 1L, 408 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 70L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 2L, 2114 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 71L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 2L, 1380 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 72L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 3L, 645 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 73L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 1L, 2351 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 74L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 2L, 1616 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 75L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 3L, 882 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 76L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 1L, 147 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 77L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 2L, 1853 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 78L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 3L, 1118 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 79L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 3L, 384 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 80L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 1L, 2089 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 81L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 2L, 1355 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 82L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 3L, 620 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 83L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 1L, 2326 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 84L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 2L, 1591 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 85L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 3L, 857 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 86L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 1L, 122 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 87L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 2L, 1828 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 88L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 2L, 1094 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 89L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 3L, 359 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 90L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 1L, 2065 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 91L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 2L, 1330 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 92L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 3L, 596 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 93L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 1L, 2301 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 94L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 2L, 1567 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 95L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 3L, 832 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 96L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 3L, 98 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 97L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 1L, 1803 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 98L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 2L, 1069 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 99L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 3L, 334 });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 100L,
                columns: new[] { "HotelId", "Price" },
                values: new object[] { 1L, 2040 });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelId",
                table: "Rooms",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomEntityId",
                table: "Bookings",
                column: "RoomEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomId",
                table: "Bookings",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Entity_HotelId",
                table: "Rooms",
                column: "HotelId",
                principalTable: "Entity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Entity_HotelId",
                table: "Rooms");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_HotelId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Entity");

            migrationBuilder.UpdateData(
                table: "Entity",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "City", "ZipCode" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Entity",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "City", "ZipCode" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Entity",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "City", "ZipCode" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 6L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 7L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 8L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 9L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 10L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 11L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 12L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 13L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 14L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 15L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 16L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 17L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 18L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 19L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 20L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 21L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 22L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 23L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 24L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 25L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 26L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 27L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 28L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 29L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 30L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 31L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 32L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 33L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 34L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 35L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 36L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 37L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 38L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 39L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 40L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 41L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 42L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 43L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 44L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 45L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 46L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 47L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 48L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 49L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 50L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 51L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 52L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 53L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 54L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 55L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 56L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 57L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 58L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 59L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 60L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 61L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 62L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 63L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 64L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 65L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 66L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 67L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 68L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 69L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 70L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 71L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 72L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 73L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 74L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 75L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 76L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 77L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 78L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 79L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 80L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 81L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 82L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 83L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 84L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 85L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 86L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 87L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 88L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 89L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 90L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 91L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 92L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 93L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 94L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 95L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 96L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 97L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 98L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 99L,
                column: "Price",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 100L,
                column: "Price",
                value: 0);
        }
    }
}
