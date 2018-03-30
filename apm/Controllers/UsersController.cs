using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using apm.Models;
using Microsoft.EntityFrameworkCore;

namespace apm.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        #region DEPENDENCY INJECTION

        private ApmContext db;
        public UsersController(ApmContext context)
        {
            this.db = context;
        }

        #endregion

        #region HTTP GET
        /// <summary>Returns users registred in system.</summary>
        [HttpGet]
        public async Task<IActionResult> GetUsers(int? id, string name, string surname, string phoneNumber)
        {
            IQueryable<User> query = db.Users.OrderByDescending(c => c.id);

            if (id > 0 && id != null)
                query = query.Where(c => c.id == id);

            if (name != null)
                query = query.Where(c => c.name == name);

            if (surname != null)
                query = query.Where(c => c.surname == surname);

            if (phoneNumber != null)
                query = query.Where(c => c.phoneNumber == phoneNumber);



            try
            {
                var stations = await query.AsNoTracking().ToListAsync();

                if (stations != null)
                    return new ObjectResult(stations);

                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        #endregion

        #region HTTP POST
        /// <summary>Adds new user to system.</summary>
        // POST api/users/
        [HttpPost]
        public User Post([FromBody]User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return user;
        }

        #endregion

        #region HTTP DELETE
        /// <summary>Deletes existing user from system.</summary>
        /// <param name="id">ID of user</param>
        /// <response code="400" type="ErrorResponse">Bad request</response>
        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            User user = new User() { id = id };
            db.Users.Attach(user);
            db.Users.Remove(user);
            db.SaveChanges();
            return new ObjectResult(db.Users.ToList());
        }

        #endregion


    }
}

