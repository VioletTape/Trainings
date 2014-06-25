namespace GoF_ShowCase.Prototype.SimpleStructure {
    internal abstract class Prototype {
        private readonly string id;

        public Prototype(string id) {
            this.id = id;
        }

        public string Id {
            get { return id; }
        }

        public abstract Prototype Clone();
    }
}