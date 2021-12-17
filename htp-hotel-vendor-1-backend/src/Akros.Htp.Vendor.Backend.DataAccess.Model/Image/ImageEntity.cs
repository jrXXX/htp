using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Akros.Htp.Vendor.Backend.DataAccess.Model.Hotel;

namespace Akros.Htp.Vendor.Backend.DataAccess.Model.Image
{
    public class ImageEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }

        [Required]
        public string Title { get; set; }
        
        public string AlternativeText { get; set; }

        public int Width { get; set; }
        
        public int Height { get; set; }
        
        public byte Image { get; set; }
        
        public byte ThumbImage { get; set; }

        public string ImageUrl { get; set; }

        public string ThumbImageUrl { get; set; }

        public HotelEntity Hotel { get; set; }

        public long HotelId { get; set; }

    }
}
