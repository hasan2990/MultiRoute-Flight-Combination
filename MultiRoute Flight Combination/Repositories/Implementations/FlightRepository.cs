using MultiRoute_Flight_Combination.Models;
using MultiRoute_Flight_Combination.Repositories.Interfaces;

namespace MultiRoute_Flight_Combination.Repositories.Implementations
{
    public class FlightRepository : IFlightRepository
    {
        public Task<List<FlightModel>> GetAllFlights()
        {
            throw new NotImplementedException();
        }
    }
}
