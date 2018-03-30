using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace apm.Models
{
    public class Point
    {
        [Key]
        public int id { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }
        public int pm01_0 { get; set; }
        public int pm02_5 { get; set; }
        public int pm10_0 { get; set; }
        public DateTime DateTime { get; set; }
    }
}
