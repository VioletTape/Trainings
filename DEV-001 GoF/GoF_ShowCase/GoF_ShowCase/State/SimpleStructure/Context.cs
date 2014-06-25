using System;

namespace GoF_ShowCase.State.SimpleStructure {
    internal class Context {
        private State state;

        public Context(State state) {
            State = state;
        }

        public State State {
            get { return state; }
            set {
                state = value;
                Console.WriteLine("State: " +
                                  state.GetType().Name);
            }
        }

        public void Request() {
            state.Handle(this);
        }
    }
}