namespace GoF_ShowCase.AbstractFactory.ClassicExample {
    public class Example {
        public Example() {
            IGUIFactory guiFactory = new DefaultGUIFactory();
            GetUserInput(guiFactory);

            guiFactory = new SkinnedGUIFactory();
            GetUserInput(guiFactory);
        }

        public string GetUserInput(IGUIFactory guiFactory) {
            // Create UI elements
            var wndInput = guiFactory.CreateWindow();
            var btnOk = guiFactory.CreateButton();
            var btnCancel = guiFactory.CreateButton();
            var tbInput = guiFactory.CreateTextbox();

            // TODO: Setup the window and elements
            wndInput.AddChild(btnOk);
            wndInput.AddChild(btnCancel);
            wndInput.AddChild(tbInput);

            // TODO: Show dialog
            // TODO: Get the result

            return tbInput.GetText();
        }
    }
}