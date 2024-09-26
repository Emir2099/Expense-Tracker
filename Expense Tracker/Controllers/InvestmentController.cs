using Expense_Tracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace Expense_Tracker.Controllers
{
    public class InvestmentController : Controller
    {
        private readonly GeminiService _geminiService;

        public InvestmentController(GeminiService geminiService)
        {
            _geminiService = geminiService;
        }

        public async Task<IActionResult> Index()
        {
            var topInvestmentOptions = await _geminiService.GetTopInvestmentOptionsAsync();
            return View(topInvestmentOptions);
        }
    }
}
