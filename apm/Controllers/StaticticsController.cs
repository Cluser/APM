using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using apm.Models;

namespace apm.Controllers
{
    [Route("api/[controller]")]
    public class StatisticsController : Controller
    {
        private ApmContext db;
        public StatisticsController(ApmContext context)
        {
            this.db = context;
        }

        #region HTTP GET
        /// <summary>Returns daily statistics.</summary>
        /// <remarks>Daily average concentration of suspended dusts</remarks>
        /// <param name="date">Date</param>
        // GET api/statistics/daily
        [HttpGet("daily")]
       
        public Statistic GetDaily(DateTime date, int? startHour, int? endHour)
        {
            Statistic statistic = new Statistic();
            
            // Sum up concentration of suspended dusts
            int sumPm01_0 = db.Points.AsEnumerable().Where(c => c.DateTime.Date == date.Date &&
                                                                c.DateTime.Hour >= startHour && 
                                                                c.DateTime.Hour <= endHour)
                                                                .Sum(row => row.pm01_0);
            int sumPm02_5 = db.Points.AsEnumerable().Where(c => c.DateTime.Date == date.Date &&
                                                                c.DateTime.Hour >= startHour && 
                                                                c.DateTime.Hour <= endHour)
                                                                .Sum(row => row.pm02_5);
            int sumPm10_0 = db.Points.AsEnumerable().Where(c => c.DateTime.Date == date.Date &&
                                                                c.DateTime.Hour >= startHour &&
                                                                c.DateTime.Hour <= endHour)
                                                                .Sum(row => row.pm10_0);
        
            // Count number of measures
            int recordsCount = db.Points.AsEnumerable().Where(c => c.DateTime.Date == date.Date).Count();
        
            // Calculate average concentration of suspended dusts
            statistic.pm01_0 = sumPm01_0 / recordsCount;
            statistic.pm02_5 = sumPm02_5 / recordsCount;
            statistic.pm10_0 = sumPm10_0 / recordsCount;
        
            return statistic;
        }

        /// <summary>Returns weekly statistics.</summary>
        /// <remarks>Weekly average concentration of suspended dusts</remarks>
        /// <param name="date">Date</param>
        // GET api/statistics/weekly
        [HttpGet("weekly")]
        public Statistic GetWeekly(DateTime date)
        {
            Statistic statistic = new Statistic();

            // Get current week of year
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;
            int currentWeekOfYear = cal.GetWeekOfYear(DateTime.Now.Date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);

            // Sum up concentration of suspended dusts
            int sumPm01_0 = db.Points.AsEnumerable().Where(c => c.DateTime.Date == DateTime.Now.Date).Sum(row => row.pm01_0);
            int sumPm02_5 = db.Points.AsEnumerable().Where(c => c.DateTime.Date == DateTime.Now.Date).Sum(row => row.pm02_5);
            int sumPm10_0 = db.Points.AsEnumerable().Where(c => c.DateTime.Date == DateTime.Now.Date).Sum(row => row.pm10_0);
            
            // Count number of measures
            int recordsCount = db.Points.AsEnumerable().Where(c => c.DateTime.Date == DateTime.Now.Date).Count();

            // Calculate average concentration of suspended dusts
            statistic.pm01_0 = sumPm01_0 / recordsCount;
            statistic.pm02_5 = sumPm02_5 / recordsCount;
            statistic.pm10_0 = sumPm10_0 / recordsCount;
            
            return statistic;
        }

        /// <summary>Returns monthly statistics.</summary>
        /// <remarks>Monthly average concentration of suspended dusts</remarks>
        /// <param name="date">Date</param>
        // GET api/statistics/monthly
        [HttpGet("monthly")]
        public Statistic GetMonthly(DateTime date)
        {
            Statistic statistic = new Statistic();

            // Sum up concentration of suspended dusts
            int sumPm01_0 = db.Points.AsEnumerable().Where(c => c.DateTime.Date.Month == date.Month).Sum(row => row.pm01_0);
            int sumPm02_5 = db.Points.AsEnumerable().Where(c => c.DateTime.Date.Month == date.Month).Sum(row => row.pm02_5);
            int sumPm10_0 = db.Points.AsEnumerable().Where(c => c.DateTime.Date.Month == date.Month).Sum(row => row.pm10_0);
           
            // Count number of measures
            int recordsCount = db.Points.AsEnumerable().Where(c => c.DateTime.Date.Month == date.Month).Count();

            // Calculate average concentration of suspended dusts
            statistic.pm01_0 = sumPm01_0 / recordsCount;
            statistic.pm02_5 = sumPm02_5 / recordsCount;
            statistic.pm10_0 = sumPm10_0 / recordsCount;

            return statistic;
        }

        /// <summary>Returns monthly statistics.</summary>
        /// <remarks>Monthly average concentration of suspended dusts</remarks>
        /// <param name="dateStart">Start date</param>
        /// <param name="dateEnd">End date</param>
        // GET api/statistics/monthly
        [HttpGet("dateRange")]
        public Statistic GetDateRange(DateTime dateStart, DateTime dateEnd)
        {
            Statistic statistic = new Statistic();

            // Sum up concentration of suspended dusts
            int sumPm01_0 = db.Points.AsEnumerable().Where(c => c.DateTime.Date.Date >= dateStart.Date && c.DateTime.Date.Date <= dateEnd.Date).Sum(row => row.pm01_0);
            int sumPm02_5 = db.Points.AsEnumerable().Where(c => c.DateTime.Date.Date >= dateStart.Date && c.DateTime.Date.Date <= dateEnd.Date).Sum(row => row.pm02_5);
            int sumPm10_0 = db.Points.AsEnumerable().Where(c => c.DateTime.Date.Date >= dateStart.Date && c.DateTime.Date.Date <= dateEnd.Date).Sum(row => row.pm10_0);

            // Count number of measures
            int recordsCount = db.Points.AsEnumerable().Where(c => c.DateTime.Date.Date >= dateStart.Date && c.DateTime.Date.Date <= dateEnd.Date).Count();

            // Calculate average concentration of suspended dusts
            statistic.pm01_0 = sumPm01_0 / recordsCount;
            statistic.pm02_5 = sumPm02_5 / recordsCount;
            statistic.pm10_0 = sumPm10_0 / recordsCount;

            return statistic;
        }


        #endregion
    }
}

