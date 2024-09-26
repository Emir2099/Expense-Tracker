using Expense_Tracker.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Expense_Tracker.Services
{
    public class GeminiService
    {
        private readonly HttpClient _httpClient;

        public GeminiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Method to fetch data for the top 5 cryptocurrencies
        public async Task<List<InvestmentOption>> GetTopInvestmentOptionsAsync()
        {
            try
            {
                // Step 1: Fetch all available symbols from Gemini API
                var symbolsResponse = await _httpClient.GetStringAsync("https://api.gemini.com/v1/symbols");
                var symbols = JsonConvert.DeserializeObject<List<string>>(symbolsResponse);

                var investmentOptions = new List<InvestmentOption>();

                // Check if there are any symbols available
                if (symbols == null || !symbols.Any())
                {
                    Console.WriteLine("No symbols available from the Gemini API.");
                    return investmentOptions; // Return an empty list
                }

                // Fetch data for the top 5 symbols
                foreach (var symbol in symbols.Take(5))
                {
                    try
                    {
                        // Fetch ticker data for the current symbol
                        var response = await _httpClient.GetStringAsync($"https://api.gemini.com/v1/pubticker/{symbol}");
                        var investmentOption = JsonConvert.DeserializeObject<InvestmentOption>(response);

                        if (investmentOption != null && investmentOption.Volume != null)
                        {
                            // Set the symbol and convert to uppercase for better readability
                            investmentOption.Name = symbol.ToUpper(); // Assign the symbol as the Name property

                            // Optionally, you can convert the bid, ask, and last prices to strings
                            investmentOption.Bid = investmentOption.Bid ?? "N/A";
                            investmentOption.Ask = investmentOption.Ask ?? "N/A";
                            investmentOption.Last = investmentOption.Last ?? "N/A";

                            investmentOptions.Add(investmentOption);
                        }
                    }
                    catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        // If the specific symbol endpoint is not found, log and continue
                        Console.WriteLine($"Symbol {symbol} not found: {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        // Log other exceptions to continue fetching remaining symbols
                        Console.WriteLine($"Error fetching data for symbol {symbol}: {ex.Message}");
                    }
                }

                return investmentOptions;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching investment options: {ex.Message}");
                throw;
            }
        }
    }
}
