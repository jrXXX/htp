using Akros.Htp.Vendor.Backend.Domain.Model.Mutations;
using Akros.Htp.Vendor.Backend.Domain.Model.Queries;
using Akros.Htp.Vendor.Backend.Domain.Model.Room;
using Akros.Htp.Exchange.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Akros.Htp.Vendor.Backend.Domain.Model.Results;
using RoomType = Akros.Htp.Exchange.Model.TypeEnum;
using Currency = Akros.Htp.Exchange.Model.CurrencyEnum;
using Image = Akros.Htp.Vendor.Backend.Domain.Model.Facility.Image;

namespace Akros.Htp.Vendor.Backend.Service.Infrastructure
{
    public static class HtpExchangeModelAdapter
    {
        public static RoomSearch Map(SearchRequest searchRequest)
        {
            return new()
            {
                DateFrom = searchRequest.DateFrom,
                DateTo = searchRequest.DateTo,
                City = searchRequest.DestinationCity,
                Country = searchRequest.DestinationCountry,
                PostalCode = searchRequest.DestinationPostalCode,
                HotelName = searchRequest.HotelName,
                PriceLowerBound = searchRequest.PriceFrom,
                PriceUpperBound = searchRequest.PriceTo,
                NumberOfGuests = searchRequest.NumberOfGuests,
                Facilities = searchRequest.FacilityList?.Select(x => x.Name).ToList()
            };
        }
        
        public static RoomReservationRequest Map(BookingRequest bookingRequest)
        {
            if (bookingRequest.Room == null)
            {
                throw new ArgumentNullException("Room", "Booking request has to provide a room object.");
            }

            return new RoomReservationRequest()
            {
                DateFrom = bookingRequest.DateFrom,
                DateTo = bookingRequest.DateTo,
                RoomId = bookingRequest.Room.Id,
                Currency = ConvertCurrency(bookingRequest.Room.Currency),
                Price = bookingRequest.Room.Price
            };
        }

        private static Domain.Model.Common.Currency ConvertCurrency(Currency? currency)
        {
            switch (currency)
            {
                case Currency.CHF:
                    return Domain.Model.Common.Currency.CHF;
                case Currency.EUR:
                    return Domain.Model.Common.Currency.EUR;
                default:
                    throw new ArgumentException("currency", $"Unknown currency enum type {currency}");
            }
        }

        public static SearchResponse Map(this SearchRequest searchRequest, List<RoomDto> room, Domain.Model.Facility.Hotel hotel)
        {
            var searchResponse = new SearchResponse()
            {
                Currency = searchRequest.Currency,
                DateFrom = searchRequest.DateFrom,
                DateTo = searchRequest.DateTo,
                Hotel = hotel.Map()
            };

            searchResponse.Hotel.Rooms = room.Select(room => room.Map(searchRequest.DateFrom, searchRequest.DateTo)).ToList();
            return searchResponse;
        }

        private static Currency ConvertCurrency(this Domain.Model.Common.Currency? currency)
        {
            switch (currency)
            {
                case Domain.Model.Common.Currency.CHF:
                    return Currency.CHF;
                case Domain.Model.Common.Currency.EUR:
                    return Currency.EUR;
                default:
                    throw new ArgumentException("currency", $"Unknown currency enum type {currency}");
            }
        }

        private static Room Map(this RoomDto room, DateTime dateFrom, DateTime dateTo)
        {
            return new()
            {
                Id = room.Id,
                Currency = ConvertCurrency(room.Currency),
                Price = room.Price,
                Name = room.Name,
                Type = ConvertRoomType(room.Type),

                DateFrom = dateFrom,
                DateTo = dateTo,
            };
        }

        private static RoomType ConvertRoomType(Domain.Model.Room.RoomType roomType)
        {
            switch (roomType)
            {
                case Domain.Model.Room.RoomType.DOUBLE:
                    return RoomType.DOUBLE;
                case Domain.Model.Room.RoomType.DOUBLE_DOUBLE:
                    return RoomType.DOUBLEDOUBLE;
                case Domain.Model.Room.RoomType.KING:
                    return RoomType.KING;
                case Domain.Model.Room.RoomType.QUAD:
                    return RoomType.QUAD;
                case Domain.Model.Room.RoomType.SINGLE:
                    return RoomType.SINGLE;
                case Domain.Model.Room.RoomType.STUDIO:
                    return RoomType.STUDIO;
                case Domain.Model.Room.RoomType.TRIPLE:
                    return RoomType.TRIPLE;
                case Domain.Model.Room.RoomType.QUEEN:
                    return RoomType.QUEEN;
                case Domain.Model.Room.RoomType.TWIN:
                    return RoomType.TWIN;
                default:
                    throw new ArgumentException("type", $"Unknown RoomType <{roomType}>");
            }
        }

        private static Hotel Map(this Domain.Model.Facility.Hotel hotel)
        {
            return new()
            {
                Id = hotel.Id,
                Country = new Country{ Name = hotel.Name },
                Name = hotel.Name,
                City = hotel.City,
                ZipCode = hotel.ZipCode,
                Stars = hotel.Stars,
                Street = hotel.Street,
                Image = hotel.Images.Select(Map).ToList()
            };
        }

        public static BookingResponse Map(this ReservationResult reservation, RoomDto room)
        {
            return new()
            {
                DateTo = reservation.To,
                DateFrom = reservation.From,
                RoomPaid = false,
                Room = Map(room, reservation.From, reservation.To)
            };
        }

        public static Exchange.Model.Image Map(this Image image)
        {
            return new()
            {
                _Image = image.ImageUrl,
                Alt = image.AlternativeText,
                Height = image.Height,
                Id = image.Id,
                ThumbImage = image.ThumbImageUrl,
                Title = image.Title,
                Width = image.Width
            };
        }
    }
}
