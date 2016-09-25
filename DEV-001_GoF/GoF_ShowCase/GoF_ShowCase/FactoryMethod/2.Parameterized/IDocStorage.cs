namespace GoF_ShowCase.FactoryMethod.Parameterized {
    public interface IDocStorage {
        void Save(string name, Document document);
        Document Load(string name);
    }
}