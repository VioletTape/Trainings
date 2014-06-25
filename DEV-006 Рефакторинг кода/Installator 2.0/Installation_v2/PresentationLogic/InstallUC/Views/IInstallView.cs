using Installation_v2.PresentationLogic.InstallUC.DataState;
using Installation_v2.PresentationLogic.WelcomeUC.Views;

namespace Installation_v2.PresentationLogic.InstallUC.Views {
    public interface IInstallView : IBaseView {
        new InstallViewState State { get; set; }
    }
}