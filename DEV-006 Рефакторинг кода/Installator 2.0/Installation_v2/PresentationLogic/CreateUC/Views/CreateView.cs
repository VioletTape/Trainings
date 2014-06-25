using System;
using System.Windows.Forms;
using Installation_v2.PresentationLogic.CreateUC.DataState;
using Installation_v2.PresentationLogic.WelcomeUC.Views;

namespace Installation_v2.PresentationLogic.CreateUC.Views {
    public partial class CreateView : UserControl, ICreateView {
        public CreateView() {
            InitializeComponent();
        }

        BaseViewState IBaseView.State {
            get { return State; }
            set { State = (CreateViewState) value; }
        }

        public CreateViewState State {
            get {
                bindingSource.EndEdit();
                var source = (CreateViewState) bindingSource[0];
                return source;
            }
            set { bindingSource.DataSource = value; }
        }


        private void button4_Click(object sender, EventArgs e) {

            State.CreateCore("");
        }

        private void dialogCE_Click(object sender, EventArgs e) {
            if (folderDialog.ShowDialog() != DialogResult.OK) return;

            pathToCE.Text = folderDialog.SelectedPath;
        }

        private void pathToExe_Click(object sender, EventArgs e) {
            if (folderDialog.ShowDialog() != DialogResult.OK) return;

            pathToExe.Text = folderDialog.SelectedPath;
        }

        private void dialogVsvars_Click(object sender, EventArgs e) {
            if (folderDialog.ShowDialog() != DialogResult.OK) return;

            vsvars.Text = folderDialog.SelectedPath;
        }

        private void dialogCsc_Click(object sender, EventArgs e) {
            if (folderDialog.ShowDialog() != DialogResult.OK) return;

            csc.Text = folderDialog.SelectedPath;
        }

        private void dialogPathToAppl_Click(object sender, EventArgs e) {
            if (folderDialog.ShowDialog() != DialogResult.OK) return;

            pathToAppl.Text = folderDialog.SelectedPath;
        }
    }
}