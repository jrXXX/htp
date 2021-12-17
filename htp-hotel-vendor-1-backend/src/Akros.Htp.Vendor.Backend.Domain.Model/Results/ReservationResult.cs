using System;
using Akros.Htp.Vendor.Backend.Domain.Model.Booking;
using Akros.Htp.Vendor.Backend.Domain.Model.Common;

namespace Akros.Htp.Vendor.Backend.Domain.Model.Results
{
    public class ReservationResult
    {
        public long? ReservationId
        {
            get;
            set;
        }

        public decimal Price { get; set; }

        public DateTime From { get; set; }
        
        public DateTime To { get; set; }

        public Currency Currency { get; set; }

        public bool Success => ReservationId.HasValue;

        public ReservationError Error { get; set; }
        
        public long RoomId { get; set; }
    }
}
