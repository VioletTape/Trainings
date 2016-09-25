using System;
using System.Runtime.ConstrainedExecution;

namespace GoF_TryOut.Memento.StraightCode {
    public class MementoExample {
        public MementoExample() {
            var contact = new Contact(Contact.Type.Private);
            contact.Name = "Bruce";
            contact.LastName = "Waine";

            var service = new ContactService();
            service.Save(contact);

            Print(contact);
            var editingContact = service.StartEdit(contact);
            editingContact.CellNumber = "555-23-11";
            service.Commit(editingContact);
            Print(editingContact);


            editingContact.HomeNumber = "12234";
            service.Commit(editingContact);
            Print(editingContact);

            editingContact.LastName = "Batman";
            service.Commit(editingContact);
            Print(editingContact);

            Console.WriteLine("");
            Console.WriteLine("Undo");
            editingContact = service.Undo(editingContact);
            Print(editingContact);

            editingContact = service.Undo(editingContact);
            Print(editingContact);

            editingContact = service.Undo(editingContact);
            Print(editingContact);

            editingContact = service.Undo(editingContact);
            Print(editingContact);

            Console.WriteLine("");
            Console.WriteLine("Redo");
            editingContact = service.Redo(editingContact);
            Print(editingContact);

            editingContact = service.Redo(editingContact);
            Print(editingContact);

            service.EndEdit(editingContact);
        }

        private void Print(Contact contact) {
            Console.WriteLine(contact);
        }
    }
}