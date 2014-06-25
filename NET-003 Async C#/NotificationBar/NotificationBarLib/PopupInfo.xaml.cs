using System.Windows.Controls;
using System.Windows.Input;
using NotificationBarLib.Core;

namespace NotificationBarLib {
    public partial class PopupInfo : UserControl {
        public PopupInfo() {
            InitializeComponent();
        }

        private void CloseHover(object sender, MouseButtonEventArgs e) {
            ((NotificationInfo) DataContext).RemoveWithoutNavigation();
        }

        private void MouseOverControlEnter(object sender, MouseEventArgs e) {
            ((NotificationInfo) DataContext).RestartTimer();
        }

        private void MouseOverControlLeave(object sender, MouseEventArgs e) {
            ((NotificationInfo) DataContext).StartTimer();
        }
    }
}