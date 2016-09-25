namespace GoF_ShowCase.AbstractFactory.ClassicExample {
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
}