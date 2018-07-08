using System.Collections.Generic;
using System.Text;
using PhylomonCLI.model.cards;
using PhylomonCLI.extensions;

namespace PhylomonCLI.model {
    
    public class Board {
        private Dictionary<Position, Card> cards;

        public Board() {
            cards = new Dictionary<Position, Card> {
                [new Position(1, 0)] = new HomeCard(),
                [new Position(0, 0)] = new HomeCard()
            };
        }

        /// <summary>
        /// Stringifies area around the given position, displaying card info
        /// </summary>
        /// <returns>The 3x3 area around a given position as a string
        /// </returns>
        public string InspectPosition(Position position) 
        {
            Card placeholder = new PlaceHolderCard();

            StringBuilder sb = new StringBuilder();
            const int CARD_WIDTH = 30;
            const int DESCRIPTION_WIDTH = CARD_WIDTH - 3;
            string horizontalDivider = "".PadRight(3 * CARD_WIDTH , '*');
            string horizontalEmpty = "*".PadRight(CARD_WIDTH - 2, ' ') + "*" +
                                     "*".PadRight(CARD_WIDTH - 2, ' ') + "*" +
                                     "*".PadRight(CARD_WIDTH - 2, ' ') + "*";
            
            for (int dy = -1; dy < 2; ++dy)
            {
                sb.AppendLine(horizontalDivider);

                int leftIndex = position.X - 1;
                int middleIndex = position.X;
                int rightIndex = position.X + 1;
                int y = position.Y + dy;
                Card left = cards.GetValueOrDefault(leftIndex, y, placeholder);
                Card middle = cards.GetValueOrDefault(middleIndex, y, placeholder);
                Card right = cards.GetValueOrDefault(rightIndex, y, placeholder);

                // iterate across 3 columns
                for (int i = 0; i < 3; i++)
                {
                    sb.AppendLine("* " + left.Props(leftIndex, y)[i].padAndTruncate(' ', DESCRIPTION_WIDTH) + "*" +
                                  "* " + middle.Props(middleIndex, y)[i].padAndTruncate(' ', DESCRIPTION_WIDTH)  + "*" +
                                  "* " + right.Props(rightIndex, y)[i].padAndTruncate(' ', DESCRIPTION_WIDTH)  + "*");
                }
            }
            sb.AppendLine(horizontalDivider);

            return sb.ToString();
        }
    }
}
