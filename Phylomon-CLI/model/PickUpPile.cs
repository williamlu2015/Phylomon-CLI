using System.Collections.Generic;
using PhylomonCLI.model.cards;

namespace PhylomonCLI.model {
    public class PickUpPile {
        private Queue<Card> cards;

        public PickUpPile(List<Card> cards) {
            this.cards = new Queue<Card>(cards);
        }

        public Card PickUp() {
            return cards.Dequeue();
        }

        public bool IsEmpty() {
            return cards.Count == 0;
        }
    }
}
