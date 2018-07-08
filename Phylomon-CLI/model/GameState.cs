using System;
using System.Collections.Generic;

namespace PhylomonCLI.model {
    public class GameState {
        private Player player0;
        private Player player1;
        private Board board;
        private Tuple<int, int> currTurn;

        public GameState() {
            List<Card> cards = GetCardPack();
            // cards.shuffle();

            board = new Board();
            currTurn = new Tuple<int, int>(0, 0);
        }

        private static List<Card> GetCardPack() {
            return new List<Card>();   // TODO
        }
    }
}
