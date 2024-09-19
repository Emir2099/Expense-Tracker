using Microsoft.AspNetCore.Mvc;

namespace Expense_Tracker.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int ListId { get; set; } // Add this property to link cards to lists
    }


}
