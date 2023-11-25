using Microsoft.EntityFrameworkCore;
using se4458_midterm.Context;
using se4458_midterm.Models;
using se4458_midterm.Source.Db;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace se4458_midterm.Source.Svc
{
    public class FlightService : IFlightService
    {
        public AirlineDbContext _airlineDbContext;

        public FlightService(AirlineDbContext airlineDbContext)
        {
            _airlineDbContext = airlineDbContext;
        }

        public int CreateFlight(Flight flight)
        {
                CheckFlightForCreate(flight);
                _airlineDbContext.Flights.Add(flight);
                return _airlineDbContext.SaveChanges();
            
        }

        public List<Flight> GetAllFlights()
        {
            FlightAccess access = new(_airlineDbContext);
            return access.GetAllFlights().ToList();
        }

        

        public Flight GetFlightById(int id)
        {
            FlightAccess access = new FlightAccess(_airlineDbContext);
            return access.GetFlight(id);
        }

        

        public Flight GetFlightByNumber(int flightNumber)
        {
            FlightAccess access = new FlightAccess(_airlineDbContext);
            return access.GetFlightByNumber(flightNumber);
        }

        public bool IsFlightNumberExists(int flightNumber)
        {
            bool isExists = _airlineDbContext.Flights.Any(f => f.FlightNumber == flightNumber);

            return isExists;
        }

        public void CheckFlightForCreate(Flight flight)
        {
            if (IsFlightNumberExists(flight.FlightNumber))
            {
                throw new Exception("Flight Number Exists");
            }
            
        }

        public void CheckFlightForUpdate(Flight flight)
        {
            if (flight.FlightNumber == 0)
            {
                throw new Exception("Flight number cannot be empty");
            }
        }

        public void UpdateFlight(Flight flight)
        {
            CheckFlightForUpdate(flight);
            _airlineDbContext.SaveChanges();
            
        }

        public void Remove(Flight flight)
        {
            
            _airlineDbContext.Flights.Remove(flight);
            _airlineDbContext.SaveChanges();
        }

        public List<Flight> QueryFlight(DateTime date, string from, string to, int numOfPeople)
        {
            FlightAccess access = new FlightAccess(_airlineDbContext);
            return access.QueryFlights(date, from, to, numOfPeople);
        }

        public Flight BookFlight(Flight flight)
        {
            FlightAccess access = new FlightAccess(_airlineDbContext);

            
            return access.BookFlight(flight);
        }
    }
}
