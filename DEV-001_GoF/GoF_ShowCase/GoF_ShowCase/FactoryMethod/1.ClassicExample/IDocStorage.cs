namespace GoF_ShowCase.FactoryMethod.ClassicExample {
    public interface IDocStorage {
        void Save(string name, Document document);
        Document Load(string name);
    }
}