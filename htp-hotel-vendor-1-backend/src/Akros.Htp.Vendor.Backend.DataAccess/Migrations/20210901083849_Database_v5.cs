using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Akros.Htp.Vendor.Backend.DataAccess.Migrations
{
    public partial class Database_v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    AlternativeText = table.Column<string>(type: "text", nullable: true),
                    Width = table.Column<int>(type: "integer", nullable: false),
                    Height = table.Column<int>(type: "integer", nullable: false),
                    Image = table.Column<byte>(type: "smallint", nullable: false),
                    ThumbImage = table.Column<byte>(type: "smallint", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    ThumbImageUrl = table.Column<string>(type: "text", nullable: true),
                    HotelId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Entity_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "AlternativeText", "Height", "HotelId", "Image", "ImageUrl", "ThumbImage", "ThumbImageUrl", "Title", "Width" },
                values: new object[,]
                {
                    { 1L, "Bild 1", 200, 1L, (byte)0, "http://htp-vendor-hotel1-ui.azurewebsites.net/static/media/room-2.48c60181.jpeg", (byte)0, "http://htp-vendor-hotel1-ui.azurewebsites.net/static/media/room-2.48c60181.jpeg", "Bild 1", 200 },
                    { 2L, "Bild 1", 200, 2L, (byte)0, "https://htp-vendor-hotel1-ui.azurewebsites.net/static/media/room-6.3697aea3.jpeg", (byte)0, "https://htp-vendor-hotel1-ui.azurewebsites.net/static/media/room-6.3697aea3.jpeg", "Bild 1", 200 },
                    { 3L, "Bild 1", 200, 3L, (byte)0, "https://htp-vendor-hotel1-ui.azurewebsites.net/static/media/room-11.1605f19e.jpeg", (byte)0, "https://htp-vendor-hotel1-ui.azurewebsites.net/static/media/room-11.1605f19e.jpeg", "Bild 1", 200 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_HotelId",
                table: "Images",
                column: "HotelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
