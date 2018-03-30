using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace apm.Models
{
    public class Statistic
    {
        [Key]
        public int id { get; set; }
        public int pm01_0 { get; set; }
        public int pm02_5 { get; set; }
        public int pm10_0 { get; set; }
    }
}
