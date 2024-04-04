namespace MultiRoute_Flight_Combination.Models
{
    public class FlightModel
    {
        public FlightModel()
        {
            TaxBreakDowns = new List<TaxBreakDown>();
        }
        public int Id { get; set; }
        public decimal BasePrice { get; set; }
        public decimal TaxPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public required string Origin { get; set; }
        public required string Destination { get; set; }
        public List<TaxBreakDown> TaxBreakDowns { get; set; }
    }
}
