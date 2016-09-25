namespace GoF_ShowCase.FactoryMethod.Parameterized {
    public class RtfDocumentManager : DocumentManager {
         public IDocStorage CreateStorage() {
            return CreateStorage(StorageFormat.Rtf);
        }
        internal class RtfDocStorage : IDocStorage {
            public void Save(string name, Document document) {
                throw new System.NotImplementedException();
            }

            public Document Load(string name) {
                throw new System.NotImplementedException();
            }
        }

       
    }
}