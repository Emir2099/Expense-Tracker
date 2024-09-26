namespace Expense_Tracker.Models
{
    public class InvestmentOption
    {
        public string Name { get; set; } // Add this line for the cryptocurrency name
        public string Bid { get; set; }   // Bid price as a string
        public string Ask { get; set; }   // Ask price as a string
        public string Last { get; set; }  // Last trade price as a string
        public Volume Volume { get; set; } // Volume details (using the Volume class)
        public string Symbol { get; set; } // Adding the Symbol property for reference
    }

    public class Volume
    {
        public string BTC { get; set; }  // Bitcoin volume as a string
        public string USD { get; set; }  // USD volume as a string
        public string ETH { get; set; }  // Ethereum volume as a string (if needed)
        public long Timestamp { get; set; } // Timestamp as a long (Unix epoch time)
    }
}
