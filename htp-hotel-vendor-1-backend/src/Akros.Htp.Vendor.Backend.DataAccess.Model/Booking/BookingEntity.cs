using Akros.Htp.Vendor.Backend.DataAccess.Model.Room;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Akros.Htp.Vendor.Backend.DataAccess.Model.Enums;

namespace Akros.Htp.Vendor.Backend.DataAccess.Model.Booking
{
    public class BookingEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }
        
        public DateTime BookedFrom { get; set; }

        public DateTime BookedTo { get; set; }

        public long RoomId { get; set; }

        public decimal Price { get; set; }

        public Currency Currency { get; set; }

        [ForeignKey("RoomId")]
        public RoomEntity Room { get; set; }
	}
}
