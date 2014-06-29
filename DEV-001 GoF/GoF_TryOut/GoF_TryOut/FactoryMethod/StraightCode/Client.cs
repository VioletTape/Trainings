namespace GoF_TryOut.FactoryMethod.StraightCode {
    public class Client {
        public void Do() {
            var parser = new Parser();
            parser.StringNodeDecode = true;
            parser.RemoveEscapeCharacters = true;
            var result = parser.Parse("lalala");
        }
    }
}