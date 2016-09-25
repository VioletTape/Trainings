using System;
using System.Collections.Generic;
using System.Linq;

namespace GoF_TryOut.FactoryMethod.Refactored {
    public class Client1 {
        public void Do() {
            var factory = new NodeFactoryManager();
            factory.StringNodeDecode = true;
            factory.RemoveEscapeCharacters = true;

            var parser = new Parser(factory);
            var result = parser.Parse("lalala");
        }
    }

    /// <summary>
    /// В данном случае реализация ближе к современности
    /// т.к. за создание объектов отвечает отдельный класс 
    /// </summary>
    internal class NodeFactoryManager : INodeFactory
    {
        private readonly NodeFactoryX nodeFactoryX = new NodeFactoryX();
        private readonly NodeFactoryY nodeFactoryY = new NodeFactoryY();

        public bool StringNodeDecode { get; set; }
        public bool RemoveEscapeCharacters { get; set; }

        public Node Create(string url) {
            if (RemoveEscapeCharacters) {
                url = url.Replace("\t", "");
            }

            if (StringNodeDecode) {
                url = url.ToUpper();
            }

            // использование NodeFactoryX
            if (url.StartsWith("c:")) {
                return nodeFactoryX.Create<CompanyNode>();
            }
            if (url.StartsWith("p:")) {
                return nodeFactoryX.Create<PersonNode>();
            }
            if (url.StartsWith("n:")) {
                return nodeFactoryX.Create<NonProfitFoundationNode>();
            }

            // использование NodeFactoryY
            return nodeFactoryY.Create(url.Take(2).ToString());

            return new UndefinedNode();
        }
    }


    /// <summary>
    /// Настоящая фабрика в современном видении
    /// </summary>
    internal class NodeFactoryX {
        public T Create<T>()  where T : Node, new() {
            return new T();
        }
    }


    internal class NodeFactoryY {

        private Dictionary<string, Type> map = new Dictionary<string, Type> {
            {"c:", typeof (CompanyNode)},
            {"p:", typeof (PersonNode)},
            {"n:", typeof (NonProfitFoundationNode)},
        };

        public Node Create(string key) {
            return (Node) map[key].GetConstructor(new Type[] {}).Invoke(new object[] {});
        }
    }
   
}