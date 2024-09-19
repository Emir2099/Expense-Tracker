using Expense_Tracker.Controllers;
using Expense_Tracker.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class BoardController : Controller
{
    public IActionResult Index()
    {
        return View(LocalStorage.Boards);
    }

    [HttpPost]
    public IActionResult Create(string title)
    {
        if (!string.IsNullOrEmpty(title))
        {
            var newBoard = new Board
            {
                Id = LocalStorage.Boards.Count + 1,
                Title = title
            };
            LocalStorage.Boards.Add(newBoard);
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult AddList(int boardId, string listName)
    {
        var board = LocalStorage.Boards.FirstOrDefault(b => b.Id == boardId);
        if (board != null && !string.IsNullOrEmpty(listName))
        {
            var newList = new List
            {
                Id = board.Lists.Count + 1,
                Name = listName
            };
            board.Lists.Add(newList);
        }
        return RedirectToAction("Index");
    }

    public IActionResult AddTask(int boardId, int listId, string taskContent)
    {
        var board = LocalStorage.Boards.FirstOrDefault(b => b.Id == boardId);
        var list = board?.Lists.FirstOrDefault(l => l.Id == listId);
        if (list != null && !string.IsNullOrEmpty(taskContent))
        {
            var newTask = new TodoTask
            {
                Id = list.Tasks.Count + 1,
                Content = taskContent
            };
            list.Tasks.Add(newTask);
        }
        return RedirectToAction("Index");
    }


    [HttpPost]
    public IActionResult AddSubtask(int boardId, int listId, int taskId, string subtaskContent)
    {
        var board = LocalStorage.Boards.FirstOrDefault(b => b.Id == boardId);
        var list = board?.Lists.FirstOrDefault(l => l.Id == listId);
        var task = list?.Tasks.FirstOrDefault(t => t.Id == taskId);
        if (task != null && !string.IsNullOrEmpty(subtaskContent))
        {
            var newSubtask = new Subtask
            {
                Id = task.Subtasks.Count + 1,
                Content = subtaskContent
            };
            task.Subtasks.Add(newSubtask);
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult ToggleTaskCompletion(int boardId, int listId, int taskId)
    {
        var board = LocalStorage.Boards.FirstOrDefault(b => b.Id == boardId);
        var list = board?.Lists.FirstOrDefault(l => l.Id == listId);
        var task = list?.Tasks.FirstOrDefault(t => t.Id == taskId);
        if (task != null)
        {
            task.IsCompleted = !task.IsCompleted;
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult ToggleSubtaskCompletion(int boardId, int listId, int taskId, int subtaskId)
    {
        var board = LocalStorage.Boards.FirstOrDefault(b => b.Id == boardId);
        var list = board?.Lists.FirstOrDefault(l => l.Id == listId);
        var task = list?.Tasks.FirstOrDefault(t => t.Id == taskId);
        var subtask = task?.Subtasks.FirstOrDefault(s => s.Id == subtaskId);
        if (subtask != null)
        {
            subtask.IsCompleted = !subtask.IsCompleted;
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult DeleteTask(int boardId, int listId, int taskId)
    {
        var board = LocalStorage.Boards.FirstOrDefault(b => b.Id == boardId);
        var list = board?.Lists.FirstOrDefault(l => l.Id == listId);
        var task = list?.Tasks.FirstOrDefault(t => t.Id == taskId);
        if (task != null)
        {
            list.Tasks.Remove(task);
        }
        return RedirectToAction("Index");
    }



}
