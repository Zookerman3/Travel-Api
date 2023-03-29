using Microsoft.EntityFrameworkCore;

namespace TravelApi.Models
{
    public class TravelApiContext : DbContext
    {
        public DbSet<Destination> Destinations { get; set; }

        public TravelApiContext(DbContextOptions<TravelApiContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Destination>()
              .HasData(
                new Destination { DestinationId = 1, Country = "Mexico", City = "Mexico City"},
                new Destination { DestinationId = 2, Country = "France", City = "Paris"},
                new Destination { DestinationId = 3, Country = "United States", City = "New York"},
                new Destination { DestinationId = 4, Country = "Japan", City = "Tokyo"},
                new Destination { DestinationId = 5, Country = "Australia", City = "Perth"}
              );
        }
    }
}