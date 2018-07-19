using System.Collections.Generic;
using System;

namespace PhylomonCLI.model.cards {
    
    public class HomeCard : Card {
        public override List<string> Properties()
        {
            return FormatProperties(new List<String> { "Home Card" });
        }
    }
}
