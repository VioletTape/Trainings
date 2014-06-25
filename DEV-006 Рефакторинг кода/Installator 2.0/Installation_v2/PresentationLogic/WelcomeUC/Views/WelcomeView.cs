using System.Windows.Forms;
using Installation_v2.PresentationLogic.WelcomeUC.DataState;

namespace Installation_v2.PresentationLogic.WelcomeUC.Views {
    public partial class WelcomeView : UserControl, IWelcomeView {
        public WelcomeView() {
            InitializeComponent();
        }

        BaseViewState IBaseView.State {
            get { return State; }
            set { State = (WelcomeViewState) value; }
        }

        public WelcomeViewState State {
            get {
                bindingSource.EndEdit();
                return (WelcomeViewState) bindingSource[0];
            }
            set { bindingSource.DataSource = value; }
        }
    }
}