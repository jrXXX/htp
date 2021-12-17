using Akros.Htp.Vendor.Backend.DataAccess.Model.Hotel;
using Akros.Htp.Vendor.Backend.Domain.Model.Facility;

namespace Akros.Htp.Vendor.Backend.DataAccess.DataAdapter
{
    public sealed class FacilityDataAdapter
    {
        public static Hotel Map(HotelEntity entity)
        {
            return new Hotel()
            {
                City = entity.City,
                Id = entity.Id,
                Country = entity.Country,
                Name = entity.Name,
                Stars = entity.Stars,
                ZipCode = entity.ZipCode
            };
        }
    }
}
