using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using apm.Models;
using Microsoft.EntityFrameworkCore;

namespace apm.Controllers
{
    [Route("api/[controller]")]
    public class PointsController : Controller
    {
        private ApmContext db;
        public PointsController(ApmContext context)
        {
            this.db = context;
        }

        #region HTTP GET

        // GET api/points
        [HttpGet]
        public async Task<IActionResult> GetPoints(int? id, 
                                                    float? latStart, float? latEnd, float? lngStart, float? lngEnd, 
                                                    DateTime? startDate, DateTime? endDate, 
                                                    int? pm01_0_Min, int? pm01_0_Max, int? pm02_5_Min, int? pm02_5_Max, int? pm10_0_Min, int? pm10_0_Max)
        {
            IQueryable<Point> query = db.Points.OrderByDescending(c => c.id);

            if (id > 0 && id != null)
                query = query.Where(c => c.id == id);

            if (latStart != null)
                query = query.Where(c => c.lat >= latStart);

            if (latEnd != null)
                query = query.Where(c => c.lat <= latEnd);

            if (lngStart != null) 
                query = query.Where(c => c.lng >= lngStart);

            if (lngEnd != null)
                query = query.Where(c => c.lng <= lngEnd);

            if (startDate != null)
                query = query.Where(c => c.DateTime >= startDate);

            if (endDate != null)
                query = query.Where(c => c.DateTime <= endDate);

            if (pm01_0_Min != null)
                query = query.Where(c => c.pm01_0 >= pm01_0_Min);

            if (pm01_0_Max != null)
                query = query.Where(c => c.pm01_0 <= pm01_0_Max);

            if (pm02_5_Min != null)
                query = query.Where(c => c.pm02_5 >= pm02_5_Min);

            if (pm02_5_Max != null)
                query = query.Where(c => c.pm02_5 <= pm02_5_Max);

            if (pm10_0_Min != null)
                query = query.Where(c => c.pm10_0 >= pm10_0_Min);

            if (pm10_0_Max != null)
                query = query.Where(c => c.pm10_0 <= pm10_0_Max);

            try
            {
                var points = await query.AsNoTracking().ToListAsync();

                if (points != null)
                    return new ObjectResult(points);

                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        #endregion

        #region HTTP POST

        // POST api/points/
        [HttpPost]
        public IEnumerable<Point> Post([FromBody]IEnumerable<Point> point)
        {
            db.Points.AddRange(point);
            db.SaveChanges();
            return point;
        }

        #endregion

        #region HTTP DELETE

        // DELETE api/points/5
        [HttpDelete("{id}")]
        public IEnumerable<Point> Delete (int id)
        {
            Point point = new Point() { id = id };
            db.Points.Attach(point);
            db.Points.Remove(point);
            db.SaveChanges();
            return db.Points.ToList();
        }

        #endregion
    }
}
