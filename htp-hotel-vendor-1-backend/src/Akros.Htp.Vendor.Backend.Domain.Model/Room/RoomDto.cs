using Akros.Htp.Vendor.Backend.Domain.Model.Common;

namespace Akros.Htp.Vendor.Backend.Domain.Model.Room
{
    public class RoomDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public RoomType Type { get; set; }

        public int Price { get; set; }

        public Currency Currency { get; set; }

        public int Floor { get; set; }

        public long HotelId { get; set; } 
    }
}
