using Microsoft.AspNetCore.Mvc;
public class AIController : Controller
{
    private readonly AIService _aiService;

    public AIController(AIService aiService)
    {
        _aiService = aiService;
    }

    [HttpPost]
    public async Task<IActionResult> GetAIResponse(string userInput)
    {
        var aiResponse = await _aiService.GetAIResponse(userInput);
        return Json(new { response = aiResponse });
    }
}
