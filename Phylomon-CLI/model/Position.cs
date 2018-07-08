namespace PhylomonCLI.model {
    public class Position {
        public int X { get; }
        public int Y { get; }

        public Position(int x, int y) {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj) {
            if (obj == null || GetType() != obj.GetType()) {
                return false;
            }

            Position position = (Position) obj;
            return X == position.X && Y == position.Y;
        }

        public override int GetHashCode() {
            int hash = 17;
            hash = hash * 23 + X;
            hash = hash * 23 + Y;
            return hash;
        }
    }
}
