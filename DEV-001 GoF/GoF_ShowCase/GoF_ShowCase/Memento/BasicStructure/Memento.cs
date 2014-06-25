namespace GoF_ShowCase.Memento.BasicStructure {
    internal class Memento {
        private readonly string state;

        // Constructor
        public Memento(string state) {
            this.state = state;
        }

        // Gets or sets state
        public string State {
            get { return state; }
        }
    }
}