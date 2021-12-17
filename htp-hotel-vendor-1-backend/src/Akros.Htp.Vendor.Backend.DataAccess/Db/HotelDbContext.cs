using System;
using Akros.Htp.Vendor.Backend.DataAccess.Model.Booking;
using Akros.Htp.Vendor.Backend.DataAccess.Model.Enums;
using Akros.Htp.Vendor.Backend.DataAccess.Model.Hotel;
using Akros.Htp.Vendor.Backend.DataAccess.Model.Image;
using Akros.Htp.Vendor.Backend.DataAccess.Model.Room;
using Microsoft.EntityFrameworkCore;

namespace Akros.Htp.Vendor.Backend.DataAccess.Db
{
    public class HotelDbContext : DbContext
    {
        public DbSet<RoomEntity> Rooms { get; set; }
        
        public DbSet<BookingEntity> Bookings { get; set; }

        public DbSet<HotelEntity> Entity { get; set; }

        public DbSet<ImageEntity> Images { get; set; }

        public HotelDbContext(DbContextOptions<HotelDbContext> dbOptions) : base(dbOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotelEntity>().HasMany<RoomEntity>()
                .WithOne(x => x.Hotel).HasForeignKey(x => x.HotelId);

            modelBuilder.Entity<HotelEntity>().HasData(
                new HotelEntity { Id = 1, Name = "Billiges Hotel", City = "Hamburg", ZipCode = "20251", Country = "Germany", Stars = 1}, 
                new HotelEntity { Id = 2, Name = "Schoenes Hotel", City = "Sursee", ZipCode = "6210", Country = "Switzerland", Stars = 3 },
                new HotelEntity { Id = 3, Name = "Luxus Hotel", City = "Sursee", ZipCode = "6210", Country = "Switzerland", Stars = 5 },
                new HotelEntity { Id = 4, Name = ".Net Hotel Bern", City = "Bern", ZipCode = "8401", Country = "Switzerland", Stars = 3 }
            );

            for (int i = 0; i < 100; i++)
            {
                var random = new Random(123456799 + i);

                modelBuilder.Entity<RoomEntity>().HasData(
                    new RoomEntity
                    {
                        Id = i + 1,
                        Floor = random.Next(1, 10),
                        HotelId = random.Next(1, 4),
                        Name = "RoomNumber" + i,
                        Price = random.Next(60, 2500)
                        //IsDoubleRoom = random.Next() % 2 == 0,
                        //IsOceanView = random.Next() % 2 == 1,
                    });
            }

            modelBuilder.Entity<RoomEntity>().HasData(
                new RoomEntity
                {
                    Id = 101,
                    Floor = 4,
                    HotelId = 4,
                    Name = "Aareblick",
                    Price = 500,
                    Type = RoomType.Studio
                },
                new RoomEntity
                {
                    Id = 102,
                    Floor = 2,
                    HotelId = 4,
                    Name = "Stadtblick",
                    Price = 300,
                    Type = RoomType.Double
                });

            modelBuilder.Entity<ImageEntity>().HasData(
                new ImageEntity{
                    Id = 1,
                    AlternativeText = "Bild 1",
                    Height = 200,
                    Width = 200,
                    HotelId = 1,
                    ImageUrl = "http://htp-vendor-hotel1-ui.azurewebsites.net/static/media/room-2.48c60181.jpeg",
                    ThumbImageUrl = "http://htp-vendor-hotel1-ui.azurewebsites.net/static/media/room-2.48c60181.jpeg",
                    Title = "Bild 1"
                    },
                new ImageEntity{
                    Id = 2,
                    AlternativeText = "Bild 1",
                    Height = 200,
                    Width = 200,
                    HotelId = 2,
                    ImageUrl = "https://htp-vendor-hotel1-ui.azurewebsites.net/static/media/room-6.3697aea3.jpeg",
                    ThumbImageUrl = "https://htp-vendor-hotel1-ui.azurewebsites.net/static/media/room-6.3697aea3.jpeg",
                    Title = "Bild 1"
                },
                new ImageEntity
                {
                    Id = 3,
                    AlternativeText = "Bild 1",
                    Height = 200,
                    Width = 200,
                    HotelId = 3,
                    ImageUrl = "https://htp-vendor-hotel1-ui.azurewebsites.net/static/media/room-11.1605f19e.jpeg",
                    ThumbImageUrl = "https://htp-vendor-hotel1-ui.azurewebsites.net/static/media/room-11.1605f19e.jpeg",
                    Title = "Bild 1"
                },
                new ImageEntity
                {
                    Id = 4,
                    AlternativeText = "Bild 1",
                    Height = 200,
                    Width = 200,
                    HotelId = 4,
                    ImageUrl = "https://htp-vendor-hotel1-ui.azurewebsites.net/static/media/room-11.1605f19e.jpeg",
                    ThumbImageUrl = "https://htp-vendor-hotel1-ui.azurewebsites.net/static/media/room-11.1605f19e.jpeg",
                    Title = "Bild 1"
                },
                new ImageEntity
                {
                    Id = 5,
                    AlternativeText = "Bild 2",
                    Height = 200,
                    Width = 200,
                    HotelId = 4,
                    ImageUrl = "https://htp-vendor-hotel1-ui.azurewebsites.net/static/media/room-6.3697aea3.jpeg",
                    ThumbImageUrl = "https://htp-vendor-hotel1-ui.azurewebsites.net/static/media/room-6.3697aea3.jpeg",
                    Title = "Bild 2"
                },
                new ImageEntity
                {
                    Id = 6,
                    AlternativeText = "Bild 3",
                    Height = 200,
                    Width = 200,
                    HotelId = 4,
                    ImageUrl = "http://htp-vendor-hotel1-ui.azurewebsites.net/static/media/room-2.48c60181.jpeg",
                    ThumbImageUrl = "http://htp-vendor-hotel1-ui.azurewebsites.net/static/media/room-2.48c60181.jpeg",
                    Title = "Bild 3"
                    });            
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
