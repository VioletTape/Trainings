namespace GoF_ShowCase.FactoryMethod.ClassicExample {
    public class RtfDocumentManager : DocumentManager {
        private class RtfDocStorage : IDocStorage {
            public void Save(string name, Document document) {
                throw new System.NotImplementedException();
            }

            public Document Load(string name) {
                throw new System.NotImplementedException();
            }
        }

        public override IDocStorage CreateStorage() {
            return new RtfDocStorage();
        }
    }
}