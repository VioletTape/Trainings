namespace GoF_TryOut.FactoryMethod.StraightCode {
    public class Client {
        public void Do() {
            var parser = new Parser();
            parser.StringNodeDecode = true;
            parser.RemoveEscapeCharacters = true;
            var result = parser.Parse("lalala");
        }
    }

    internal class Parser {
        public bool StringNodeDecode { get; set; }
        public bool RemoveEscapeCharacters { get; set; }


        public Node Parse(string url) {
            var stringParser = new StringParser(this, url);
            return stringParser.FindString();
        }
    }

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

    internal class Node {
        public bool IsCompany;
        public bool IsPerson;
        public bool IsNonProfitFoundation;

        public void Create(string url) {
            if (url.StartsWith("c:")) {
                IsCompany = true;
            }
            if (url.StartsWith("p:")) {
                IsPerson = true;
            }
            if (url.StartsWith("n:")) {
                IsNonProfitFoundation = true;
            }
        }
    }
}