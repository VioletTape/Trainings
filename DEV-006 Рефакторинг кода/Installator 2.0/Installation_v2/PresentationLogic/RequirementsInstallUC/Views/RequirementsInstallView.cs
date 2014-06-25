using System.Windows.Forms;
using Installation_v2.PresentationLogic.RequirementsInstallUC.DataState;
using Installation_v2.PresentationLogic.WelcomeUC.Views;

namespace Installation_v2.PresentationLogic.RequirementsInstallUC.Views {
    public partial class RequirementsInstallView : UserControl, IRequirementsInstallView {
        public RequirementsInstallView() {
            InitializeComponent();
        }

        BaseViewState IBaseView.State {
            get { return State; }
            set { State = (RequirementsInstallViewState) value; }
        }

        public RequirementsInstallViewState State {
            get {
                bindingSource.EndEdit();
                return (RequirementsInstallViewState) bindingSource[0];
            }
            set {
                bindingSource.DataSource = value;
                grid.DataSource = value.Requirements;
                bindingSource.ResetBindings(true);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if(e.ColumnIndex == 2 && !string.IsNullOrEmpty(State.Requirements[e.RowIndex].ErrorFullText)) {
                MessageBox.Show(State.Requirements[e.RowIndex].ErrorFullText);
            }
        }
    }
}