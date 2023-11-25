using se4458_midterm.Models;


namespace se4458_midterm.Source.Svc
{
    public interface IFlightService
    {
        public List<Flight> GetAllFlights();

        public Flight GetFlightById(int id);
        public Flight GetFlightByNumber(int flightNumber);

        public int CreateFlight(Flight flight);

        public void UpdateFlight(Flight flight);

        public List<Flight> QueryFlight(DateTime date, string from, string to, int numOfPeople);

        public Flight BookFlight(Flight flight);

        bool IsFlightNumberExists(int flightNumber);
        void Remove(Flight flight);
    }
}
