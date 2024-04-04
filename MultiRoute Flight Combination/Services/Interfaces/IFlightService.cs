using MultiRoute_Flight_Combination.Models;

namespace MultiRoute_Flight_Combination.Services.Interfaces
{
    public interface IFlightService
    {
        Task<List<FlightResponseModel>> GetAllFlights();
    }
}
