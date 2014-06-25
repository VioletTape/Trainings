using System.Collections.Generic;
using System.Linq;

namespace GoF_TryOut.Memento.Refactored {
    public class ContactService {
        private readonly List<Contact> contacts = new List<Contact>();
        private readonly Dictionary<Contact, ContactKeeper> keepers = new Dictionary<Contact, ContactKeeper>();

        public void Save(Contact contact) {
            if (!contacts.Contains(contact)) {
                contacts.Add(contact);
                keepers[contact] = new ContactKeeper();
            }

            keepers[contact].Set(contact.GetMemento());
        }

        public Contact Find(string value) {
            return null;
        }

        public void Undo(Contact contact) {
            var memento = keepers[contact].GetPrevious();
            contact.SetMemento(memento);
        }

        public void Redo(Contact contact) {
            keepers[contact].CurrentVersion++;
            var memento = keepers[contact].GetCurrent();
            contact.SetMemento(memento);
        }
    }


    public class ContactKeeper {
        private readonly List<Contact.ContactMemento> mementoes = new List<Contact.ContactMemento>();

        public int LastVersion {
            get { return mementoes.Count - 1; }
        }

        public int CurrentVersion { get; set; }

        public void Set(Contact.ContactMemento memento) {
            if (CurrentVersion != LastVersion) {
                var oddMementoes = mementoes.Skip(CurrentVersion).Count();
                mementoes.RemoveRange(CurrentVersion, oddMementoes);
            }

            mementoes.Add(memento);
            CurrentVersion = LastVersion;
        }

        public Contact.ContactMemento GetCurrent() {
            if (CurrentVersion < 0) {
                CurrentVersion = 0;
            }

            if (CurrentVersion > LastVersion) {
                CurrentVersion = LastVersion;
            }

            return mementoes[CurrentVersion];
        }

        public Contact.ContactMemento GetPrevious() {
            var contactMemento = mementoes[CurrentVersion];
            CurrentVersion--;
            if (CurrentVersion < 0)
                CurrentVersion = 0;

            return contactMemento;
        }
    }
}