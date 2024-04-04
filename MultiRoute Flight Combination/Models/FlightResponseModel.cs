namespace MultiRoute_Flight_Combination.Models
{
    public class FlightResponseModel
    {
        public decimal TotalPrice { get; set; }
        public decimal TotalBasePrice { get; set; }
        public decimal TotalTaxPrice { get; set; }
        public required  List<FlightDetails> Flights { get; set; }
        public required List<TaxBreakDown> TaxBreakDowns { get; set; }

    }
}
