using System;
using System.Collections.Generic;
using PhylomonCLI.model.cards;
using PhylomonCLI.model;
using Newtonsoft.Json;

namespace PhylomonCLI.providers
{
    /// <summary>
    /// Manages all the cards available
    /// </summary>
    public class CardProvider
    {

        static CardProvider instance;

        private static IDictionary<string, Card> allCards = new Dictionary<string, Card>();

        CardProvider()
        {
            List<SpeciesCard> rawCards = JsonConvert.DeserializeObject<List<SpeciesCard>>(Examples.allSpecieCards);
            foreach (SpeciesCard card in rawCards)
            {
                allCards.Add(card.LatinName, card);
            }
        }

        public static CardProvider GetInstance()
        {
            if (instance == null)
            {
                instance = new CardProvider();
            }

            return instance;
        }

        public static List<Card> GetDeck(List<String> cardNamesForDeck)
        {
            List<Card> cardsForPile = new List<Card>();
            foreach (string key in cardNamesForDeck)
            {
                if (allCards.TryGetValue(key, out var card))
                {
                    cardsForPile.Add(card);
                }
                else
                {
                    Console.WriteLine($"The card {key} does not exist, fix your deck and try again");
                    return cardsForPile;
                }
            }
            return cardsForPile;
        }

        public static List<Card> GetDefaultCards() {
            List<string> defaultCards = JsonConvert.DeserializeObject<List<string>>(Examples.userDeck);
            return GetDeck(defaultCards);
        }
    }
}
