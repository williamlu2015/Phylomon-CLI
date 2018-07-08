using System.Collections.Generic;
using PhylomonCLI.model.cards;

namespace PhylomonCLI.model {
    
    public class Board {
        private Dictionary<Position, Card> cards;

        public Board() {
            cards = new Dictionary<Position, Card> {
                [new Position(1, 0)] = new HomeCard(),
                [new Position(0, 0)] = new HomeCard()
            };
        }
    }
}
