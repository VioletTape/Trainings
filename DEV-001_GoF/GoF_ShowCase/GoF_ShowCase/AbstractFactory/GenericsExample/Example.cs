using System;

namespace GoF_ShowCase.AbstractFactory.GenericsExample {
    public class Example {
        public Example() {
            var factory = GUI.GetFactory(GUI.Style.Skinned);
            var userInput = GetUserInput(factory);

            factory = GUI.GetFactory(GUI.Style.Default);
            userInput = GetUserInput(factory);
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

    public static class GUI {
        private class GUIFactoryGeneric<TWindow, TButton, TTextBox> : IGUIFactory
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

        public enum Style {
            Default,
            Skinned
        }

        public static IGUIFactory GetFactory(Style guiStyle) {
            switch (guiStyle) {
                case Style.Default:
                    return new GUIFactoryGeneric<DefaultWindow, DefaultButton, DefaultTextBox>();

                case Style.Skinned:
                    return new GUIFactoryGeneric<SkinnedWindow, SkinnedButton, SkinnedTextBox>();
            }

            throw new ArgumentException("An invalid guiStyle: " + guiStyle.ToString());
        }
    }
}