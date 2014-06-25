namespace GoF_ShowCase.FactoryMethod.ClassicExample {
    public abstract class DocumentManager {
        public abstract IDocStorage CreateStorage();

        public bool Save(Document document) {
            if (!SaveDialog()) {
                return false;
            }

            // using Factory method to create a new document storage
            var storage = CreateStorage();

            storage.Save(document.Name, document);

            return true;
        }

        private bool SaveDialog() {
            return false;
        }
    }
}