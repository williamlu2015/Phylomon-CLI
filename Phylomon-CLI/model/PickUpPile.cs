using System.Collections.Generic;

namespace PhylomonCLI.model {
    public class PickUpPile {
        private List<Card> cards;

        public PickUpPile(List<Card> cards) {
            this.cards = cards;
        }

        public Card PickUp() {
            Card result = cards[cards.Count - 1];
            cards.RemoveAt(cards.Count - 1);
            return result;
        }

        public bool IsEmpty() {
            return cards.Count == 0;
        }
    }
}
