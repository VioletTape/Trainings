using Installation_v2.PresentationLogic.RequirementsInstallUC.DataState;
using Installation_v2.PresentationLogic.WelcomeUC.Views;

namespace Installation_v2.PresentationLogic.RequirementsInstallUC.Views {
    public interface IRequirementsInstallView : IBaseView {
        new RequirementsInstallViewState State { get; set; }
    }
}