namespace GoF_ShowCase.FactoryMethod.ClassicExample {
    public class TxtDocumentManager : DocumentManager {
        private class TxtDocStorage : IDocStorage {
            public void Save(string name, Document document) {
                throw new System.NotImplementedException();
            }

            public Document Load(string name) {
                throw new System.NotImplementedException();
            }
        }

        public override IDocStorage CreateStorage() {
            return new TxtDocStorage();
        }
    }
}