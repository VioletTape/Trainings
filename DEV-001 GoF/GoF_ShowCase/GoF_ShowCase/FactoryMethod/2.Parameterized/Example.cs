namespace GoF_ShowCase.FactoryMethod.Parameterized {
    public class Example {
        public Example() {
            var document = new Document();

            var rtfDocumentManager = new RtfDocumentManager().CreateStorage();
            rtfDocumentManager.Save("somename", document);
        }
    }
}