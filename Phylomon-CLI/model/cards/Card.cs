using System.Collections.Generic;
using System;


namespace PhylomonCLI.model {
    
    public abstract class Card {
        public List<string> Props(int x, int y) {
            return new List<string> {
                "Card Name: Test Card",
                "Card Type: Placeholder",
                "Position: X: " + x + " Y: " + y
            };
        }
    }

    class PlaceHolderCard: Card 
    {
        
    }
}
