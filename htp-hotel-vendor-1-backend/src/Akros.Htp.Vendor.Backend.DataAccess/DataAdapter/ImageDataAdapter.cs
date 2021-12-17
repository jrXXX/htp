using Akros.Htp.Vendor.Backend.DataAccess.Model.Image;
using Akros.Htp.Vendor.Backend.Domain.Model.Facility;

namespace Akros.Htp.Vendor.Backend.DataAccess.DataAdapter
{
    public sealed class ImageDataAdapter
    {
        public static Image Map(ImageEntity entity)
        {
            return new Image()
            {
                Id = entity.Id,

                AlternativeText = entity.AlternativeText,
                Height = entity.Height,
                HotelId = entity.HotelId,
                ImageData = entity.Image,
                ImageUrl = entity.ImageUrl,
                ThumbImageUrl = entity.ThumbImageUrl,
                ThumbImageData = entity.ThumbImage,
                Title = entity.Title,
                Width = entity.Width,
            };
        }
    }
}