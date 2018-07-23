public static class Examples
{
    public const string marbledMurrelet = @"{
    'CommonName': 'Marbled Murrelet',
    'LatinName': 'Brachyramphus marmoratus',
    'PointsValue': 6,
    'CardText': 'Play: Brachyramphus marmoratus has a FLIGHT of 2\nFact: Unusual for a seabird, Brachyramphus marmoratus nests inland in old-growth forests',
    'Scale': 6,
    'FoodchainNumber': 3,
    'Diet': 'CARNIVORE',
    'Classification': 'Animalia, Chordata, Aves',
    'Terrain': 'FOREST, GRASSLAND, FRESHWATER',
    'Climate': 'COOL, WARM'
    }";
    
    public const string seaOtter = @"{
    'CommonName': 'Sea Otter',
    'LatinName': 'Enhydra lutris',
    'PointsValue': 8,
    'CardText': 'Play: Enhydra lutris has a MOVE of 2\nFact: Enhydra lutris have the densest fur in theanimal kingdom, with nearly one million hairs per square inch',
    'Scale': 7,
    'FoodchainNumber': 3,
    'Diet': 'CARNIVORE',
    'Classification': 'Animalia, Chordata, Mammalia',
    'Terrain': 'OCEAN',
    'Climate': 'COOL, WARM'
    }";

    public const string himilayanBlackberry = @"{
    'CommonName': 'Himalayan Blackberry',
    'LatinName': 'Rubus ameniacus',
    'PointsValue': 1,
    'CardText': 'Play: Rubus armeniacus is an INVASIVE species of Plantae cards of identical scale.\nFact: Rubus armeniacus is native to Armenia and northern Iran, but is now widespread across most of the temperate world.',
    'Scale': 6,
    'FoodchainNumber': 1,
    'Diet': 'AUTOTROPH',
    'Classification': 'Plantae, Angiosperms, Eudicots',
    'Terrain': 'FOREST, GRASSLAND, URBAN',
    'Climate': 'COOL, WARM, HOT'
    }";

    public const string killerWhale = @"{
    'CommonName': 'Killer Whale',
    'LatinName': 'Orcinus orca',
    'PointsValue': 8,
    'CardText': 'Play: Orcinus orca has a MOVE of 2\nFact: Orcinus orca feed on fish, sea lions, seals, walruses and even large whales',
    'Scale': 9,
    'FoodchainNumber': 3,
    'Diet': 'CARNIVORE',
    'Classification': 'Animalia, Chordata, Mammalia',
    'Terrain': 'OCEAN',
    'Climate': 'COLD, COOL, WARM'
    }";

    public const string mycorrhizalFungi = @"{
    'CommonName': 'Mycorrhizal Fungi',
    'LatinName': 'Oidiodendron sp.',
    'PointsValue': 2,
    'CardText': 'Play: Oidiodendron must be played adjacent to a PLANT SPECIES\nFact: Oidiodendron forms a mutualistic relationship with the roots of most plant species',
    'Scale': 3,
    'FoodchainNumber': 1,
    'Diet': 'OTHER',
    'Classification': 'Fungi, Basidiomycota, Agricomycetes',
    'Terrain': 'FOREST, GRASSLAND, URBAN',
    'Climate': 'COLD, COOL, WARM, HOT'
    }";

    public static string allSpecieCards = $@"[{marbledMurrelet}, {seaOtter}, {himilayanBlackberry}, {killerWhale}, {mycorrhizalFungi}]";

}