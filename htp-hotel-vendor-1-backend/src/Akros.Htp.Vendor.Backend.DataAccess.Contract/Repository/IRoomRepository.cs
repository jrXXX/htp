using Akros.Htp.Vendor.Backend.Domain.Model.Booking;
using Akros.Htp.Vendor.Backend.Domain.Model.Facility;
using Akros.Htp.Vendor.Backend.Domain.Model.Mutations;
using Akros.Htp.Vendor.Backend.Domain.Model.Queries;
using Akros.Htp.Vendor.Backend.Domain.Model.Room;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Akros.Htp.Vendor.Backend.DataAccess.Contract.Repository
{
    public interface IRoomRepository
    {
        Task<List<RoomDto>> GetAvailableRoomsAsync(RoomSearch roomSearch);
        
        Task<BookingEntry> CreateBookingAsync(RoomReservationRequest reservationRequest);

        Task<List<BookingEntry>> GetBookingsAsync(long roomId, DateTime dateFrom, DateTime dateTo);

        Task<List<Hotel>> GetHotelsAsync(IEnumerable<long> hotelIds);
        
        Task<RoomDto> GetRoomByIdAsync(long roomId);

        Task<Hotel> GetHotelAsync(long hotelId);

        Task<List<Image>> GetHotelImagesAsync(long hotelId);
    }
}
