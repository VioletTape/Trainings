namespace GoF_ShowCase.FactoryMethod.Parameterized {
    public class TxtDocumentManager : DocumentManager {
        public IDocStorage CreateStorage() {
            return CreateStorage(StorageFormat.Txt);
        }

        internal class TxtDocStorage : IDocStorage {
            public void Save(string name, Document document) {
                 throw new System.NotImplementedException();
            }

            public Document Load(string name) {
                throw new System.NotImplementedException();
            }
        }

       
    }
}