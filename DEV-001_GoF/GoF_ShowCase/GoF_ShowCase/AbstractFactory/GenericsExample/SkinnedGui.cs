namespace GoF_ShowCase.AbstractFactory.GenericsExample {
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

    public class SkinnedGUIFactory :
        GUIFactoryGeneric<SkinnedWindow, SkinnedButton, SkinnedTextBox> {};
}