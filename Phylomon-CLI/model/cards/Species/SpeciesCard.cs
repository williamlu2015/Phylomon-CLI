using System.Collections.Generic;

namespace PhylomonCLI.model.cards {
    
    public abstract class SpeciesCard : Card {
		public string CommonName { get; }
		public string LatinName { get; }
		public int PointsValue { get; }
		public string CardText { get; }
		public int Scale { get; }
		public int FoodchainNumber { get; }
		public Diet Diet { get; }
		public Classification Classification { get; }
		public HashSet<Terrain> Terrain { get; }
		public HashSet<Climate> Climate { get; }
    }
}
