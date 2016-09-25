namespace GoF_ShowCase.FactoryMethod.Template {
        internal class TxtDocStorage : IDocStorage {
            public void Save(string name, Document document) {
                 throw new System.NotImplementedException();
            }

            public Document Load(string name) {
                throw new System.NotImplementedException();
            }
        }

}