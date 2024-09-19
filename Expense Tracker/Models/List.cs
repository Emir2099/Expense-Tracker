using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;

namespace Expense_Tracker.Models
{
    public class List
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
        public List<TodoTask> Tasks { get; set; } = new List<TodoTask>();
    }



}
