using System;

namespace GoF_ShowCase.Decorator {
    public class ElementStrikedDecorator : ElementDecoratorBase {
        public ElementStrikedDecorator(IElement component) : base(component) {}

        public override void Draw() {
            Component.Draw();
            Strike();
        }

        private void Strike() {
            Console.WriteLine("Striked");
        }
    }
}