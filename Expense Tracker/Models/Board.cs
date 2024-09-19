using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Expense_Tracker.Models
{
    public class Board
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<List> Lists { get; set; } = new List<List>();
    }


}
