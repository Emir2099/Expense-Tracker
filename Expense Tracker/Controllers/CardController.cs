using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Expense_Tracker.Models;

namespace Expense_Tracker.Controllers
{
    public class CardController : Controller
    {
        // Simulating an in-memory storage for cards
        private static List<Card> _cards = new List<Card>();

        // Display cards for a specific list
        public IActionResult Index(int listId)
        {
            // Retrieve cards based on the listId
            var cards = _cards.Where(c => c.ListId == listId).ToList();
            return View(cards);  // Pass the retrieved cards to the view
        }

        // Create a new card
        [HttpPost]
        public IActionResult Create(Card card)
        {
            if (ModelState.IsValid)
            {
                // Add the card to the in-memory list
                _cards.Add(card);
                return RedirectToAction("Index", new { listId = card.ListId });
            }
            return View(card);
        }

        // Delete a card
        [HttpPost]
        public IActionResult Delete(int id)
        {
            // Find the card by ID
            var card = _cards.FirstOrDefault(c => c.Id == id);
            if (card != null)
            {
                // Remove the card from the in-memory list
                _cards.Remove(card);
            }
            return RedirectToAction("Index", new { listId = card.ListId });
        }
    }
}
