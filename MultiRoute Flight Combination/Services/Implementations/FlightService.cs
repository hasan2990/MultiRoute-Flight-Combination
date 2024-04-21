using MultiRoute_Flight_Combination.Models;
using MultiRoute_Flight_Combination.Services.Interfaces;

namespace MultiRoute_Flight_Combination.Services.Implementations
{
    public class FlightService : IFlightService
    {
        private readonly FlightByRoutes _flightByRoutes;
        public FlightService()
        {
            _flightByRoutes = new FlightByRoutes();
        }

        public async Task<List<FlightResponseModel>> GetAllFlights()
        {

            var flights = new List<FlightResponseModel>();

            Dictionary<string, decimal> My_dict = new Dictionary<string, decimal>();

            var allPossibleCombinations = GetAllCombinations(_flightByRoutes.DirectionWiseFlight);

            foreach (var comb in allPossibleCombinations)
            {
                decimal totalPrice = 0, totalBasePrice = 0, totalTaxPrice = 0;
                List<TaxBreakDown> taxBreakdowns = new List<TaxBreakDown>();
                
                foreach(var i in comb)
                {
                    totalPrice += i.TotalPrice;
                    totalBasePrice += i.BasePrice;
                    totalTaxPrice += i.TaxPrice;
                    //taxBreakdowns.AddRange(i.TaxBreakDowns);
                    foreach(var j in i.TaxBreakDowns)
                    {
                        if(j != null)
                        {
                            if (My_dict.ContainsKey(j.Description))
                            {
                                My_dict[j.Description] += j.Tax;
                            }
                            else
                            {
                                My_dict[j.Description] = j.Tax;

                            }
                        }
                    }
                }
                foreach (var flight in My_dict)
                {
                    taxBreakdowns.Add(new TaxBreakDown { Tax = flight.Value, Description = flight.Key });
                }
                

                var flightDetails = comb.Select(onFlight => new FlightDetails
                {
                    Id = onFlight.Id,
                    BasePrice = onFlight.BasePrice,
                    TaxPrice = onFlight.TaxPrice,
                    TotalPrice = onFlight.TotalPrice,
                    Origin = onFlight.Origin,
                    Destination = onFlight.Destination
                     
                }).ToList();

                var flightResponse = new FlightResponseModel
                {
                    TotalFlightCount = 1+flights.Count,
                    TotalPrice = totalPrice,
                    TotalBasePrice = totalBasePrice,
                    TotalTaxPrice = totalTaxPrice,
                    TaxBreakDowns = taxBreakdowns,

                    Flights = flightDetails,
                };

                flights.Add(flightResponse);
            }
            Console.WriteLine(flights.Count);
            return flights;
        }

        private List<List<FlightModel>> GetAllCombinations(List<List<FlightModel>> directionWiseFlights)
        {
            var totalCombinations = new List<List<FlightModel>>();

            GenerateCombinations(directionWiseFlights, totalCombinations, new List<FlightModel>(), 0);

            return totalCombinations;
        }

        private void GenerateCombinations(List<List<FlightModel>> directionWiseFlights, List<List<FlightModel>> totalCombinations, List<FlightModel> currentCombination, int cur_id)
        {
            var cnt = directionWiseFlights.Count;
            Console.WriteLine("Before Base Case: " + cur_id + " " + cnt);
            if (cur_id == cnt)
            {
                Console.WriteLine("After: " + cur_id + " " + cnt);
                Console.WriteLine(currentCombination);
                totalCombinations.Add(new List<FlightModel>(currentCombination));
                Console.WriteLine(currentCombination);
                return;
            }

            foreach (var flight in directionWiseFlights[cur_id])
            {
                currentCombination.Add(flight);
                GenerateCombinations(directionWiseFlights, totalCombinations, currentCombination, cur_id+1);
                cnt = currentCombination.Count;
                currentCombination.RemoveAt(cnt-1);
            }
        }
    }
}
