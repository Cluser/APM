using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace apm.Models
{
    public class ApmContext : DbContext
    {
        public DbSet<Point> Points { get; set; }
        public DbSet<Statistic> Statistics { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Station> Stations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;user id=root;password=root;persistsecurityinfo=True;database=apm;allowuservariables=True;SslMode=none");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
