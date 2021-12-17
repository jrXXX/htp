using Akros.Htp.Vendor.Backend.Domain.Service;
using Akros.Htp.Vendor.Backend.Service.Infrastructure;
using Akros.Htp.Exchange.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Akros.Htp.Vendor.Backend.Service.Controllers
{
    [ApiController]
    [DisplayName("foo")]
    public class BookingController : ControllerBase
    {
        private readonly IHotelService hotelService;

        public BookingController(IHotelService hotelService)
        {
            this.hotelService = hotelService;
        }

        [Route("roomBooking")]
        [HttpPost]
        public async Task<ActionResult<BookingResponse>> RoomBooking([FromBody]BookingRequest bookingRequest)
        {
            try
            {
                var reservation = await hotelService.CreateRoomReservationAsync(HtpExchangeModelAdapter.Map(bookingRequest));
                
                // Check Reservation Result for not valid. 
                if (reservation.Error != null && !reservation.Success)
                { 
                    return Conflict(reservation.Error);
                }

                var room = await hotelService.GetRoomByIdAsync(reservation.RoomId);

                return Ok(reservation.Map(room));
            }
            catch (Exception e)
            {
                //log error
                Console.WriteLine(e);
                throw;
            }
        }

    }
}