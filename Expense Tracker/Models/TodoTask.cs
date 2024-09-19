using Microsoft.AspNetCore.Mvc;

namespace Expense_Tracker.Models
{
    public class TodoTask
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool IsCompleted { get; set; } = false;
        public List<Subtask> Subtasks { get; set; } = new List<Subtask>();
    }


}
