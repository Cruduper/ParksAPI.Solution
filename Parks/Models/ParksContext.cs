using Microsoft.EntityFrameworkCore;

namespace Parks.Models
{
    public class ParksContext : DbContext
    {
        public ParksContext(DbContextOptions<ParksContext> options)
            : base(options)
        {
        }

        public DbSet<Park> Parks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Park>()
            .HasData(
            new Park { ParkId = 1, Name = "Q’emiln Park", City = "Post Falls", State = "ID", Swimming = true, Hiking = true, Size = 508 },
            new Park { ParkId = 2, Name = "People's Park", City = "Spokane", State = "WA", Swimming = true, Hiking = true, Size = 258 },
            new Park { ParkId = 3, Name = "Oneonta Park", City = "Gresham", State = "OR", Swimming = false, Hiking = true, Size = 106 },
            new Park { ParkId = 4, Name = "Blair Park", City = "Springfield", State = "MA", Swimming = false, Hiking = true, Size = 766 },
            new Park { ParkId = 5, Name = "Agate Beach", City = "Newport", State = "OR", Swimming = true, Hiking = true, Size = 1405 },
            new Park { ParkId = 6, Name = "Ainsworth", City = "Gresham", State = "OR", Swimming = false, Hiking = true, Size = 1405 },
            new Park { ParkId = 7, Name = "Alderwood Wayside", City = "Triangle Lake", State = "OR", Swimming = true, Hiking = true, Size = 895 },
            new Park { ParkId = 8, Name = "Angel's Rest", City = "Hood River", State = "OR", Swimming = true, Hiking = true, Size = 2719 },
            new Park { ParkId = 9, Name = "Banks Vernonia Trail", City = "Portland", State = "OR", Swimming = false, Hiking = true, Size = 2719 },
            new Park { ParkId = 10, Name = "Riverfront Park", City = "Spokane", State = "WA", Swimming = false, Hiking = false, Size = 595 },
            new Park { ParkId = 11, Name = "Battle Mountain", City = "Pendleton", State = "OR", Swimming = false, Hiking = true, Size = 367 },
            new Park { ParkId = 12, Name = "Bald Peak", City = "Portland", State = "OR", Swimming = false, Hiking = true, Size = 246 }
            );
        }
    }
}