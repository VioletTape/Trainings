namespace GoF_ShowCase.FactoryMethod.ClassicExample {
    public class Example {
        public Example() {
            var document = new Document();

            var docStorage = new RtfDocumentManager().CreateStorage();  
            docStorage.Save("filename", document);
        }
    }
}