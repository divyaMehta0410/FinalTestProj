using BusinessLayer.Services;
using SharedProject.Models;
using System;
using System.Web.Http;

namespace DreamVacations_CampBookingSite.Controllers
{
    [RoutePrefix("Api/bookings")]

    public class BookingsController : ApiController
    {
        private readonly BookingServices bookingServices;
        private readonly CampServices campServices;
        public BookingsController()
        {
            bookingServices = new BookingServices();
            campServices = new CampServices();
        }
        // GET: api/Bookings
        [HttpGet]
        [Route("BookingsBetween/{checkInDate}/{checkOutDate}")]
        public IHttpActionResult Get(DateTime checkInDate, DateTime checkOutDate)
        {
           var bookings = bookingServices.GetBokingsBetween(checkInDate, checkOutDate);
            if (bookings == null)
            {
                return NotFound();
            }

            return Ok(bookings);
            //return new string[] { "value1", "value2" };
        }

        // GET: api/Bookings/5
        [HttpGet]
        [Route("GetBookings/{referenceNumber}")]
        public IHttpActionResult Get(Guid referenceNumber)
        {
           var booking =bookingServices.GetBooking(referenceNumber);
            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);

        }

        // POST: api/Bookings
        [HttpPost]
        [Route("Book")]
        public IHttpActionResult Post([FromBody]Bookings booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var campId = Guid.Parse(booking.CampId.ToString());
            campServices.SetBooked(campId, true);
            bookingServices.AddBooking(booking);
            return Ok(booking);

        }

        // PUT: api/Bookings/5

        // DELETE: api/Bookings/5
        [HttpDelete]
        [Route("CancelBooking")]
        public IHttpActionResult Delete(Guid id)
        {
           var result= bookingServices.DeleteBooking(id);
            if (!result)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
