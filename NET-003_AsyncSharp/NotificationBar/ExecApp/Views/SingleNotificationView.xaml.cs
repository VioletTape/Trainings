using System.Windows.Controls;
using Presentation.ViewInterfaces;

namespace ExecApp.Views {
    public partial class SingleNotificationView : UserControl, ISingleNotification {
        public SingleNotificationView() {
            InitializeComponent();
        }
    }
}