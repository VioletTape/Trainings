namespace GoF_TryOut.FactoryMethod.Refactored {
    public class Client {
        public void Do() {
            var factory = new NodeFactory();
            factory.StringNodeDecode = true;
            factory.RemoveEscapeCharacters = true;

            var parser = new Parser(factory);
            var result = parser.Parse("lalala");
        }
    }

    internal class NodeFactory {
        public bool StringNodeDecode { get; set; }
        public bool RemoveEscapeCharacters { get; set; }

        public Node Create(string url) {
            if (RemoveEscapeCharacters) {
                url = url.Replace("\t", "");
            }

            if (StringNodeDecode) {
                url = url.ToUpper();
            }

            if (url.StartsWith("c:")) {
                return new CompanyNode();
            }
            if (url.StartsWith("p:")) {
                return new PersonNode();
            }
            if (url.StartsWith("n:")) {
                return new NonProfitFoundationNode();
            }
            return new UndefinedNode();
        }
    }

    internal class Parser {
        private readonly NodeFactory factory;

        public Parser(NodeFactory factory) {
            this.factory = factory;
        }

        public Node Parse(string url) {
            var stringParser = new StringParser(url);
            url = stringParser.FindString();

            return factory.Create(url);
        }
    }

    internal class StringParser {
        private readonly string url;

        public StringParser(string url) {
            this.url = url;
        }

        public string FindString() {
            return url;
        }   
    }

    internal abstract class Node {
        protected Node(NodeType type) {}
    }

    internal class CompanyNode : Node {
        public CompanyNode() : base(NodeType.Company) {}
    }

    internal class PersonNode : Node {
        public PersonNode() : base(NodeType.Person) {}
    }

    internal class NonProfitFoundationNode : Node {
        public NonProfitFoundationNode() : base(NodeType.NonProfitFoundation) {}
    }

    internal class UndefinedNode : Node {
        public UndefinedNode() : base(NodeType.Undefined) {}
    }

    internal enum NodeType {
        Undefined,
        Company,
        Person,
        NonProfitFoundation
    }
}