using System.Windows.Forms;
using Installation_v2.PresentationLogic.RequirementsCheckupUC.DataState;
using Installation_v2.PresentationLogic.WelcomeUC.Views;

namespace Installation_v2.PresentationLogic.RequirementsCheckupUC.Views {
    public partial class RequirementsCheckupView : UserControl, IRequirementCheckupView {
        public RequirementsCheckupView() {
            InitializeComponent();
        }

        BaseViewState IBaseView.State {
            get { return State; }
            set { State = (RequirementCheckupViewState) value; }
        }

        public RequirementCheckupViewState State {
            get {
                bindingSource.EndEdit();
                return (RequirementCheckupViewState) bindingSource[0];
            }
            set {
                bindingSource.DataSource = value;
                grid.DataSource = value.Requirements;
                bindingSource.ResetBindings(true);
            }
        }
    }
}