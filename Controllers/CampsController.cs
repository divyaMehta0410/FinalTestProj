using BusinessLayer.Services;
using SharedProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
namespace DreamVacations_CampBookingSite.Controllers
{
    [RoutePrefix("Api/Camps")]
    public class CampsController : ApiController
    {

        private readonly CampServices campServices;
        private readonly BookingServices bookingServices;
        public CampsController()
        {
            campServices = new CampServices();
            bookingServices = new BookingServices();
        }
        // GET: api/Camps
        [HttpGet]
        [Route("GetCamps")]
        public IEnumerable<Camps> GetCamps()
        {
            try
            {
                return campServices.GetAllCamps();
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpGet]
        [Route("GetCampsBetween")]
        public IEnumerable<Camps> GetCampsBetween(DateTime checkIn,DateTime checkOut,int Capacity)
        {
            IEnumerable<Camps> result;
            try
            {
                result = campServices.GetAvailableCamps();
                var camps = campServices.GetAllCamps().ToList();
                var bookings = bookingServices.GetBokingsBetween(checkIn, checkOut);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }


        // GET: api/Camps/5
        [HttpGet]
        [Route("GetCamps/{CampId}")]
        public IHttpActionResult GetCamp(Guid CampId)
        {
            var camp = campServices.GetCamp(CampId);
            if (camp == null)
            {
                return NotFound();
            }

            return Ok(camp);
        }

        // PUT: api/Camps/5
        [HttpPut]
        [Route("UpdateCamps")]
        public IHttpActionResult PutCamps(Camps camp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = campServices.UpdateCamp(camp);

            if (!result)
            {
                return NotFound();
            }
            return Ok(camp);

            //return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Camps
        [HttpPost]
        [Route("Addcamp")]
        public IHttpActionResult PostCamps(Camps camps)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            campServices.AddCamp(camps);
            return Ok(camps);

            //     return CreatedAtRoute("DefaultApi", new { id = camps.Id }, camps);
        }

        //        // DELETE: api/Camps/5
        [HttpDelete]
        [Route("DeleteCampsDetails")]
        public IHttpActionResult DeleteCamp(Guid id)
        {
            var result = campServices.DeleteCamp(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok(result);
        }

    }
}