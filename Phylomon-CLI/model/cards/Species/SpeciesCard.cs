using System.Collections.Generic;
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
        // public Classification Classification { get; } TODO: Implement parser for Classication type
        [JsonConverter(typeof(HashSetEnumConverter<Terrain>))]
        public HashSet<Terrain> Terrain;
        [JsonConverter(typeof(HashSetEnumConverter<Climate>))]
        public HashSet<Climate> Climate;

        // TODO: Generalize for all Card types, returning a specific type of card depending on type flag
        public static SpeciesCard parseWrappedFromString(string jsonString) 
        {
            JsonConverter[] converters = new JsonConverter[]{
                new HashSetEnumConverter<Terrain>(),
                new HashSetEnumConverter<Climate>()};
            CardWrapper cardWrapper = JsonConvert.DeserializeObject<CardWrapper>(Examples.marbledMurreletWrapped, converters);
            return (SpeciesCard) cardWrapper.Data;
        }

        public override List<string> Properties()
        {
            return new List<string>()
            {
                CommonName, 
                LatinName, 
                PointsValue.ToString(), 
                CardText, 
                Scale.ToString(), 
                FoodchainNumber.ToString(), 
                Diet.ToString(),
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
        public string Kingdom { get; }
        public string Phylum { get; }
        public string Class { get; }

        public Classification(string kingdom, string phylum, string _class)
        {
            Kingdom = kingdom;
            Phylum = phylum;
            Class = _class;
        }
    }
}
