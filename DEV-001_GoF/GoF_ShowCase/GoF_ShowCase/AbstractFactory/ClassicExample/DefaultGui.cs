namespace GoF_ShowCase.AbstractFactory.ClassicExample {
    /// Default GUI
    public class DefaultWindow : IWindow {
        public void AddChild(object obj) {}
    }

    public class DefaultButton : IButton {}

    public class DefaultTextBox : ITextBox {
        public string GetText() {
            return "";
        }
    }

    public class DefaultGUIFactory : IGUIFactory {
        public IWindow CreateWindow() {
            return new DefaultWindow();
        }

        public IButton CreateButton() {
            return new DefaultButton();
        }

        public ITextBox CreateTextbox() {
            return new DefaultTextBox();
        }
    }
}