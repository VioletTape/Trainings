namespace GoF_TryOut.FactoryMethod.StraightCode {
    internal class StringParser {
        private readonly Parser parser;
        private string url;

        public StringParser(Parser parser, string url) {
            this.url = url;
            this.parser = parser;
        }

        public Node FindString() {
            if (parser.RemoveEscapeCharacters) {
                url = url.Replace("\t", "");
            }

            if (parser.StringNodeDecode) {
                url = url.ToUpper();
            }

            var stringNode = new Node();
            stringNode.Create(url);
            return stringNode;
        }
    }
}