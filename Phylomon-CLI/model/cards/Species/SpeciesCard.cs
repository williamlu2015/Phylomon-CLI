using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PhylomonCLI.extensions;

namespace PhylomonCLI.model.cards {
    
    public class SpeciesCard : Card {
        public string CommonName;
        public string LatinName;
        public int PointsValue;
        public string CardText;
        public int Scale;
        public int FoodchainNumber;
        [JsonConverter(typeof(StringEnumConverter))]
        public Diet Diet;
        [JsonConverter(typeof(ClassicationConverter))]
        public Classification Classification;
        [JsonConverter(typeof(HashSetEnumConverter<Terrain>))]
        public HashSet<Terrain> Terrain;
        [JsonConverter(typeof(HashSetEnumConverter<Climate>))]
        public HashSet<Climate> Climate;

        public static SpeciesCard parseWrappedFromString(string jsonString) 
        {
            JsonConverter[] converters = new JsonConverter[]{
                new HashSetEnumConverter<Terrain>(),
                new HashSetEnumConverter<Climate>()
            };
            return JsonConvert.DeserializeObject<SpeciesCard>(jsonString, converters);
        }

        public override List<string> Properties()
        {
            return new List<string>()
            {
                CommonName, 
                LatinName, 
                PointsValue.ToString(), 
               // CardText, 
                Scale.ToString(), 
                FoodchainNumber.ToString(), 
                Diet.ToString(),
                Classification.ToString(),
                Terrain.MakeString<Terrain>(),
                Climate.MakeString<Climate>()
            };
        }
    }

    public enum Diet
    {
        AUTOTROPH,
        HERBIVORE,
        OMNIVORE,
        CARNIVORE
    }

    public enum Terrain
    {
        FOREST,
        DESERT,
        FRESHWATER,
        OCEAN,
        GRASSLAND,
        TUNDRA,
        URBAN
    }

    public enum Climate
    {
        COLD,
        COOL,
        WARM,
        HOT
    }

    public class Classification
    {
        public string Kingdom;
        public string Phylum;
        public string Class;

        public Classification(string kingdom, string phylum, string clazz)
        {
            Kingdom = kingdom;
            Phylum = phylum;
            Class = clazz;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Kingdom);
            sb.Append(", ");
            sb.Append(Phylum);
            sb.Append(", ");
            sb.Append(Class);
            return sb.ToString();
        }
    }
}
