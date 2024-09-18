using Microsoft.AspNetCore.Mvc;

public class GanttChartController : Controller
{
    // GET: /GanttChart/CreateGanttChart
    [HttpGet]
    public IActionResult CreateGanttChart()
    {
        // Initialize with an empty list or fetch existing tasks if any
        var tasks = new List<TaskModel>();
        return View(tasks);
    }

    // POST: /GanttChart/GenerateGanttChart
    [HttpPost]
    public IActionResult GenerateGanttChart(List<TaskModel> tasks)
    {
        // Make sure the tasks are processed correctly
        if (tasks == null || !tasks.Any())
        {
            // Handle case where no tasks are provided
            return View("CreateGanttChart", new List<TaskModel>());
        }

        foreach (var task in tasks)
        {
            Console.WriteLine($"Task: {task.TaskName}, Start: {task.StartDate}, End: {task.EndDate}, Progress: {task.Progress}");
        }
        // Return the view with the submitted tasks
        return View("CreateGanttChart", tasks);
    }
}
