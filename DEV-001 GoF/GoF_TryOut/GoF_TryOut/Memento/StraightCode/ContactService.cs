using System;
using System.Collections.Generic;

namespace GoF_TryOut.Memento.StraightCode {
    public class ContactService {
        private List<Contact> contacts;
        private Dictionary<Guid, List<Contact>> editingContacts;
        private Dictionary<Guid, int> editIndex;

        public ContactService() {
            contacts = new List<Contact>();
            editingContacts = new Dictionary<Guid, List<Contact>>();
            editIndex = new Dictionary<Guid, int>();
        }

        public void Save(Contact contact) {
            contacts.Add(contact);
        }

        public Contact Find(string value) {
            return null;
        }

        public Contact StartEdit(Contact contact) {
            if (!contacts.Contains(contact)) {
                contacts.Add(contact);
            }

            editingContacts.Add(contact.Guid, new List<Contact> {contact});
            editIndex.Add(contact.Guid, 1);

            return contact.Clone();
        }

        public void Commit(Contact contact) {
            for (var i = editIndex[contact.Guid]; i < editingContacts[contact.Guid].Count-1; i++) {
                editingContacts[contact.Guid].RemoveAt(i);
            }

            var clone = contact.Clone();
            editingContacts[contact.Guid].Add(clone);
            editIndex[contact.Guid] = editingContacts[contact.Guid].Count - 1;
        }

        public Contact Redo(Contact contact) {
            if (editIndex[contact.Guid] < 0) {
                editIndex[contact.Guid] = 0;
            }
            var index = ++editIndex[contact.Guid];
            if (index >= editingContacts[contact.Guid].Count - 1) {
                return contact;
            }
            var redo = editingContacts[contact.Guid][index];
            return redo;
        }

        public Contact Undo(Contact contact) {
            var index = editIndex[contact.Guid];
            editIndex[contact.Guid]--;
            var undo = editingContacts[contact.Guid][index];
            return undo;
        }

        public void EndEdit(Contact contact) {
            editingContacts[contact.Guid].Clear();
            editIndex.Remove(contact.Guid);
        }
    }
}