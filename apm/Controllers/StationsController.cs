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
    public class StationsController : Controller
    {
        private ApmContext db;
        public StationsController(ApmContext context)
        {
            this.db = context;
        }

        #region HTTP GET

        // GET api/points
        [HttpGet]
        public async Task<IActionResult> GetStations(int? id, string sensor, bool? isMobile, DateTime? additionDate)
        {
            IQueryable<Station> query = db.Stations.OrderByDescending(c => c.id);

            if (id > 0 && id != null)
                query = query.Where(c => c.id == id);

            if (sensor != null)
                query = query.Where(c => c.sensor == sensor);

            if (isMobile != null)
                query = query.Where(c => c.isMobile == isMobile);

            if (additionDate != null)
                query = query.Where(c => c.additionDate == additionDate);



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

        // POST api/stations/
        [HttpPost]
        public Station PostStation([FromBody]Station station)
        {
            db.Stations.Add(station);
            db.SaveChanges();
            return station;
        }

        #endregion

        #region HTTP DELETE

        // DELETE api/stations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            Station station = new Station() { id = id };
            db.Stations.Attach(station);
            db.Stations.Remove(station);
            db.SaveChanges();
            return new ObjectResult(db.Stations.ToList());
        }

        #endregion

    }
}

