using Expense_Tracker.Models;

namespace Expense_Tracker.Controllers
{
    public static class LocalStorage
    {
        public static List<Board> Boards { get; set; } = new List<Board>();
    }


}
