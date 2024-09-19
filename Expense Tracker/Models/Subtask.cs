using Microsoft.AspNetCore.Mvc;

namespace Expense_Tracker.Models
{
    public class Subtask
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool IsCompleted { get; set; } = false;
    }

}
