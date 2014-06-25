namespace GoF_ShowCase.FactoryMethod.StaticInternal {
    public class Example {
        public Example() {
            var document = new Document();

           var documentManager = DocumentManager.CreateStorage(StorageFormat.Rtf);
            documentManager.Save(document.Name, document);
        }
    }
}