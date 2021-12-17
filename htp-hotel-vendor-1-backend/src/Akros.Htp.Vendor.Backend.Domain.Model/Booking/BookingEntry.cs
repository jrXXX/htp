using Akros.Htp.Vendor.Backend.Domain.Model.Common;
using System;

namespace Akros.Htp.Vendor.Backend.Domain.Model.Booking
{
    public class BookingEntry
    {
        public long Id { get; set; }

        public DateTime BookedFrom { get; set; }

        public DateTime BookedTo { get; set; }

        public long RoomId { get; set; }

        public decimal Price { get; set; }

        public Currency Currency { get; set; }
    }
}
