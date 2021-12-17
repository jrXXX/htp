using Akros.Htp.Vendor.Backend.DataAccess.Model.Booking;
using Akros.Htp.Vendor.Backend.Domain.Model.Booking;

namespace Akros.Htp.Vendor.Backend.DataAccess.DataAdapter
{
    public class BookingDataAdapter
    {
        public static BookingEntry Map(BookingEntity entity)
        {
            return new BookingEntry()
            {
                Id = entity.Id,
                BookedFrom = entity.BookedFrom,
                BookedTo = entity.BookedTo,
                Currency = CommonDataModelAdapter.Map(entity.Currency),
                Price = entity.Price,
                RoomId = entity.RoomId
            };
        }
    }
}
