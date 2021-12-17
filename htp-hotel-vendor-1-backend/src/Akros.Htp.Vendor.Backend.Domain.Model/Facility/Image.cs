namespace Akros.Htp.Vendor.Backend.Domain.Model.Facility
{
    public class Image
    {
        public long Id { get; set; }

        public string Title { get; set; }
        
        public string AlternativeText { get; set; }

        public int Width { get; set; }
        
        public int Height { get; set; }
        
        public byte ImageData { get; set; }
        
        public byte ThumbImageData { get; set; }

        public string ImageUrl { get; set; }

        public string ThumbImageUrl { get; set; }

        public long HotelId { get; set; }
    }
}
