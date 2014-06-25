using Installation_v2.PresentationLogic.LicenseUC.DataState;
using Installation_v2.PresentationLogic.WelcomeUC.Views;

namespace Installation_v2.PresentationLogic.LicenseUC.Views {
    public interface ILicenseView : IBaseView {
        new LicenseViewState State { get; set; }
    }
}