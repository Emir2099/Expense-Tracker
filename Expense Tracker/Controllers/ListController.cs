using Expense_Tracker.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

public class ListController : Controller
{
    private static List<Board> Boards = new List<Board>(); // In-memory storage for boards

    // Display all lists for a specific board
    public IActionResult Index(int boardId)
    {
        var board = Boards.FirstOrDefault(b => b.Id == boardId);
        return View(board?.Lists);
    }

    // Create a new list
    [HttpPost]
    public IActionResult Create(int boardId, string name)
    {
        var board = Boards.FirstOrDefault(b => b.Id == boardId);
        if (board != null)
        {
            var newList = new List
            {
                Id = board.Lists.Count + 1,
                Name = name
            };
            board.Lists.Add(newList);
        }
        return RedirectToAction("Index", new { boardId });
    }

    // Delete a list
    [HttpPost]
    public IActionResult Delete(int boardId, int listId)
    {
        var board = Boards.FirstOrDefault(b => b.Id == boardId);
        if (board != null)
        {
            var list = board.Lists.FirstOrDefault(l => l.Id == listId);
            if (list != null)
            {
                board.Lists.Remove(list);
            }
        }
        return RedirectToAction("Index", new { boardId });
    }


}
