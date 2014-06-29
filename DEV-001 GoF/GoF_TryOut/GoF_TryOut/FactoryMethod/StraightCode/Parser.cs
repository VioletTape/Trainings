namespace GoF_TryOut.FactoryMethod.StraightCode {
    internal class Parser {
        public bool StringNodeDecode { get; set; }
        public bool RemoveEscapeCharacters { get; set; }


        public Node Parse(string url) {
            var stringParser = new StringParser(this, url);
            return stringParser.FindString();
        }
    }
}