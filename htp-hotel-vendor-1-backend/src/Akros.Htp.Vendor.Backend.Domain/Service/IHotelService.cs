using System.Collections.Generic;
using System.Threading.Tasks;
using Akros.Htp.Vendor.Backend.Domain.Model.Facility;
using Akros.Htp.Vendor.Backend.Domain.Model.Mutations;
using Akros.Htp.Vendor.Backend.Domain.Model.Queries;
using Akros.Htp.Vendor.Backend.Domain.Model.Results;
using Akros.Htp.Vendor.Backend.Domain.Model.Room;

namespace Akros.Htp.Vendor.Backend.Domain.Service
{
    public interface IHotelService
    {
        Task<List<RoomDto>> AvailabeRoomsAsync(RoomSearch roomSearch);

        Task<ReservationResult> CreateRoomReservationAsync(RoomReservationRequest reservationRequest);
        
        Task<List<Hotel>> GetHotelsAsync(IEnumerable<long> hotelIds);
        
        Task<Hotel> GetHotelAsync(long hotelId);

        Task<List<Image>> GetHotelImagesAsync(long hotelId);

        Task<RoomDto> GetRoomByIdAsync(long reservationRoomId);
    }
}
