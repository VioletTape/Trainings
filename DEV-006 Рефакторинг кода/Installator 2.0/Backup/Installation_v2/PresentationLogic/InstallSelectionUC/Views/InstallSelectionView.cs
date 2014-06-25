using System;
using System.Windows.Forms;
using Installation_v2.PresentationLogic.InstallSelectionUC.DataState;
using Installation_v2.PresentationLogic.WelcomeUC.Views;

namespace Installation_v2.PresentationLogic.InstallSelectionUC.Views {
    public partial class InstallSelectionView : UserControl, IInstallSelectionView {
        public InstallSelectionView() {
            InitializeComponent();

            SubscribeOnActions();
        }

        private void SubscribeOnActions() {
            for (var i = 0; i < Controls.Count; i++) {
                var button = Controls[i] as Button;
                if (button != null) {
                    button.MouseClick += PerformActionTag;
                }
                var label = Controls[i] as Label;
                if (label != null) {
                    label.MouseClick += PerformActionTag;
                }
            }
        }

        private static void PerformActionTag(object sender, MouseEventArgs e) {
            if (((Control) sender).Tag == null) return;
            ((Action<object>) ((Control) sender).Tag)("");
        }

        private bool sendingChanges;

        BaseViewState IBaseView.State {
            get { return State; }
            set { State = (InstallSelectionViewState) value; }
        }

        public InstallSelectionViewState State {
            get {
                bindingSource.EndEdit();
                return (InstallSelectionViewState) bindingSource[0];
            }
            set { bindingSource.DataSource = value; }
        }

        private void SelectInstalPathClick(object sender, EventArgs e) {
            if (folderBrowser.ShowDialog() == DialogResult.OK) {
                label5.Text = folderBrowser.SelectedPath;
            }
        }

        private void bindingSource_CurrentItemChanged(object sender, EventArgs e) {
            if (!sendingChanges) {
                sendingChanges = true;
                State.AcceptChange(true);
                sendingChanges = false;
            }
        }
    }
}