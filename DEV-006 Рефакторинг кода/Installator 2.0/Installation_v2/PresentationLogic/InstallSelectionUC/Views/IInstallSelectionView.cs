using Installation_v2.PresentationLogic.InstallSelectionUC.DataState;
using Installation_v2.PresentationLogic.WelcomeUC.Views;

namespace Installation_v2.PresentationLogic.InstallSelectionUC.Views {
    public interface IInstallSelectionView : IBaseView {
        new InstallSelectionViewState State { get; set; }
    }
}