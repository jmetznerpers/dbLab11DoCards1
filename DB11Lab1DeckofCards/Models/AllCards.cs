using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DB11Lab1DeckofCards.Models
{
    public class Deck
    {
        public bool success { get; set; }
        public string deck_id { get; set; }
        public bool shuffled { get; set; }
        public int remaining { get; set; }
        public List<myCards> cards { get; set; }
    }
    public class myCards
    {
        public string value { get; set; }
        public string suit { get; set; }
        public string code { get; set; }
    }

    
}
