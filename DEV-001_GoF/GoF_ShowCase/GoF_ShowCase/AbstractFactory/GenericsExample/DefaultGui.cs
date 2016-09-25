namespace GoF_ShowCase.AbstractFactory.GenericsExample {
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

    public class DefaultGUIFactory :
        GUIFactoryGeneric<DefaultWindow, DefaultButton, DefaultTextBox> {};
}