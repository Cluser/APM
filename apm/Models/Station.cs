using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace apm.Models
{
    public class Station
    {
        [Key]
        public int id { get; set; }
        public string sensor { get; set; }
        public bool isMobile { get; set; }
        public DateTime additionDate { get; set; }
    }
}
