namespace GoF_ShowCase.AbstractFactory.ClassicExample {
    /// Skinned GUI
    public class SkinnedWindow : IWindow {
        public void AddChild(object obj) {}
    }

    public class SkinnedButton : IButton {}

    public class SkinnedTextBox : ITextBox {
        public string GetText() {
            return "";
        }
    }

    public class SkinnedGUIFactory : IGUIFactory {
        public IWindow CreateWindow() {
            return new SkinnedWindow();
        }

        public IButton CreateButton() {
            return new SkinnedButton();
        }

        public ITextBox CreateTextbox() {
            return new SkinnedTextBox();
        }
    }
}