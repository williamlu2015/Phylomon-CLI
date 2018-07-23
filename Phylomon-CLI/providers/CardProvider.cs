using System.Collections.Generic;
using PhylomonCLI.model.cards;
using Newtonsoft.Json;
namespace PhylomonCLI.providers
{
    /// <summary>
    /// Manages all the cards available
    /// </summary>
    public class CardProvider
    {

        static CardProvider instance;

        public List<SpeciesCard> Cards;

        CardProvider() {
            Cards = JsonConvert.DeserializeObject<List<SpeciesCard>>(Examples.allSpecieCards);
        }

        public static CardProvider GetInstance() {
            if (instance == null) {
                instance = new CardProvider();
            }

            return instance;
        }
    }
}
