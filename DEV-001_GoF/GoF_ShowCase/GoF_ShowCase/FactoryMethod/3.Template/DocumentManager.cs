namespace GoF_ShowCase.FactoryMethod.Template {
    public class DocumentManager {
        private IDocStorage storage;

        public void SetStorage<T>() where T : IDocStorage, new() {
            storage = new T();
        }

        public bool Save(Document document) {
            if (!SaveDialog()) {
                return false;
            }

            storage.Save(document.Name, document);

            return true;
        }

        private bool SaveDialog() {
            return false;
        }
    }
}