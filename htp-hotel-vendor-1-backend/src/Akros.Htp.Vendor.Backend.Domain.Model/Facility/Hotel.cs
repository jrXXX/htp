using System.Collections.Generic;

namespace Akros.Htp.Vendor.Backend.Domain.Model.Facility
{
    public class Hotel
    {
        public long Id { get; set; }

        public int Stars { get; set; }

        public string Name { get; set; }

        public string ZipCode { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string HouseNumber { get; set; }

        public string Homepage { get; set; }

        public int Price { get; set; }

        public string Country { get; set; }

        public List<Image> Images { get; set; }
    }
}
