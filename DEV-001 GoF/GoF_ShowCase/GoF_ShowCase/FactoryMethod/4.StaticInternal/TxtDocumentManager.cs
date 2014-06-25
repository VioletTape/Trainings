using System;

namespace GoF_ShowCase.FactoryMethod.StaticInternal {
    public class TxtDocumentManager : DocumentManager {
        private TxtDocumentManager() {}

        internal class TxtDocStorage : IDocStorage {
            internal TxtDocStorage() {}

            public void Save(string name, Document document) {
                throw new NotImplementedException();
            }

            public Document Load(string name) {
                throw new NotImplementedException();
            }
        }
    }
}