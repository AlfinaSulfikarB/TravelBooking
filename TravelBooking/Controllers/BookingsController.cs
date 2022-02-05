using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelBooking.Models;
using TravelBooking.Repository;
using TravelBooking.ViewModel;

namespace TravelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        //data member

        private readonly IBooking _booking;

        //constructor injection

        public BookingsController(IBooking booking)
        {
            _booking = booking;
        }

        #region GetAll Booking
        [HttpGet]
        [Route("getallbooking")]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<BookingViewModel>>> GetBookingAll()
        {
            return await _booking.GetAllBookings();
        }

        #endregion



        #region Add a traveler
        [HttpPost]
        [Route("addtraveler")]
        //[Authorize]
        public async Task<IActionResult> AddTraveler([FromBody] Traveler traveler)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var travelerID = await _booking.AddTraveler(traveler);
                    if (travelerID > 0)
                    {
                        return Ok(travelerID);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        #endregion


        #region Update a traveler
        [HttpPut]
        [Route("updatetraveler")]
        [Authorize]
        public async Task<IActionResult> UpdateTraveler([FromBody] Traveler traveler)
        {
            //check validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    try
                    {
                        await _booking.UpdateTraveler(traveler);
                        return Ok();

                    }
                    catch (Exception)
                    {
                        return BadRequest();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }


        #endregion


        #region Delete a Travler

        [HttpDelete("{id}")]
        [Route("deletetraveler")]
        public async Task<IActionResult> DeleteEmployeeByID(int? id)
        {
            int result = 0;
            if (id == null)
            {
                return BadRequest();
            }
            try
            {
                result = await _booking.DeleteTraveler(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region Get By Date
         [HttpGet]
         [Route("getbookingbydate")]

         public async Task<ActionResult<IEnumerable<BookingViewModel>>> GetBookingBydate()
         {
             try
             {
                 var traveler = await _booking.GetBookingsByDate();
                 if (traveler == null)
                 {
                     return NotFound();
                 }
                 return traveler;
             }
             catch (Exception)
             {
                 return BadRequest();
             }
         }
        #endregion

        #region Get By Airport
        [HttpGet]
        [Route("getbookingbyairport")]

        public async Task<ActionResult<IEnumerable<BookingViewModel>>> GetBookingByAirport()
        {
            try
            {
                var traveler = await _booking.GetBookingsByAirport();
                if (traveler == null)
                {
                    return NotFound();
                }
                return traveler;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion



    }
}
