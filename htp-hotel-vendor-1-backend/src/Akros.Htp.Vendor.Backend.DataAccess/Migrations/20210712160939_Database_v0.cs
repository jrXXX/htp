using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Akros.Htp.Vendor.Backend.DataAccess.Migrations
{
    public partial class Database_v0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Start = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ZipCode = table.Column<string>(type: "text", nullable: true),
                    Street = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    HouseNumber = table.Column<string>(type: "text", nullable: true),
                    Homepage = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    DeepLink = table.Column<string>(type: "text", nullable: true),
                    Floor = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookingEntity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BookedFrom = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    BookedTo = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    RoomId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingEntity_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Entity",
                columns: new[] { "Id", "City", "Homepage", "HouseNumber", "Name", "Price", "Start", "Street", "ZipCode" },
                values: new object[,]
                {
                    { 1L, null, null, null, "Billiges Hotel", 0, 0, null, null },
                    { 2L, null, null, null, "Schoenes Hotel", 0, 0, null, null },
                    { 3L, null, null, null, "Luxus Hotel", 0, 0, null, null }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "DeepLink", "Floor", "Name", "Price", "Type" },
                values: new object[,]
                {
                    { 72L, null, 8, "RoomNumber71", 0, 0 },
                    { 71L, null, 3, "RoomNumber70", 0, 0 },
                    { 70L, null, 8, "RoomNumber69", 0, 0 },
                    { 69L, null, 3, "RoomNumber68", 0, 0 },
                    { 68L, null, 7, "RoomNumber67", 0, 0 },
                    { 67L, null, 2, "RoomNumber66", 0, 0 },
                    { 66L, null, 7, "RoomNumber65", 0, 0 },
                    { 65L, null, 2, "RoomNumber64", 0, 0 },
                    { 64L, null, 6, "RoomNumber63", 0, 0 },
                    { 63L, null, 2, "RoomNumber62", 0, 0 },
                    { 61L, null, 1, "RoomNumber60", 0, 0 },
                    { 73L, null, 4, "RoomNumber72", 0, 0 },
                    { 60L, null, 6, "RoomNumber59", 0, 0 },
                    { 59L, null, 1, "RoomNumber58", 0, 0 },
                    { 58L, null, 5, "RoomNumber57", 0, 0 },
                    { 57L, null, 9, "RoomNumber56", 0, 0 },
                    { 56L, null, 5, "RoomNumber55", 0, 0 },
                    { 55L, null, 9, "RoomNumber54", 0, 0 },
                    { 54L, null, 4, "RoomNumber53", 0, 0 },
                    { 53L, null, 9, "RoomNumber52", 0, 0 },
                    { 52L, null, 4, "RoomNumber51", 0, 0 },
                    { 62L, null, 6, "RoomNumber61", 0, 0 },
                    { 74L, null, 8, "RoomNumber73", 0, 0 },
                    { 76L, null, 9, "RoomNumber75", 0, 0 },
                    { 51L, null, 8, "RoomNumber50", 0, 0 },
                    { 98L, null, 4, "RoomNumber97", 0, 0 },
                    { 97L, null, 8, "RoomNumber96", 0, 0 },
                    { 96L, null, 4, "RoomNumber95", 0, 0 },
                    { 95L, null, 8, "RoomNumber94", 0, 0 },
                    { 94L, null, 3, "RoomNumber93", 0, 0 },
                    { 93L, null, 8, "RoomNumber92", 0, 0 },
                    { 92L, null, 3, "RoomNumber91", 0, 0 },
                    { 91L, null, 7, "RoomNumber90", 0, 0 },
                    { 90L, null, 3, "RoomNumber89", 0, 0 },
                    { 89L, null, 7, "RoomNumber88", 0, 0 },
                    { 75L, null, 4, "RoomNumber74", 0, 0 },
                    { 88L, null, 2, "RoomNumber87", 0, 0 },
                    { 86L, null, 2, "RoomNumber85", 0, 0 },
                    { 85L, null, 6, "RoomNumber84", 0, 0 },
                    { 84L, null, 1, "RoomNumber83", 0, 0 },
                    { 83L, null, 6, "RoomNumber82", 0, 0 },
                    { 82L, null, 1, "RoomNumber81", 0, 0 },
                    { 81L, null, 5, "RoomNumber80", 0, 0 },
                    { 80L, null, 1, "RoomNumber79", 0, 0 },
                    { 79L, null, 5, "RoomNumber78", 0, 0 },
                    { 78L, null, 9, "RoomNumber77", 0, 0 },
                    { 77L, null, 4, "RoomNumber76", 0, 0 },
                    { 87L, null, 6, "RoomNumber86", 0, 0 },
                    { 50L, null, 3, "RoomNumber49", 0, 0 },
                    { 49L, null, 8, "RoomNumber48", 0, 0 },
                    { 48L, null, 3, "RoomNumber47", 0, 0 },
                    { 21L, null, 2, "RoomNumber20", 0, 0 },
                    { 20L, null, 6, "RoomNumber19", 0, 0 },
                    { 19L, null, 2, "RoomNumber18", 0, 0 },
                    { 18L, null, 6, "RoomNumber17", 0, 0 },
                    { 17L, null, 1, "RoomNumber16", 0, 0 },
                    { 16L, null, 6, "RoomNumber15", 0, 0 },
                    { 15L, null, 1, "RoomNumber14", 0, 0 },
                    { 14L, null, 5, "RoomNumber13", 0, 0 },
                    { 13L, null, 1, "RoomNumber12", 0, 0 },
                    { 12L, null, 5, "RoomNumber11", 0, 0 },
                    { 11L, null, 9, "RoomNumber10", 0, 0 },
                    { 10L, null, 4, "RoomNumber9", 0, 0 },
                    { 9L, null, 9, "RoomNumber8", 0, 0 },
                    { 8L, null, 4, "RoomNumber7", 0, 0 },
                    { 7L, null, 8, "RoomNumber6", 0, 0 },
                    { 6L, null, 4, "RoomNumber5", 0, 0 },
                    { 5L, null, 8, "RoomNumber4", 0, 0 },
                    { 4L, null, 3, "RoomNumber3", 0, 0 },
                    { 3L, null, 7, "RoomNumber2", 0, 0 },
                    { 2L, null, 3, "RoomNumber1", 0, 0 },
                    { 1L, null, 7, "RoomNumber0", 0, 0 },
                    { 22L, null, 7, "RoomNumber21", 0, 0 },
                    { 23L, null, 3, "RoomNumber22", 0, 0 },
                    { 24L, null, 7, "RoomNumber23", 0, 0 },
                    { 25L, null, 3, "RoomNumber24", 0, 0 },
                    { 47L, null, 7, "RoomNumber46", 0, 0 },
                    { 46L, null, 3, "RoomNumber45", 0, 0 },
                    { 45L, null, 7, "RoomNumber44", 0, 0 },
                    { 44L, null, 2, "RoomNumber43", 0, 0 },
                    { 43L, null, 7, "RoomNumber42", 0, 0 },
                    { 42L, null, 2, "RoomNumber41", 0, 0 },
                    { 41L, null, 6, "RoomNumber40", 0, 0 },
                    { 40L, null, 1, "RoomNumber39", 0, 0 },
                    { 39L, null, 6, "RoomNumber38", 0, 0 },
                    { 38L, null, 1, "RoomNumber37", 0, 0 },
                    { 99L, null, 9, "RoomNumber98", 0, 0 },
                    { 37L, null, 5, "RoomNumber36", 0, 0 },
                    { 35L, null, 5, "RoomNumber34", 0, 0 },
                    { 34L, null, 9, "RoomNumber33", 0, 0 },
                    { 33L, null, 5, "RoomNumber32", 0, 0 },
                    { 32L, null, 9, "RoomNumber31", 0, 0 },
                    { 31L, null, 4, "RoomNumber30", 0, 0 },
                    { 30L, null, 8, "RoomNumber29", 0, 0 },
                    { 29L, null, 4, "RoomNumber28", 0, 0 },
                    { 28L, null, 8, "RoomNumber27", 0, 0 },
                    { 27L, null, 3, "RoomNumber26", 0, 0 },
                    { 26L, null, 8, "RoomNumber25", 0, 0 },
                    { 36L, null, 1, "RoomNumber35", 0, 0 },
                    { 100L, null, 5, "RoomNumber99", 0, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingEntity_RoomId",
                table: "BookingEntity",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingEntity");

            migrationBuilder.DropTable(
                name: "Entity");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
