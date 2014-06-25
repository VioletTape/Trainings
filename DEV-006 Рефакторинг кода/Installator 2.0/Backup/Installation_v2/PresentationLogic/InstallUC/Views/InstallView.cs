using System.Windows.Forms;
using Installation_v2.PresentationLogic.InstallUC.DataState;
using Installation_v2.PresentationLogic.WelcomeUC.Views;

namespace Installation_v2.PresentationLogic.InstallUC.Views {
    public partial class InstallView : UserControl, IInstallView {
        public InstallView() {
            InitializeComponent();
        }

        BaseViewState IBaseView.State {
            get { return State; }
            set { State = (InstallViewState) value; }
        }

        public InstallViewState State {
            get {
                bindingSource.EndEdit();
                return (InstallViewState) bindingSource[0];
            }
            set {
                bindingSource.DataSource = value;
                grid.DataSource = value.Requirements;
                bindingSource.ResetBindings(true);
                Refresh();
            }
        }

         private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if(e.ColumnIndex == 2 && !string.IsNullOrEmpty(State.Requirements[e.RowIndex].ErrorFullText)) {
                MessageBox.Show(State.Requirements[e.RowIndex].ErrorFullText);
            }
        }
    }
}