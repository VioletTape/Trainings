using System;

namespace GoF_TryOut.Memento.StraightCode {
    public class Contact {
        private Guid guid = Guid.NewGuid();

        public Guid Guid {
            get { return guid; }
            set { guid = value; }
        }

        public Type ContactType { get; private set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string CellNumber { get; set; }
        public string HomeNumber { get; set; }
        public string Note { get; set; }

        public Contact(Type type) {
            ContactType = type;
        }

        public enum Type {
            Private,
            Public
        }

        protected bool Equals(Contact other) {
            return guid.Equals(other.guid);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            if (obj.GetType() != GetType()) {
                return false;
            }
            return Equals((Contact) obj);
        }

        public override int GetHashCode() {
            return guid.GetHashCode();
        }

        public override string ToString() {
            return string.Format("{0} {1} {2} {3} {4} {5}", guid, ContactType, Name, LastName, CellNumber, HomeNumber);
        }

        public Contact Clone() {
            return new Contact(ContactType) {
                                                Guid = guid,
                                                CellNumber = CellNumber,
                                                ContactType = ContactType,
                                                HomeNumber = HomeNumber,
                                                LastName = LastName,
                                                Name = Name,
                                                Note = Note
                                            };
        }
    }
}