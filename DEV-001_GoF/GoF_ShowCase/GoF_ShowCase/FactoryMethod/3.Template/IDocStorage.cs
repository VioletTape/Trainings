namespace GoF_ShowCase.FactoryMethod.Template {
    public interface IDocStorage {
        void Save(string name, Document document);
        Document Load(string name);
    }
}