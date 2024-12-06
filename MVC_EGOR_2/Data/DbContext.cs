using Microsoft.EntityFrameworkCore;
using MVC_EGOR_2.Models;

namespace MVC_EGOR_2.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Player> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=EGORMVC.accdb;");
        }
    }

}
