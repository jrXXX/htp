using Akros.Htp.Vendor.Backend.DataAccess.Model.Room;
using Akros.Htp.Vendor.Backend.Domain.Model.Room;

namespace Akros.Htp.Vendor.Backend.DataAccess.DataAdapter
{
    public sealed class RoomDataAdapter
    {
        public static RoomDto Map(RoomEntity entity)
        {
            return new RoomDto()
            {
                Currency = CommonDataModelAdapter.Map(entity.Currency),
                Floor = entity.Floor,
                Price = entity.Price,
                HotelId = entity.HotelId,
                Id = entity.Id,
                Name = entity.Name,
                Type = CommonDataModelAdapter.Map(entity.Type)
            };
        }
    }
}
