using System.Windows.Forms;
using Installation_v2.PresentationLogic.End.DataState;
using Installation_v2.PresentationLogic.WelcomeUC.Views;

namespace Installation_v2.PresentationLogic.End.Views {
    public partial class EndView : UserControl, IEndView {
        public EndView() {
            InitializeComponent();
        }

        BaseViewState IBaseView.State {
            get { return State; }
            set { State = (EndViewState) value; }
        }

        public EndViewState State {
            get {
                bindingSource.EndEdit();
                return (EndViewState) bindingSource[0];
            }
            set { bindingSource.DataSource = value; }
        }
    }
}