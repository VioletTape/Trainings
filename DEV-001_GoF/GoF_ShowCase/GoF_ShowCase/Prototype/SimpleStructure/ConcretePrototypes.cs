namespace GoF_ShowCase.Prototype.SimpleStructure {
    internal class ConcretePrototype1 : Prototype {
        public ConcretePrototype1(string id) : base(id) {}

        public override Prototype Clone() {
            // Shallow copy 
            return (Prototype) MemberwiseClone();
        }
    }

    internal class ConcretePrototype2 : Prototype {
        public ConcretePrototype2(string id) : base(id) {}

        public override Prototype Clone() {
            // Shallow copy 
            return (Prototype) MemberwiseClone();
        }
    }
}