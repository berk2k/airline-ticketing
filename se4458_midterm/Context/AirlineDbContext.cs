using Microsoft.EntityFrameworkCore;
using se4458_midterm.Models;

namespace se4458_midterm.Context
{
    public class AirlineDbContext : DbContext
    {
        public AirlineDbContext(DbContextOptions<AirlineDbContext> options)
            : base(options)
        {

        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<User> Users { get; set; }

        

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
           

        //    modelBuilder.Entity<Flight>().HasData(
        //        new Flight()
        //        {
        //            Id = 1,
        //            FlightNumber = 4428,
        //            DepartureDate = new DateTime(2023, 6, 1, 7, 40, 0),
        //            Capacity = 100,
        //            AvailableSeats = 50,
        //            Departure = "Boston",
        //            Destination = "New York",
        //            Price = 50,

        //        },
        //        new Flight()
        //        {
        //            Id = 2,
        //            FlightNumber = 5626,
        //            DepartureDate = new DateTime(2023, 7, 1, 9, 00, 0),
        //            Capacity = 200,
        //            AvailableSeats = 4,
        //            Departure = "Berlin",
        //            Destination = "Istanbul",
        //            Price = 60,

        //        },
        //        new Flight()
        //        {
        //            Id = 3,
        //            FlightNumber = 6550,
        //            DepartureDate = new DateTime(2023, 7, 1, 9, 00, 0),
        //            Capacity = 100,
        //            AvailableSeats = 5,
        //            Departure = "Berlin",
        //            Destination = "Istanbul",
        //            Price = 50,

        //        },
        //         new Flight()
        //         {
        //            Id = 4,
        //            FlightNumber = 3328,
        //            DepartureDate = new DateTime(2023, 6, 1, 10, 40, 0),
        //            Capacity = 100,
        //            AvailableSeats = 50,
        //            Departure = "Boston",
        //            Destination = "New York",
        //            Price = 40,

        //        },
        //         new Flight()
        //         {
        //             Id = 5,
        //             FlightNumber = 2233,
        //             DepartureDate = new DateTime(2023, 10, 2, 10, 40, 0),
        //             Capacity = 100,
        //             AvailableSeats = 50,
        //             Departure = "Tokyo",
        //             Destination = "Toronto",
        //             Price = 140,

        //         }
                 
        //    );
        //    modelBuilder.Entity<User>().HasData(
        //        new User()
        //        {
        //            Id = 1,
        //            UserName = "admin",
        //            Password = "admin",
        //            Name = "admin",
        //            Role = "admin",
        //        },
        //        new User()
        //        {
        //            Id = 2,
        //            UserName = "se4458_passenger",
        //            Password = "12345",
        //            Name = "passenger",
        //            Role = "passenger",
        //        }
        //    );

        //}
    }
}
