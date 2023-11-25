using Microsoft.EntityFrameworkCore;
using se4458_midterm.Context;
using se4458_midterm.Models;

namespace se4458_midterm.Source.Db
{
    public class FlightAccess
    {
        private readonly AirlineDbContext _airlineDbContext;

        public FlightAccess(AirlineDbContext airlineDbContext)
        {
            _airlineDbContext = airlineDbContext;
        }

        public List<Flight> GetAllFlights()
        {
            return _airlineDbContext.Flights.ToList();
        }

        public Flight GetFlight(int id)
        {
            return _airlineDbContext.Flights.FirstOrDefault(s => s.Id == id);
        }

        public Flight GetFlightByNumber(int number)
        {
            return _airlineDbContext.Flights.FirstOrDefault(s => s.FlightNumber == number);
        }

        public List<Flight> QueryFlights(DateTime date, string from, string to, int numOfPeople)
        {
            List<Flight> queryList = GetAllFlights().FindAll(f => f.DepartureDate.Date == date.Date && f.Departure.ToLower() == from.ToLower() && f.Destination.ToLower() == to.ToLower() && numOfPeople <= f.AvailableSeats);
            return queryList;
        }

        public Flight BookFlight(Flight flight)
        {
           flight.AvailableSeats = Math.Max(0, flight.AvailableSeats - 1);
            _airlineDbContext.SaveChanges();                                                 
            return flight;
        }
    }
}
