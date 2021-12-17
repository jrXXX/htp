using Akros.Htp.Vendor.Backend.DataAccess.Contract.Repository;
using Akros.Htp.Vendor.Backend.DataAccess.DataAdapter;
using Akros.Htp.Vendor.Backend.DataAccess.Db;
using Akros.Htp.Vendor.Backend.DataAccess.Model.Booking;
using Akros.Htp.Vendor.Backend.DataAccess.Model.Room;
using Akros.Htp.Vendor.Backend.Domain.Model.Booking;
using Akros.Htp.Vendor.Backend.Domain.Model.Facility;
using Akros.Htp.Vendor.Backend.Domain.Model.Mutations;
using Akros.Htp.Vendor.Backend.Domain.Model.Queries;
using Akros.Htp.Vendor.Backend.Domain.Model.Room;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akros.Htp.Vendor.Backend.DataAccess.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelDbContext _hotelDbContext;

        public RoomRepository(HotelDbContext hotelDbContext)
        {
            _hotelDbContext = hotelDbContext;
        }

        public async Task<List<RoomEntity>> GetAvailableRoomsAsync()
        {
            return await _hotelDbContext.Rooms.ToListAsync();
        }

        public async Task<List<RoomDto>> GetAvailableRoomsAsync(RoomSearch roomSearch)
        {
            IQueryable<RoomEntity> rooms = _hotelDbContext.Rooms.Include("Bookings");
            if (roomSearch.DateFrom.HasValue && roomSearch.DateTo.HasValue)
            {
                rooms = rooms.Where(x => !x.Bookings.Any(y =>
                    y.BookedFrom <= roomSearch.DateTo.Value && y.BookedTo >= roomSearch.DateFrom.Value));
            }

            if (roomSearch.PriceLowerBound > 0)
            {
                rooms = rooms.Where(x => x.Price >= roomSearch.PriceLowerBound);
            }

            if (roomSearch.PriceUpperBound > 0)
            {
                rooms = rooms.Where(x => x.Price <= roomSearch.PriceUpperBound);
            }

            if (!string.IsNullOrEmpty(roomSearch.City))
            {
                rooms = rooms.Where(x => roomSearch.City.Contains(x.Hotel.City));
            }

            if (!string.IsNullOrEmpty(roomSearch.Country))
            {
                rooms = rooms.Where(x => roomSearch.Country.Contains(x.Hotel.Country));
            }

            return (await rooms.ToListAsync()).Select(RoomDataAdapter.Map).ToList();
        }

        public async Task<BookingEntry> CreateBookingAsync(RoomReservationRequest reservationRequest)
        {
            try
            {
                var booking = await _hotelDbContext.Bookings.AddAsync(new BookingEntity()
                {
                    RoomId = reservationRequest.RoomId,
                    BookedFrom = reservationRequest.DateFrom,
                    BookedTo = reservationRequest.DateTo,
                    Currency = CommonDataModelAdapter.Map(reservationRequest.Currency),
                    Price = reservationRequest.Price
                });
                await _hotelDbContext.SaveChangesAsync();
                return BookingDataAdapter.Map(booking.Entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<List<BookingEntry>> GetBookingsAsync(long roomId, DateTime dateFrom, DateTime dateTo)
        {
            return (await _hotelDbContext.Bookings.Where(x =>
                x.RoomId == roomId && x.BookedFrom <= dateTo && x.BookedTo >= dateFrom).ToListAsync()).Select(BookingDataAdapter.Map).ToList();
        }

        public async Task<List<Hotel>> GetHotelsAsync(IEnumerable<long> hotelIds)
        {
            return (await _hotelDbContext.Entity.Where(x => hotelIds.Contains(x.Id)).ToListAsync())
                .Select(FacilityDataAdapter.Map).ToList();
        }

        public async Task<RoomDto> GetRoomByIdAsync(long roomId)
        {
            var room = await _hotelDbContext.Rooms.FirstOrDefaultAsync(x => x.Id == roomId);

            return room == null
                ? null
                : RoomDataAdapter.Map(room);
        }

        public async Task<Hotel> GetHotelAsync(long hotelId)
        {
            return FacilityDataAdapter.Map(await _hotelDbContext.Entity.FirstOrDefaultAsync(x => x.Id == hotelId));
        }

        public async Task<List<Image>> GetHotelImagesAsync(long hotelId)
        {
            return (await _hotelDbContext.Images.Where(x => x.HotelId == hotelId).ToListAsync())
                .Select(ImageDataAdapter.Map).ToList();
        }
    }
}
