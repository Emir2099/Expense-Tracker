using Microsoft.AspNetCore.Mvc;

namespace Expense_Tracker.Controllers
{
    public class BudgetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
