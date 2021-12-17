using Akros.Htp.Vendor.Backend.DataAccess.Contract.Repository;
using Akros.Htp.Vendor.Backend.Domain.Model.Booking;
using Akros.Htp.Vendor.Backend.Domain.Model.Mutations;
using Akros.Htp.Vendor.Backend.Domain.Model.Queries;
using Akros.Htp.Vendor.Backend.Domain.Model.Results;
using Akros.Htp.Vendor.Backend.Domain.Model.Room;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Akros.Htp.Vendor.Backend.Domain.Model.Facility;

namespace Akros.Htp.Vendor.Backend.Domain.Service
{
    public class HotelService : IHotelService
    {
        private readonly IRoomRepository _roomRepository;

        public HotelService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<List<RoomDto>> AvailabeRoomsAsync()
        {
            return await _roomRepository.GetAvailableRoomsAsync(new RoomSearch());
        }

        public async Task<List<RoomDto>> AvailabeRoomsAsync(RoomSearch roomSearch)
        {
            return await _roomRepository.GetAvailableRoomsAsync(roomSearch);
        }

        public async Task<ReservationResult> CreateRoomReservationAsync(RoomReservationRequest reservationRequest)
        {
            if (!await IsReservationValidAsync(reservationRequest))
            {
                return new ReservationResult()
                {
                    Error = new ReservationError()
                    {
                        Message = "Reservation is not valid, room is already booked during the given period.",
                        Type = ReservationErrorType.ALREADY_BOOKED
                    }
                };
            }

            var booking = await _roomRepository.CreateBookingAsync(reservationRequest);
            return new ReservationResult()
            {
                ReservationId = booking.Id,
                Currency = booking.Currency,
                From = booking.BookedFrom,
                Price = booking.Price,
                To = booking.BookedTo,
                RoomId = booking.RoomId
            };
        }

        public async Task<Hotel> GetHotelAsync(long hotelId)
        {
            return await _roomRepository.GetHotelAsync(hotelId);
        }

        public async Task<List<Hotel>> GetHotelsAsync(IEnumerable<long> hotelIds)
        {
            return await _roomRepository.GetHotelsAsync(hotelIds);
        }

        public async Task<RoomDto> GetRoomByIdAsync(long roomId)
        {
            return await _roomRepository.GetRoomByIdAsync(roomId);
        }

        private async Task<bool> IsReservationValidAsync(RoomReservationRequest reservationRequest)
        {
            List<BookingEntry> existingBookings =
                await _roomRepository.GetBookingsAsync(reservationRequest.RoomId, reservationRequest.DateFrom, reservationRequest.DateTo);
            return !existingBookings.Any();
        }

        public async Task<List<Image>> GetHotelImagesAsync(long hotelId)
        {
            return await _roomRepository.GetHotelImagesAsync(hotelId);
        }
    }
}
