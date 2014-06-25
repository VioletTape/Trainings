namespace GoF_ShowCase.Decorator {
    public class ElementDecoratorBase : IElement {
        protected readonly IElement Component;

        public ElementDecoratorBase(IElement component) {
            Component = component;
        }

        public virtual string Text {
            get { return Component.Text; }
            set { Component.Text = value; }
        }

        public virtual void Draw() {
            Component.Draw();
        }
    }
}