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
                Inspectable left = cards.GetValueOrDefault(leftIndex, y, new PlaceHolderCard(leftIndex, y));
                Inspectable middle = cards.GetValueOrDefault(middleIndex, y, new PlaceHolderCard(middleIndex,y));
                Inspectable right = cards.GetValueOrDefault(rightIndex, y, new PlaceHolderCard(rightIndex,y));

                // iterate across 3 rows
                for (int i = 0; i < 10; i++)
                {
                    sb.AppendLine("* " + left.Properties()[i].truncateAndCenter(' ', DESCRIPTION_WIDTH) + "*" +
                                  "* " + middle.Properties()[i].truncateAndCenter(' ', DESCRIPTION_WIDTH)  + "*" +
                                  "* " + right.Properties()[i].truncateAndCenter(' ', DESCRIPTION_WIDTH)  + "*");
                }
            }
            sb.AppendLine(horizontalDivider);

            return sb.ToString();
        }
    }
}
