using System.Collections.Generic;
using System;
using PhylomonCLI.extensions;
using PhylomonCLI.model.cards;
using Newtonsoft.Json;

namespace PhylomonCLI.model
{

    public interface Inspectable
    {
        /// <summary>
        /// Returns a list of properties, with a maximum of 10 items
        /// - If less than 10, elements should be centred within the list
        /// so that it can be easily displayed
        /// </summary>
        /// <returns>The properties related to the object</returns>
        List<string> Properties();
    }

    public abstract class Card : Inspectable
    {
        
        public static List<string> FormatProperties(List<String> unpaddedProperties)
        {
            List<string> properties = new List<string>(new string[10]);
            int contentStartPosition = Math.Max(0, (int)Math.Floor((decimal)(10 - unpaddedProperties.Count) / 2));

            for (int i = 0; i < 10; i++)
            {
                if (i >= contentStartPosition) {
                    properties[i] = unpaddedProperties.GetValueOrDefault(i - contentStartPosition, " ");
                } else {
                    properties[i] = " ";
                }
            }
            return properties;
        }

        abstract public List<string> Properties();
    }

    class PlaceHolderCard : Card
    {
        private int x;
        private int y;

        public PlaceHolderCard(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public override List<string> Properties()
        {
            return FormatProperties(new List<String> { "Place Holder Card", "X Position: " + x, "Y Position " + y } );
        }
    }
}
