using DB11Lab1DeckofCards.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DB11Lab1DeckofCards.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        //NEW DECK

        public async Task<IActionResult> GetAndShuffleNewDeck() 
        {
            string domain = "https://deckofcardsapi.com";
            string path = "/api/deck/new/shuffle/?deck_count=1";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(domain);
            var connection = await client.GetAsync(path);

            Deck newDeck = await connection.Content.ReadAsAsync<Deck>();
            return View(newDeck);
        }

        //DRAW CARDS

        public async Task<IActionResult> DrawCards(string deck_id)
        {
            string domain = "https://deckofcardsapi.com";
            string path = $"/api/deck/{deck_id}/draw/?count=5";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(domain);
            var connection = await client.GetAsync(path);
            Deck myDeck = new Deck();
            myDeck = await connection.Content.ReadAsAsync<Deck>();
            return View(myDeck);
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
