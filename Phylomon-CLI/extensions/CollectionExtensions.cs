using System.Collections.Generic;
using PhylomonCLI.model;
using System.Text;
namespace PhylomonCLI.extensions
{
    public static class CollectionExtensions
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

        /// <summary>
        /// Gets the value at a specified index in the list, or defaults to given value
        /// </summary>
        /// <returns>The value or default.</returns>
        /// <param name="values">The receiver of the function.</param>
        /// <param name="index">The index to retrieve at</param>
        /// <param name="defaultValue">The value to return if index not valid</param>
        /// <typeparam name="TValue">The type of the elements in the list</typeparam>
        public static TValue GetValueOrDefault<TValue>
        (this IList<TValue> values, int index, TValue defaultValue)
        {
            if (index < 0 || index >= values.Count) {
                return defaultValue;
            } else {
                return values[index];
            }
        }

        public static string MakeString<T>
        (this HashSet<T> set,
         string seperator = ", ")
        {
            StringBuilder sb = new StringBuilder();
            foreach (T property in set)
            {
                sb.Append(property);
                sb.Append(seperator);
            }
            sb.Length = sb.Length - seperator.Length;
            return sb.ToString();
        }
    }
}
