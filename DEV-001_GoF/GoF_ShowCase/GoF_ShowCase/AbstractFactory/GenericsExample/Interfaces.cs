namespace GoF_ShowCase.AbstractFactory.GenericsExample {
    public interface IWindow {
        void AddChild(object obj);
    }

    public interface IButton {}

    public interface ITextBox {
        string GetText();
    }

    public interface IGUIFactory {
        IWindow CreateWindow();
        IButton CreateButton();
        ITextBox CreateTextbox();
    }

    public class GUIFactoryGeneric<TWindow, TButton, TTextBox> : IGUIFactory
        where TWindow : IWindow, new()
        where TButton : IButton, new()
        where TTextBox : ITextBox, new() {
        public IWindow CreateWindow() {
            return new TWindow();
        }

        public IButton CreateButton() {
            return new TButton();
        }

        public ITextBox CreateTextbox() {
            return new TTextBox();
        }
    }
}