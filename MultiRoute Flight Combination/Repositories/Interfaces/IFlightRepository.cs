using MultiRoute_Flight_Combination.Models;

namespace MultiRoute_Flight_Combination.Repositories.Interfaces
{
    public interface IFlightRepository
    {
        Task<List<FlightModel>> GetAllFlights();
    }
}
