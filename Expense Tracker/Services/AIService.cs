using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class AIService
{
    private readonly HttpClient _httpClient;
    private const string GeminiApiUrl = "https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash-latest:generateContent";
    private const string ApiKey = "AIzaSyCkEMpBY9PsnPWReMLCG_abs_DB7j-g3Cg"; // Replace with your Gemini API key

    public AIService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetAIResponse(string input)
    {
        // Create the request payload
        var requestBody = new
        {
            contents = new[]
            {
                new
                {
                    parts = new[]
                    {
                        new { text = input }
                    }
                }
            }
        };

        // Convert request body to JSON format
        var requestContent = new StringContent(
            Newtonsoft.Json.JsonConvert.SerializeObject(requestBody),
            Encoding.UTF8, "application/json"
        );

        // Make the POST request to Gemini API with the provided API key
        var response = await _httpClient.PostAsync($"{GeminiApiUrl}?key={ApiKey}", requestContent);

        // Check if the response is successful
        if (!response.IsSuccessStatusCode)
        {
            // Handle the error response (optional)
            return $"Error: {response.StatusCode}";
        }

        // Read and return the response content
        var responseContent = await response.Content.ReadAsStringAsync();
        return responseContent;
    }
}
