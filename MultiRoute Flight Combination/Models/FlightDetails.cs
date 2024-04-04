namespace MultiRoute_Flight_Combination.Models
{
    public class FlightDetails
    {
        public int Id { get; set; }
        public decimal BasePrice { get; set; }
        public decimal TaxPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public required string Origin { get; set; }
        public required string Destination { get; set; }
    }
}
