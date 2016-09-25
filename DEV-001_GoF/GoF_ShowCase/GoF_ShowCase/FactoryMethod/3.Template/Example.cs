namespace GoF_ShowCase.FactoryMethod.Template {
    public class Example {
        public Example() {
            var document = new Document();

            var documentManager = new DocumentManager();
            documentManager.SetStorage<TxtDocStorage>();
            documentManager.Save(document);
        }
    }
}