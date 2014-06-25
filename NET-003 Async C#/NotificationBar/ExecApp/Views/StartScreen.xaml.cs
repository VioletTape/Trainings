using System.Windows.Controls;
using Presentation.ViewInterfaces;

namespace ExecApp.Views {
    /// <summary>
    ///   Interaction logic for StartScreen.xaml
    /// </summary>
    public partial class StartScreen : UserControl, IStartScreen {
        public StartScreen() {
            InitializeComponent();
        }
    }
}