using Microsoft.AspNetCore.Mvc;

namespace Expense_Tracker.Models
{
    public class Budget : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
