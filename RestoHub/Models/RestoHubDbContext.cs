using Microsoft.EntityFrameworkCore;

namespace RestoHub.Models
{
    public class RestoHubDbContext : DbContext
    {
        public RestoHubDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
