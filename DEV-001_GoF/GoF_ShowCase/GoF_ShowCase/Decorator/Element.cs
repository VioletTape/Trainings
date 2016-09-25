using System;

namespace GoF_ShowCase.Decorator {
    public interface IElement {
        string Text { get; set; }
        void Draw();
    }

    public class Element : IElement {
        public string Text { get; set; }

        public void Draw() {
            Console.WriteLine("Element text = {0}", Text);
        }
    }
}