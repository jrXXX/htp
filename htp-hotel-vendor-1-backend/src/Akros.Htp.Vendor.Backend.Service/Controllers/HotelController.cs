using Akros.Htp.Exchange.Model;
using Akros.Htp.Vendor.Backend.Domain.Model.Room;
using Akros.Htp.Vendor.Backend.Domain.Service;
using Akros.Htp.Vendor.Backend.Service.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Akros.Htp.Vendor.Backend.Service.Controllers
{
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [Route("hotelSearch")]
        [HttpGet]
        public async Task<ActionResult<SearchRequest>> AvailableRooms2()
        {
            return Ok(
                new SearchRequest
                {
                    DestinationCountry = "123"
                });
        }

        [Route("hotelSearch")]
        [HttpPost]
        public async Task<ActionResult<List<SearchResponse>>>AvailableRooms([FromBody] SearchRequest searchRequest)
        {
            try
            {
                List<RoomDto> rooms = await _hotelService.AvailabeRoomsAsync(HtpExchangeModelAdapter.Map(searchRequest));
                List<SearchResponse> searchResults = new List<SearchResponse>();
                foreach (var hotelOffer in rooms.GroupBy(x => x.HotelId))
                {
                    var hotelId = hotelOffer.Key;
                    
                    Domain.Model.Facility.Hotel hotel = await _hotelService.GetHotelAsync(hotelId);
                    hotel.Images = await _hotelService.GetHotelImagesAsync(hotelId);

                    searchResults.Add(searchRequest.Map(hotelOffer.ToList(), hotel));
                }
                
                return Ok(searchResults);
            }
            catch (Exception e)
            {
                //log error
                Console.WriteLine(e);
                return NoContent();
            }
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*
        [Route("Reservation")]
        [HttpPost]
        public async Task<ActionResult> Reservation([FromBody ] DTOs.Reservation reservation)
        {
            try
            {
                bool hotelFound = await hotelService.FindHotel(reservation.HotelId);
                if (!hotelFound)
                {
                    return NotFound(reservation.HotelId);
                }
                bool roomFound = await hotelService.FindRoom(reservation.RoomId);
                if (!roomFound)
                {
                    return NotFound(reservation.RoomId);
                }
                bool alreadyReserved = await hotelService.FindReservation(reservation);
                if (alreadyReserved)
                {
                    return NoContent();
                }

                await hotelService.Reservation(reservation);
                return Created("", reservation);
            }
            catch (Exception e)
            {
                //log error
                Console.WriteLine(e);
                return NoContent();
            }
        }
        */
    }
}
