using System.Windows.Forms;
using Installation_v2.PresentationLogic.LicenseUC.DataState;
using Installation_v2.PresentationLogic.WelcomeUC.DataState;
using Installation_v2.PresentationLogic.WelcomeUC.Views;

namespace Installation_v2.PresentationLogic.LicenseUC.Views {
    public partial class LicenseView : UserControl, ILicenseView {
        public LicenseView() {
            InitializeComponent();
        }

        BaseViewState IBaseView.State {
            get { return State; }
            set { State = (LicenseViewState) value; }
        }

        public LicenseViewState State {  get {
                bindingSource.EndEdit();
                return (LicenseViewState) bindingSource[0];
            }
            set { bindingSource.DataSource = value; } }
    }
}