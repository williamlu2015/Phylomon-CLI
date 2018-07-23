using System.Collections.Generic;
using PhylomonCLI.extensions;
using PhylomonCLI.model.cards;

namespace PhylomonCLI.model {
    public class Player {
        private List<Card> hand;
        private PickUpPile pickUpPile;
        public string Name { get; }

        public Player(string name, List<Card> initialCards) {
            Name = name;
            hand = new List<Card>();
            pickUpPile = new PickUpPile(initialCards);

            for (int i = 0; i < 5; i++) {
                Card card = pickUpPile.PickUp();
                hand.Add(card);
            }
        }

        public List<string> CardsInHand() {
            List<string> cardText = new List<string>();
            foreach (Card card in hand) {
                cardText.Add(card.Properties().MakeString());
            }
            return cardText;
        }
    }
}
