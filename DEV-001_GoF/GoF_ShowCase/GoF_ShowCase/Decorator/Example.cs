using System;
using System.Drawing;

namespace GoF_ShowCase.Decorator {
    public static class Example {
        public static void DrawElement(IElement element) {
            element.Draw();
            Console.WriteLine("---------------------------");
        }

        public static void Execute() {
            var element = new Element();
            DrawElement(element);


            var elementBgnd = new ElementBgndDecorator(element);
            elementBgnd.Background = new Bitmap(10, 10);

            var elementStriked = new ElementStrikedDecorator(elementBgnd);
            elementStriked.Text = "Demo";

            DrawElement(elementStriked);
        }
    }
}