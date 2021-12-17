using Akros.Htp.Vendor.Backend.DataAccess.Model.Booking;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Akros.Htp.Vendor.Backend.DataAccess.Model.Enums;
using Akros.Htp.Vendor.Backend.DataAccess.Model.Hotel;
using Newtonsoft.Json;

namespace Akros.Htp.Vendor.Backend.DataAccess.Model.Room
{
    [DisplayName("Room")]
    public class RoomEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public RoomType Type { get; set; }

        public int Price { get; set; }

        public Currency Currency { get; set; }

        [JsonIgnore]
        public List<BookingEntity> Bookings { get; set; }

        [JsonIgnore]
        public int Floor { get; set; }

        public HotelEntity Hotel { get; set; }

        public long HotelId { get; set; }
    }
}
