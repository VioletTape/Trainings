using System;

namespace GoF_ShowCase.FactoryMethod.StaticInternal {
    public abstract class DocumentManager {
        private static IDocStorage storage;

        public static IDocStorage CreateStorage(StorageFormat format) {
            switch (format) {
                case StorageFormat.Txt:
                    storage = new TxtDocumentManager.TxtDocStorage();
                    return storage;

                case StorageFormat.Rtf:
                    storage = new RtfDocumentManager.RtfDocStorage();
                    return storage;

                default:
                    throw new ArgumentException("An invalid format: " + format.ToString());
            }
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

    public enum StorageFormat {
        Txt,
        Rtf
    }
}