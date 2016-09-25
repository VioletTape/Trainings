using System;

namespace GoF_ShowCase.FactoryMethod.Parameterized {
    public abstract class DocumentManager {
        private StorageFormat format;

        public IDocStorage CreateStorage(StorageFormat format) {
            this.format = format;
            switch (format) {
                case StorageFormat.Txt:
                    return new TxtDocumentManager.TxtDocStorage();

                case StorageFormat.Rtf:
                    return new RtfDocumentManager.RtfDocStorage();

                default:
                    throw new ArgumentException("An invalid format: " + format.ToString());
            }
        }

        public bool Save(Document document) {
            if (!SaveDialog()) {
                return false;
            }

            // using Factory method to create a new document storage
            var storage = CreateStorage(format);

            storage.Save(document.Name, document);

            return true;
        }

        private bool SaveDialog() {
            return false;
        }
    }

    public enum StorageFormat {
        Txt,
        Rtf
    }
}