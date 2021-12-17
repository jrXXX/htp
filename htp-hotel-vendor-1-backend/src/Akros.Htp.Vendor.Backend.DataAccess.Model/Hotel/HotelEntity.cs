using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Akros.Htp.Vendor.Backend.DataAccess.Model.Hotel
{
    public class HotelEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
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
    }
}
