namespace PhylomonCLI.model {
    public class Classification {
        public string Kingdom { get; }
        public string Phylum { get; }
        public string Class { get; }

        public Classification(string kingdom, string phylum, string _class) {
            Kingdom = kingdom;
            Phylum = phylum;
            Class = _class;
        }
    }
}
