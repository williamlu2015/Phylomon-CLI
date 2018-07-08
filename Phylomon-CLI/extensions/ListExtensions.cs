using System.Collections.Generic;
using PhylomonCLI.model;
namespace PhylomonCLI.extensions
{
    public static class ListExtensions
    {
        public static TValue GetValueOrDefault<TKey, TValue>
        (this IDictionary<TKey, TValue> dictionary,
         TKey key,
         TValue defaultValue)
        {
            TValue value;
            return dictionary.TryGetValue(key, out value) ? value : defaultValue;
        }

        public static Card GetValueOrDefault
        (this IDictionary<Position, Card> dictionary,
         int x,
         int y,
         Card defaultCard)
        {
            Card value;
            Position position = new Position(x, y);
            return dictionary.TryGetValue(position, out value) ? value : defaultCard;
        }
    }
}
