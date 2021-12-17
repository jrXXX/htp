using System;
using Akros.Htp.Vendor.Backend.Domain.Model.Common;

namespace Akros.Htp.Vendor.Backend.Domain.Model.Mutations
{
    public class RoomReservationRequest
    {
        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public Currency Currency { get; set; }

        public decimal Price { get; set; }

        public long RoomId { get; set; }
    }
}
