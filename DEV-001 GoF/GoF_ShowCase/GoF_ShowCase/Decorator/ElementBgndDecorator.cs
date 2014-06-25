using System;
using System.Drawing;

namespace GoF_ShowCase.Decorator {
    public class ElementBgndDecorator : ElementDecoratorBase {
        public Bitmap Background { get; set; }

        public ElementBgndDecorator(IElement component) : base(component) {}

        public override void Draw() {
            SetBackground();
            Component.Draw();
        }

        private void SetBackground() {
            Console.WriteLine("Background");
        }
    }
}