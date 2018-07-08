using System.Collections.Generic;

namespace PhylomonCLI.model {
    public class Player {
        private List<Card> hand;
        private PickUpPile pickUpPile;

        public Player(List<Card> initialCards) {
            hand = new List<Card>();
            pickUpPile = new PickUpPile(initialCards);

            for (int i = 0; i < 5; i++) {
                Card card = pickUpPile.PickUp();
                hand.Add(card);
            }
        }
    }
}
