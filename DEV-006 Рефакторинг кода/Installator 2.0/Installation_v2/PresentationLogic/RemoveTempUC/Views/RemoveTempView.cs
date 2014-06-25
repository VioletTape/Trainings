using System;
using System.Windows.Forms;
using Installation_v2.PresentationLogic.RemoveTempUC.DataState;
using Installation_v2.PresentationLogic.WelcomeUC.Views;

namespace Installation_v2.PresentationLogic.RemoveTempUC.Views {
    public partial class RemoveTempView : UserControl, IRemoveTempView {
        public RemoveTempView() {
            InitializeComponent();
        }

        BaseViewState IBaseView.State {
            get { return State; }
            set { State = (RemoveTempViewState) value; }
        }

        public RemoveTempViewState State {
            get {  bindingSource.EndEdit();
                return (RemoveTempViewState) bindingSource[0]; }
            set { bindingSource.DataSource = value;
//                grid.DataSource = value.Requirements;
                bindingSource.ResetBindings(true); }
        }

         private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if(e.ColumnIndex == 2 && !string.IsNullOrEmpty(State.Requirements[e.RowIndex].ErrorFullText)) {
                MessageBox.Show(State.Requirements[e.RowIndex].ErrorFullText);
            }
        }
    }
}