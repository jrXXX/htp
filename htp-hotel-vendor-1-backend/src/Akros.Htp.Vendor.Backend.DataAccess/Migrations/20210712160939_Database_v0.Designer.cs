// <auto-generated />
using System;
using Akros.Htp.Vendor.Backend.DataAccess.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Akros.Htp.Vendor.Backend.DataAccess.Migrations
{
    [DbContext(typeof(HotelDbContext))]
    [Migration("20210712160939_Database_v0")]
    partial class Database_v0
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Akros.Htp.Vendor.Backend.DataAccess.Model.Booking.BookingEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("BookedFrom")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("BookedTo")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("RoomId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("BookingEntity");
                });

            modelBuilder.Entity("Akros.Htp.Vendor.Backend.DataAccess.Model.Hotel.HotelEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Homepage")
                        .HasColumnType("text");

                    b.Property<string>("HouseNumber")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<int>("Start")
                        .HasColumnType("integer");

                    b.Property<string>("Street")
                        .HasColumnType("text");

                    b.Property<string>("ZipCode")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Entity");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Billiges Hotel",
                            Price = 0,
                            Start = 0
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Schoenes Hotel",
                            Price = 0,
                            Start = 0
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Luxus Hotel",
                            Price = 0,
                            Start = 0
                        });
                });

            modelBuilder.Entity("Akros.Htp.Vendor.Backend.DataAccess.Model.Room.RoomEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("DeepLink")
                        .HasColumnType("text");

                    b.Property<int>("Floor")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Floor = 7,
                            Name = "RoomNumber0",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 2L,
                            Floor = 3,
                            Name = "RoomNumber1",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 3L,
                            Floor = 7,
                            Name = "RoomNumber2",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 4L,
                            Floor = 3,
                            Name = "RoomNumber3",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 5L,
                            Floor = 8,
                            Name = "RoomNumber4",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 6L,
                            Floor = 4,
                            Name = "RoomNumber5",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 7L,
                            Floor = 8,
                            Name = "RoomNumber6",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 8L,
                            Floor = 4,
                            Name = "RoomNumber7",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 9L,
                            Floor = 9,
                            Name = "RoomNumber8",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 10L,
                            Floor = 4,
                            Name = "RoomNumber9",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 11L,
                            Floor = 9,
                            Name = "RoomNumber10",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 12L,
                            Floor = 5,
                            Name = "RoomNumber11",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 13L,
                            Floor = 1,
                            Name = "RoomNumber12",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 14L,
                            Floor = 5,
                            Name = "RoomNumber13",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 15L,
                            Floor = 1,
                            Name = "RoomNumber14",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 16L,
                            Floor = 6,
                            Name = "RoomNumber15",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 17L,
                            Floor = 1,
                            Name = "RoomNumber16",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 18L,
                            Floor = 6,
                            Name = "RoomNumber17",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 19L,
                            Floor = 2,
                            Name = "RoomNumber18",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 20L,
                            Floor = 6,
                            Name = "RoomNumber19",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 21L,
                            Floor = 2,
                            Name = "RoomNumber20",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 22L,
                            Floor = 7,
                            Name = "RoomNumber21",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 23L,
                            Floor = 3,
                            Name = "RoomNumber22",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 24L,
                            Floor = 7,
                            Name = "RoomNumber23",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 25L,
                            Floor = 3,
                            Name = "RoomNumber24",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 26L,
                            Floor = 8,
                            Name = "RoomNumber25",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 27L,
                            Floor = 3,
                            Name = "RoomNumber26",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 28L,
                            Floor = 8,
                            Name = "RoomNumber27",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 29L,
                            Floor = 4,
                            Name = "RoomNumber28",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 30L,
                            Floor = 8,
                            Name = "RoomNumber29",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 31L,
                            Floor = 4,
                            Name = "RoomNumber30",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 32L,
                            Floor = 9,
                            Name = "RoomNumber31",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 33L,
                            Floor = 5,
                            Name = "RoomNumber32",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 34L,
                            Floor = 9,
                            Name = "RoomNumber33",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 35L,
                            Floor = 5,
                            Name = "RoomNumber34",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 36L,
                            Floor = 1,
                            Name = "RoomNumber35",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 37L,
                            Floor = 5,
                            Name = "RoomNumber36",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 38L,
                            Floor = 1,
                            Name = "RoomNumber37",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 39L,
                            Floor = 6,
                            Name = "RoomNumber38",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 40L,
                            Floor = 1,
                            Name = "RoomNumber39",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 41L,
                            Floor = 6,
                            Name = "RoomNumber40",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 42L,
                            Floor = 2,
                            Name = "RoomNumber41",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 43L,
                            Floor = 7,
                            Name = "RoomNumber42",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 44L,
                            Floor = 2,
                            Name = "RoomNumber43",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 45L,
                            Floor = 7,
                            Name = "RoomNumber44",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 46L,
                            Floor = 3,
                            Name = "RoomNumber45",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 47L,
                            Floor = 7,
                            Name = "RoomNumber46",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 48L,
                            Floor = 3,
                            Name = "RoomNumber47",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 49L,
                            Floor = 8,
                            Name = "RoomNumber48",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 50L,
                            Floor = 3,
                            Name = "RoomNumber49",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 51L,
                            Floor = 8,
                            Name = "RoomNumber50",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 52L,
                            Floor = 4,
                            Name = "RoomNumber51",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 53L,
                            Floor = 9,
                            Name = "RoomNumber52",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 54L,
                            Floor = 4,
                            Name = "RoomNumber53",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 55L,
                            Floor = 9,
                            Name = "RoomNumber54",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 56L,
                            Floor = 5,
                            Name = "RoomNumber55",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 57L,
                            Floor = 9,
                            Name = "RoomNumber56",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 58L,
                            Floor = 5,
                            Name = "RoomNumber57",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 59L,
                            Floor = 1,
                            Name = "RoomNumber58",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 60L,
                            Floor = 6,
                            Name = "RoomNumber59",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 61L,
                            Floor = 1,
                            Name = "RoomNumber60",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 62L,
                            Floor = 6,
                            Name = "RoomNumber61",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 63L,
                            Floor = 2,
                            Name = "RoomNumber62",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 64L,
                            Floor = 6,
                            Name = "RoomNumber63",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 65L,
                            Floor = 2,
                            Name = "RoomNumber64",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 66L,
                            Floor = 7,
                            Name = "RoomNumber65",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 67L,
                            Floor = 2,
                            Name = "RoomNumber66",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 68L,
                            Floor = 7,
                            Name = "RoomNumber67",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 69L,
                            Floor = 3,
                            Name = "RoomNumber68",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 70L,
                            Floor = 8,
                            Name = "RoomNumber69",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 71L,
                            Floor = 3,
                            Name = "RoomNumber70",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 72L,
                            Floor = 8,
                            Name = "RoomNumber71",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 73L,
                            Floor = 4,
                            Name = "RoomNumber72",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 74L,
                            Floor = 8,
                            Name = "RoomNumber73",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 75L,
                            Floor = 4,
                            Name = "RoomNumber74",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 76L,
                            Floor = 9,
                            Name = "RoomNumber75",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 77L,
                            Floor = 4,
                            Name = "RoomNumber76",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 78L,
                            Floor = 9,
                            Name = "RoomNumber77",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 79L,
                            Floor = 5,
                            Name = "RoomNumber78",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 80L,
                            Floor = 1,
                            Name = "RoomNumber79",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 81L,
                            Floor = 5,
                            Name = "RoomNumber80",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 82L,
                            Floor = 1,
                            Name = "RoomNumber81",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 83L,
                            Floor = 6,
                            Name = "RoomNumber82",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 84L,
                            Floor = 1,
                            Name = "RoomNumber83",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 85L,
                            Floor = 6,
                            Name = "RoomNumber84",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 86L,
                            Floor = 2,
                            Name = "RoomNumber85",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 87L,
                            Floor = 6,
                            Name = "RoomNumber86",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 88L,
                            Floor = 2,
                            Name = "RoomNumber87",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 89L,
                            Floor = 7,
                            Name = "RoomNumber88",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 90L,
                            Floor = 3,
                            Name = "RoomNumber89",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 91L,
                            Floor = 7,
                            Name = "RoomNumber90",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 92L,
                            Floor = 3,
                            Name = "RoomNumber91",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 93L,
                            Floor = 8,
                            Name = "RoomNumber92",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 94L,
                            Floor = 3,
                            Name = "RoomNumber93",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 95L,
                            Floor = 8,
                            Name = "RoomNumber94",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 96L,
                            Floor = 4,
                            Name = "RoomNumber95",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 97L,
                            Floor = 8,
                            Name = "RoomNumber96",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 98L,
                            Floor = 4,
                            Name = "RoomNumber97",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 99L,
                            Floor = 9,
                            Name = "RoomNumber98",
                            Price = 0,
                            Type = 0
                        },
                        new
                        {
                            Id = 100L,
                            Floor = 5,
                            Name = "RoomNumber99",
                            Price = 0,
                            Type = 0
                        });
                });

            modelBuilder.Entity("Akros.Htp.Vendor.Backend.DataAccess.Model.Booking.BookingEntity", b =>
                {
                    b.HasOne("Akros.Htp.Vendor.Backend.DataAccess.Model.Room.RoomEntity", "Room")
                        .WithMany("Bookings")
                        .HasForeignKey("RoomId");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Akros.Htp.Vendor.Backend.DataAccess.Model.Room.RoomEntity", b =>
                {
                    b.Navigation("Bookings");
                });
#pragma warning restore 612, 618
        }
    }
}
