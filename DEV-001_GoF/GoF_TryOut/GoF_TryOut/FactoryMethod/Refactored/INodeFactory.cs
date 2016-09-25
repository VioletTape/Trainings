namespace GoF_TryOut.FactoryMethod.Refactored {
    internal interface INodeFactory {
        bool StringNodeDecode { get; set; }
        bool RemoveEscapeCharacters { get; set; }
        Node Create(string url);
    }
}