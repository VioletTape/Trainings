namespace GoF_ShowCase.FactoryMethod.StaticInternal {
    public interface IDocStorage {
        void Save(string name, Document document);
        Document Load(string name);
    }
}