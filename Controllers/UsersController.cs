using BusinessLayer.Services;
using SharedProject.Models;
using System;
using System.Web.Http;
using System.Web.Http.Description;

namespace DreamVacations_CampBookingSite.Controllers
{

    public class UsersController : ApiController
    {
        private readonly UserServices userServices;
            public UsersController()
        {
            userServices = new UserServices();
        }

        // GET: api/Users
        //public IQueryable<Users> GetUsers()
        //{
        //    return db.Users;
        //}

        // GET: api/Users/5
        [HttpGet]
        [Route("GetUsers/{id}")]
        [ResponseType(typeof(Users))]
        public IHttpActionResult GetUser(Guid id)
        {
            Users users = userServices.GetUser(id);
            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        // PUT: api/Users/5
        //POST:api/Login
        [HttpPost]
        [Route("UserLogin")]
        public IHttpActionResult PostUser(string username,string password)
        {
            if (userServices.ValidateUser(username, password))
                return Ok();
            else
                return Unauthorized(); 
        }

        // POST: api/Users
        [HttpPost]
        [Route("NewUser")]
        public IHttpActionResult PostUsers(Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            userServices.AddUser(users);
            return Ok(users);
            }

        // DELETE: api/Users/5
//       public IHttpActionResult DeleteUsers(Guid id)
//        {
////            Users users = db.Users.Find(id);
//            if (users == null)
//            {
//                return NotFound();
//            }

  //          db.Users.Remove(users);
    //        db.SaveChanges();
        //    return Ok(users);
        //}

     
        //private bool UsersExists(Guid id)
        //{
        ////    return db.Users.Count(e => e.Id == id) > 0;
        //}
    }
}