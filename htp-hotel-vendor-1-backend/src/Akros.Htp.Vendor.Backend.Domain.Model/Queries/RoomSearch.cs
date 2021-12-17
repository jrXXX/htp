using System;
using System.Collections.Generic;

namespace Akros.Htp.Vendor.Backend.Domain.Model.Queries
{
    public class RoomSearch
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string HotelName { get; set; }
        public int PriceLowerBound { get; set; }
        public int PriceUpperBound { get; set; }
        public int NumberOfGuests { get; set; }
        public List<string> Facilities { get; set; }
    }
}
