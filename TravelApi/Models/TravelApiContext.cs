using Microsoft.EntityFrameworkCore;

namespace TravelApi.Models
{
    public class TravelApiContext : DbContext
    {
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public object Destination { get; internal set; }

        public TravelApiContext(DbContextOptions<TravelApiContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Destination>()
                    .HasData(
                new Destination { DestinationId = 1, Country = "Mexico", City = "Mexico City" },
                new Destination { DestinationId = 2, Country = "France", City = "Paris" },
                new Destination { DestinationId = 3, Country = "United States", City = "New York" },
                new Destination { DestinationId = 4, Country = "Japan", City = "Tokyo" },
                new Destination { DestinationId = 5, Country = "Australia", City = "Perth" }
                );


            builder.Entity<Review>()
                    .HasData(
                new Review { ReviewId = 1, DestinationId = 1, Title = "Mexico Review", Description = "Words Would go here", Rating = 1 },
                new Review { ReviewId = 2, DestinationId = 2, Title = "France Review", Description = "Words Would go here", Rating = 2 },
                new Review { ReviewId = 3, DestinationId = 3, Title = "United States Review", Description = "Words Would go here", Rating = 3 },
                new Review { ReviewId = 4, DestinationId = 4, Title = "Japan Review", Description = "Words Would go here", Rating = 4 },
                new Review { ReviewId = 5, DestinationId = 5, Title = "Australia Review", Description = "Words Would go here", Rating = 5 }
        );
        }
    }
}