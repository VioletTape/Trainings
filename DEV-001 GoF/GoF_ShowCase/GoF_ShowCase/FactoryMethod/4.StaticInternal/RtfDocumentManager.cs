using System;

namespace GoF_ShowCase.FactoryMethod.StaticInternal {
    public class RtfDocumentManager : DocumentManager {
        private RtfDocumentManager() {}

        internal class RtfDocStorage : IDocStorage {
            public void Save(string name, Document document) {
                throw new NotImplementedException();
            }

            public Document Load(string name) {
                throw new NotImplementedException();
            }
        }
    }
}